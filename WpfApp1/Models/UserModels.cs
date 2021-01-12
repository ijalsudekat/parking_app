using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class UserModels
    {

        private string userusername;

        public string UserUsername
        {
            get { return userusername; }
            set { userusername = value; }
        }

        private string userpassword;

        public string UserPassword
        {
            get { return userpassword; }
            set { userpassword = value; }
        }

    }
}
