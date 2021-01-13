using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModel.Users
{
    class UserActivityViewModel_cs : INotifyPropertyChanged
    {

     
        public UserActivityViewModel_cs(UserModeling _users)
        {

        }

        public event EventHandler activitys;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
