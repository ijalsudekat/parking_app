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


        public Str SaveData(KategoriModels _kat)
        {
            var client = new RestClient("http://localhost:5000/api/data-kategori");
            var request = new RestRequest(Method.POST);
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
            Console.WriteLine(response.Content);
            var oke = response.StatusCode.ToString();
            if (oke == "Created")
            {
                return true;
            }
            else
            {
                return false;
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

      
    }
}
