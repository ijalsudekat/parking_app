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
                return person;
            }
            else
            {
                return new List<KategoriModels>();
            }
        }

    }
}
