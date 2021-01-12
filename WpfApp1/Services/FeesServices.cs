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


    }
}
