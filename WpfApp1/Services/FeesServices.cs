using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class FeesServices
    {
       

        public FeesServices()
        {
        }


        public bool insertData(int Fessval)
        {
            var client = new RestClient("http://localhost:5000/api/data-fees");
            var request = new RestRequest(Method.POST);
            Dictionary<string, string> bo = new Dictionary<string, string>();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                parkFeesValue = Fessval
               
            });

            var response = client.Post(request);

            var oke = response.StatusCode.ToString();
            JObject o = JObject.Parse(response.Content);

            Console.WriteLine(response.Content);
            return true;
        }

        public bool EditSave(int id, int values)
        {
            var client = new RestClient(String.Format("http://localhost:5000/api/data-fees/{0}",id));
            var request = new RestRequest(Method.PUT);
            Dictionary<string, string> bo = new Dictionary<string, string>();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                parkFeesValue = values
               
            });

            var response = client.Put(request);

            var oke = response.StatusCode.ToString();
            Console.WriteLine(response.Content);

            if (oke == "OK")
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteData(int id)
        {
            var client = new RestClient(String.Format("http://localhost:5000/api/data-fees/{0}", id));
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);
            Dictionary<string, string> bo = new Dictionary<string, string>();

            JObject o = JObject.Parse(response.Content);
            Console.WriteLine(response.Content);
            return true;
        }

        public List<FeesModel> GetFees()
        {
            var arlist = new ArrayList();
            var client = new RestClient("http://localhost:5000/api/data-fees/item");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            IRestResponse response = client.Execute(request);
            
            //Console.WriteLine()

            if (response.IsSuccessful)
            {
                JObject o = JObject.Parse(response.Content);

                JArray a = (JArray)o["data"];

                List<FeesModel> person = a.ToObject<List<FeesModel>>();
                
                return person;
            }
            else
            {
                return new List<FeesModel>();
            }
        }

        internal object SaveData(object katmodel)
        {
            throw new NotImplementedException();
        }
    }
}
