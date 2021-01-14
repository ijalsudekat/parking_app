using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Services;
using System.Net.Http.Headers;

namespace WpfApp1.Services
{
    public class AreaServices
    {
      
        private AreaModel _areamodel;
        private JObject _dataresponse;

        public AreaServices()
        {
        }

        public Dictionary<string,string> editData(AreaModel _area, int id)
        {
            var client = new RestClient(String.Format("http://localhost:5000/api/data-area/{0}",id));
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                AreaNumber = _area.AreaNumber,
                AreaKategoriId = _area.KategoriId,
                AreaParkingFeesId = _area.ParkFeesId
            });

            var response = client.Put(request);
            Console.WriteLine(response.Content);
            var oke = response.StatusCode.ToString();
            Dictionary<String, string> asc = new Dictionary<string, string>();
            JObject o = JObject.Parse(response.Content);
            if (o["state"].ToString() == "1" )
            {

                asc.Add("ef", o["alert"].ToString());
                asc.Add("od", 1.ToString());

                return asc ;
            }
            else if (o["state"].ToString() == "0")
            {
                asc.Add("ef", o["alert"].ToString());
                asc.Add("od", 0.ToString());

                return asc;
            }
            else
            {
                asc.Add("ef", "Edit failed , check connection");
                asc.Add("od", 0.ToString());
                return asc;
            }
        }

        public AreaModel SaveData(AreaModel _area)
        {
           var client = new RestClient("http://localhost:5000/api/data-area");
           var request = new RestRequest(Method.POST);
           request.AddHeader("Content-Type", "application/json");
           request.AddHeader("Accept", "application/json");
           request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
           request.RequestFormat = DataFormat.Json;
           request.AddJsonBody(new{
               AreaNumber = _area.AreaNumber,
               AreaKategoriId = _area.KategoriId,
               AreaParkingFeesId = _area.ParkFeesId
          });

         var response = client.Post(request);
       
         var oke = response.StatusCode.ToString();
            if (oke == "Created"){
                JObject o = JObject.Parse(response.Content);
                
                AreaModel arm = new AreaModel()
                {
                    AreaId = (int)o["data"]["areaId"],
                    AreaNumber = (int)o["data"]["areaNumber"],
                    Kategori = (string)o["data"]["kategori"],
                    ParkFeesValue = (int)o["data"]["fessVal"],
                    CreatedAt = (DateTime)o["data"]["areaCreatedAt"],
                    
                };
               
                return arm;
             }
                else
             {
                 return new AreaModel();
             }
        }

        internal List<AreaModel> GetFilter(string filter)
        {
            var client = new RestClient(String.Format("http://localhost:5000/api/data-area/sort/{0}", filter));
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);

          
            if (response.IsSuccessful)
            {
                JObject o = JObject.Parse(response.Content);

                JArray a = (JArray)o["data"];

                Console.WriteLine(a);

                List<AreaModel> person = a.ToObject<List<AreaModel>>();

                return person;
            }
            else
            {
                return new List<AreaModel>();
            }
        }

        public AreaModel getById(int id)
        {
            var client = new RestClient(string.Format("http://localhost:5000/api/data-area/{0}",id));
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                JObject o = JObject.Parse(response.Content);

                AreaModel arm = new AreaModel()
                {
                    AreaId = (int)o["areaId"],
                    AreaNumber = (int)o["areaNumber"],
                    KategoriId = (int)o["areaKategoriId"],
                    ParkFeesId = (int)o["areaParkingFeesId"],
                    KatNumber = (int)o["katNumber"],
                    CreatedAt = DateTime.UtcNow,
                };
                //Console.WriteLine(o);
                return arm;
            }
            else
            {
                return new AreaModel();
            }
            return new AreaModel();
        }

        public bool Delete(int id)
        {
            var client = new RestClient(String.Format("http://localhost:5000/api/data-area/{0}",id));
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);
            JObject o = JObject.Parse(response.Content);
            if ((string)o["alert"] == "sukses")
            {
                return true;
            }
            return false;
        }

        public List<HistoryModels> GetHistory()
        {

            var client = new RestClient("http://localhost:5000/api/data-history");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                JObject o = JObject.Parse(response.Content);

                JArray a = (JArray)o["data"];

                List<HistoryModels> person = a.ToObject<List<HistoryModels>>();

                return person;
            }
            else
            {
                return new List<HistoryModels>();
            }
        }

        public List<AreaModel> GetAll()
        {
           
            var client = new RestClient("http://localhost:5000/api/data-area");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);
            
            if (response.IsSuccessful)
            {
                JObject o = JObject.Parse(response.Content);

                JArray a = (JArray)o["data"];
                Console.WriteLine("a");
                List<AreaModel> person = a.ToObject<List<AreaModel>>();

                return person;
            }
            else
            {
                return new List<AreaModel>();
            }           
        }

       

    }
}
