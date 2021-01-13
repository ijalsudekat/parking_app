using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class UserModeling
    {
        private int _user_id;

        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private string _user_username;

        public string user_username
        {
            get { return _user_username; }
            set { _user_username = value; }
        }

        private string _user_fullname;

        public string user_fullname
        {
            get { return _user_fullname; }
            set { _user_fullname = value; }
        }

    }
}
