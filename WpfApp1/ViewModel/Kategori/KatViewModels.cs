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

namespace WpfApp1.ViewModel.Kategori
{
    public class KatViewModels : INotifyPropertyChanged
    {

        public KategoriServices _services = new KategoriServices();
        public KategoriModels _katmodel = new KategoriModels();
        
        public KatViewModels()
        {
            getataKat();
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

        private ObservableCollection<KategoriModels> _kategoris ;
        public ObservableCollection<KategoriModels> Kategosris
        {
            get { return _kategoris; }
            set { _kategoris = value;OnPropertyChanged("Kategosris"); }
        }

        private string filter;

        public string Filter
        {
            get { return filter; }
            set { filter = value; }
        }


        private ICommand filtercommand;
        public ICommand Filtercommand
        {
            get
            {
                if (filtercommand == null)
                    filtercommand = new RelayCommand(FilterHist);
                return filtercommand;
            }
        }

        private void FilterHist()
        {
            Kategosris = new ObservableCollection<KategoriModels>(_services.GetFillter(Filter));
        }

        public void getataKat()
        {
            Kategosris = new ObservableCollection<KategoriModels>(_services.GetAll());
        }


        #region add data
        private ICommand tambahdata;
        public ICommand Tambahdata
        {
            get
            {
                if (tambahdata == null)
                    tambahdata = new RelayCommand<object>(AddData);
                return tambahdata;
            }
        }

        private void AddData(object obj)
        {
            _katmodel.KategoriHall = Katname;
            _katmodel.katNumber = Katnumber;
            //var dataadd = _services.savedata(_katmodel);
            Kategosris = (ObservableCollection<KategoriModels>)obj;

            if (true)
            {
                Kategosris.Add(new KategoriModels() { KategoriHall = Katname, katNumber = Katnumber });
            }
        }

        private int _katnumber;

        public int Katnumber
        {
            get { return _katnumber; }
            set { _katnumber = value; OnPropertyChanged("Katnumber"); }
        }

        private string _katname;

        public string Katname
        {
            get { return _katname; }
            set { _katname = value; OnPropertyChanged("Katname"); }
        }
        #endregion

        #region edit data
        private ICommand editdata;
        public ICommand Editcommand
        {
            get
            {
                if (editdata == null)
                    editdata = new RelayCommand<object>(EditData);
                return editdata;
            }
        }

        private KategoriModels _selectedItem;

        public KategoriModels SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged("SelectedItem"); }
        }

        private int _ids;

        public int Ids
        {
            get { return _ids; }
            set { _ids = value; OnPropertyChanged("Ids"); }
        }

        private void EditData(object obj)
        {
            Console.WriteLine(SelectedItem.katNumber);
           
        }
        #endregion
    }
}
