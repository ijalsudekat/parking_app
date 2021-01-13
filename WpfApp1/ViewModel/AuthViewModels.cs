using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Services;
using WpfApp1.Commands;
using System.Windows.Controls;
using System.IO;

namespace WpfApp1.ViewModel
{
    public class AuthViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        public AuthViewModels()
        {
            _services = new AuthServices();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private AuthServices _services;
        public bool Login(string username, string password)
        {
            var user = new UserModels();
            user.UserPassword = username;
            user.UserPassword = password;

            var a_data = _services.LogedIn(username, password);
            if (a_data != null)
            {
                string result = Path.GetTempPath();
                string folder = result;
                string fileName = "PkSetting.txt";
                string fullpath = folder + fileName;
                string[] json = { a_data };
                File.WriteAllLines(fullpath, json);
                Console.WriteLine(result);
                return true;
            }
            return false;
        }
    }
}
