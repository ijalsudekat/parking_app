
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Services;


namespace WpfApp1.ViewModel.Area
{
    public class EditAreaViewModels : INotifyPropertyChanged
    {
        AreaServices _services = new AreaServices();
        FeesServices _feesServices = new FeesServices();
        private AreaModel areamodel;    
        public AreaModel AreaSelceted
        {
            get { return areamodel; }
            set { areamodel = value; }
        }


        private string kategoriHall;

        public string KategoriHall
        {
            get { return kategoriHall; }
            set { kategoriHall = value; OnPropertyChanged("KategoriHall"); }
        }

        private int parkfeesvalue;

        public int ParkFeesValue
        {
            get { return parkfeesvalue; }
            set { parkfeesvalue = value; OnPropertyChanged("ParkFeesValue"); }
        }

        public EditAreaViewModels(AreaModel seletItem)
        {
            AreaSelceted = seletItem;
            ParkFeesValue = seletItem.ParkFeesValue;
            KategoriHall = seletItem.Kategori;
        }

        private AreaModel _currentArea;

        public AreaModel CurrentArea
        {
            get { return _currentArea; }
            set {
                _currentArea = value;
                OnPropertyChanged("CurrentArea"); }
        }


        private ICommand editSave;
        public ICommand EditSaveCommand 
        {
            get {
                if (editSave == null)
                    editSave = new RelayCommand(Save);
                return editSave;
            }
        }
        public event EventHandler AreaEdit;
        public event PropertyChangedEventHandler PropertyChanged;

        private void Save()
        {
            Console.WriteLine(AreaSelceted.AreaId);
        }
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
