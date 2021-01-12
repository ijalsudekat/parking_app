using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class AuthServices
    {
        private UserModels _auth;
        public AuthServices()
        {
            _auth = new UserModels();
        }

        public string LogedIn(string username, string password)
        {

            if (!String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(password))
            {

                var client = new RestClient("http://localhost:5000/api/auth/login");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new
                {
                    UserUsername = username,
                    UserPassword = password
                });

                var response = client.Post(request);
                Console.WriteLine(response.Content);
                if (response.IsSuccessful)
                {
                    var toke = response.Content.Replace("\"","");
                    return toke;
                }
                else
                {
                    return null;
                }
            }
            return null;

        }

    }
}
