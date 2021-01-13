using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class KategoriServices : MainServices
    {
        public KategoriServices()
        {
        }

        public List<KategoriModels> GetAll()
        {

            var client = new RestClient("http://localhost:5000/api/data-kategori");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);
           
            if (response.IsSuccessful)
            {
                JObject o = JObject.Parse(response.Content);
                JArray a = (JArray)o["data"];
                List<KategoriModels> person = a.ToObject<List<KategoriModels>>();
                Console.WriteLine(a);
                return person;
            }
            else
            {
                return new List<KategoriModels>();
            }
        }


        public Dictionary<string, string> SaveData(KategoriModels _kat)
        {
            var client = new RestClient("http://localhost:5000/api/data-kategori");
            var request = new RestRequest(Method.POST);
            Dictionary<string, string> bo = new Dictionary<string, string>();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                katAreaName = _kat.KategoriHall,
                katNumber=_kat.katNumber
            });

            var response = client.Post(request);
            
            var oke = response.StatusCode.ToString();
            JObject o = JObject.Parse(response.Content);
            if (oke == "Created")
            {

                bo.Add("el", o["alert"].ToString());
                bo.Add("df", "1");
                return bo ;
            }
            else
            {
                bo.Add("el", o["alert"].ToString());
                bo.Add("df", "0");
                return bo;
            }
        }

        public Dictionary<string, string> EditSave(KategoriModels _kat)
        {
            var client = new RestClient(String.Format("http://localhost:5000/api/data-kategori/{0}", _kat.KategoriId));
            var request = new RestRequest(Method.PUT);
            Dictionary<string, string> bo = new Dictionary<string, string>();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                katAreaName = _kat.KategoriHall,
                katNumber = _kat.katNumber
            });

            var response = client.Put(request);
           
            var oke = response.StatusCode.ToString();
            
         
            if (oke == "OK")
            {
                JObject o = JObject.Parse(response.Content);
                if (Convert.ToInt32(o["state"]) == 1)
                {
                    bo.Add("el", o["alert"].ToString());
                    bo.Add("df", "1");
                    
                }
                else if (Convert.ToInt32(o["state"]) == 2)
                {
                    bo.Add("el", o["alert"].ToString());
                    bo.Add("df", "0");
                   
                }else if(Convert.ToInt32(o["state"]) == 0){
                    bo.Add("el", o["alert"].ToString());
                    bo.Add("df", "0");
                    
                }
                return bo;
            }
            else
            {
                JObject o = JObject.Parse(response.Content);
                bo.Add("el","failed to save data");
                bo.Add("df", "0");
                return bo;
            }
        }


        public List<KategoriModels> GetFillter(string filter)
        {
            var uri = String.Format("http://localhost:5000/api/data-kategori/sort/{0}", filter);
            var client = new RestClient(uri);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                JObject o = JObject.Parse(response.Content);
                JArray a = (JArray)o["data"];
                List<KategoriModels> person = a.ToObject<List<KategoriModels>>();
                Console.WriteLine(a);
                return person;
            }
            else
            {
                return new List<KategoriModels>();
            }
        }

        public Dictionary<string, string> deleteData(int id)
        {
            var client = new RestClient(String.Format("http://localhost:5000/api/data-kategori/{0}", id));
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);
            Dictionary<string, string> bo = new Dictionary<string, string>();

            JObject o = JObject.Parse(response.Content);
            Console.WriteLine(response.Content);
            if (Convert.ToInt32(o["state"]) == 1)
            {
                bo.Add("el", o["alert"].ToString());
                bo.Add("df", o["state"].ToString());
            }
            else if(Convert.ToInt32(o["state"]) == 0)
            {
                bo.Add("el", o["alert"].ToString());
                bo.Add("df", o["state"].ToString());
            }
            return bo;
        }

      
    }
}
