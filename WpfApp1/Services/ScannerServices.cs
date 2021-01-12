using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing;
using WpfApp1.Models;
using WpfApp1.helper;

namespace WpfApp1.Services
{
    public class ScannerServices
    {
        private string filedirs;
        CreateRandomPassword pwd = new CreateRandomPassword();
      
        public Dictionary<string, string> reqQrCode(string scanner)
        {
          
            var password = pwd.randomPassword();
            var username =  String.Format("user_{0}", pwd.RandomUsername());
            var license = scanner;

            var client = new RestClient("http://localhost:5000/api/auth/generate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", string.Format("Bearer {0}", new GetToken().getToken()));
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                PlateNumber = license,
                UserPassword = password,
                UserUsername = username
            });

            var response = client.Post(request);
           
            var oke = response.StatusCode.ToString();
            if (oke == "Created")
            {
                JObject o = JObject.Parse(response.Content);
                Console.WriteLine(o["data"]);

                var datadict = new Dictionary<string, string>();
                datadict.Add("kode_parkir", (string)o["kode"]);
                datadict.Add("fees", (string)o["data"]["feesValue"]);
                datadict.Add("areaNumber", (string)o["data"]["areaNumber"]);
                datadict.Add("areaKatName", (string)o["data"]["areaKatName"]);

                return datadict;
            }
            else
            {
                return new Dictionary<string, string>();
            }
        }

        private void callApi()
        {
            //if (imgInput == null)
            //{
            //    MessageBox.Show("File imgae wajib di isi");
            //    return;
            //}
            //else
            //{
            //    filedirs = opf.FileName;
            //    if (String.IsNullOrEmpty(filedirs))
            //    {
            //        return;
            //    }
            //    var client = new RestClient("http://localhost:8000/ocr-service/");
            //    client.Timeout = -1;
            //    var request = new RestRequest(Method.POST);
            //    request.AddHeader("Content-Type", "multipart/form-data");
            //    request.AddHeader("Accept", "application/json");
            //    request.AddHeader("Connection", "Keep-Alive");
            //    request.AddFile("filed", filedirs);
            //    IRestResponse response = client.Execute(request);

            //    if (response.IsSuccessful)
            //    {

            //        var deserialize = new JsonDeserializer();
            //        var output = deserialize.Deserialize<Dictionary<String, string>>(response);
            //        var result = output["base64_data"];
            //        Base64toImage(result);
                  
            //    }
            //    else
            //    {
            //        Console.WriteLine("server error");
            //    }
            //}

        }

        public System.Drawing.Image Base64toImage(string base64String)
        {
            byte[] imageByte = Convert.FromBase64String(base64String);

            using (MemoryStream ms = new MemoryStream(imageByte, 0, imageByte.Length))
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                //return image;
                //pictureBox2.Width = image.Width;
                //pictureBox2.Height = image.Height;
                //pictureBox2.Image = image;
                return image;
            }
        }

        public byte[] ConvertBitMapToByteArray(Bitmap bitmap)
        {
            byte[] result = null;

            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, bitmap.RawFormat);
                result = stream.ToArray();
            }

            return result;
        }
    }
}
