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

namespace WpfApp1.ViewModel.History
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        public HistoryModels slotmodel = new HistoryModels();
        public HistroryServices _services = new HistroryServices();

        public HistoryViewModel()
        {
            getHistoryData();
        }

        private ObservableCollection<HistoryModels> _hitory;

        public ObservableCollection<HistoryModels> HistoryList
        {
            get { return _hitory; }
            set { _hitory = value; OnPropertyChanged("HistoryList"); }
        }

        


        public void getHistoryData()
        {
            HistoryList = new ObservableCollection<HistoryModels>(_services.GetAll());
        }

        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set { _filter = value; OnPropertyChanged("Filter"); }
        }

        #region data

        private ICommand filtercommand;
        public ICommand Filtercommand
        {
            get
            {
                if (filtercommand == null)
                    filtercommand = new RelayCommand<object>(FilterHist);
                return filtercommand;
            }
        }

        private void FilterHist(object op)
        {

            HistoryList = new ObservableCollection<HistoryModels>(_services.GetFilter(Filter));
           

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
