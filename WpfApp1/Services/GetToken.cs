using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public class GetToken
    {

        public GetToken()
        {

        }

        public string getToken()
        {
           
            string folder = Path.GetTempPath() + "PkSetting.txt";
            if (!File.Exists(folder))
            {
                return "";
            }
            return System.IO.File.ReadAllText(folder);
        }

    }
}
