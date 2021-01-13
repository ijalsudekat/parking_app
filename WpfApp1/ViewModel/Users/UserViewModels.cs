using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;
using WpfApp1.views;

namespace WpfApp1.ViewModel.Users
{
    public class UserViewModels : INotifyPropertyChanged
    {
        public UserModeling slotmodel = new UserModeling();
        public UserServides _services = new UserServides();

        public UserViewModels()
        {
            getUserData();
        }

        private ObservableCollection<UserModeling> _hitory;

        public ObservableCollection<UserModeling> UserList
        {
            get { return _hitory; }
            set { _hitory = value; OnPropertyChanged("HistoryList"); }
        }

        public void getUserData()
        {
            UserList = new ObservableCollection<UserModeling>(_services.GetAll());
        }

        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set { _filter = value; OnPropertyChanged("Filter"); }
        }

        #region data

        //private ICommand filtercommand;
        //public ICommand Filtercommand
        //{
        //    get
        //    {
        //        if (filtercommand == null)
        //            filtercommand = new RelayCommand<object>(FilterHist);
        //        return filtercommand;
        //    }
        //}

        private ICommand activitycommand;
        public ICommand ActivityCommand
        {
            get
            {
                if (activitycommand == null)
                    activitycommand = new RelayCommand(activity);
                return activitycommand;
            }
        }

        private string user_fullname;

        public string UserFullname
        {
            get { return user_fullname; }
            set { user_fullname = value; OnPropertyChanged("UserFullname"); }
        }


        private void activity()
        {

            var dataid = selectedItem.user_id;
            UserFullname = selectedItem.user_fullname;

            if (dataid.ToString() != "" )
            {
                ActivityHisto = new ObservableCollection<HistoryModels>(_services.Activity(dataid));
            }

        }

        private ObservableCollection<HistoryModels> _history;

        public ObservableCollection<HistoryModels> ActivityHisto
        {
            get { return _history; }
            set { _history = value; OnPropertyChanged("ActivityHisto"); }
        }



        private UserModeling selectedItem;

        public UserModeling SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value;OnPropertyChanged("SelectedItem"); }
        }


       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
