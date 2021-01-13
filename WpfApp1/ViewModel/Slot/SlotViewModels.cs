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

namespace WpfApp1.ViewModel.Slot
{
    public class SlotViewModels : INotifyPropertyChanged
    {
        public SlotModel slotmodel = new SlotModel();
        public SlotService _services = new SlotService();
        public SlotViewModels()
        {
            getSlotData();
        }

        private ObservableCollection<SlotModel> slotModel;

        public ObservableCollection<SlotModel> SlotList
        {
            get { return slotModel; }
            set { slotModel = value; OnPropertyChanged("Slotlist"); }
        }


        public void getSlotData()
        {
            SlotList = new ObservableCollection<SlotModel>(_services.GetAll());
           
        }

        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set { _filter = value; OnPropertyChanged("Filter"); }
        }


        private ICommand filtercommand;
        public ICommand Filtercommand
        {
            get
            {
                if (filtercommand == null)
                    filtercommand = new RelayCommand<object>(FilterSlot);
                return filtercommand;
            }
        }

        private void FilterSlot(object op)
        {
            
         SlotList = new ObservableCollection<SlotModel>(_services.GetFilter(Filter));
         
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

    }
}
