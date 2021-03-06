﻿using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class HistroryServices
    {

        public List<HistoryModels> GetFilter(string id)
        {

            var client = new RestClient("http://localhost:5000/api/data-history/" + id);
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
                Console.WriteLine(person);
                return person;
            }
            else
            {
                return new List<HistoryModels>();
            }
        }

        public List<HistoryModels> GetAll()
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


    }
}
