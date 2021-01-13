using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;
using System.Windows.Forms;

namespace WpfApp1.ViewModel.Kategori
{
    public class KatViewModels : INotifyPropertyChanged
    {

        public KategoriServices _services = new KategoriServices();
        public KategoriModels _katmodel = new KategoriModels();
        
        public KatViewModels()
        {
            getataKat();
            binenable = true;
            Editnable = false;
            Visibility = false ;
        }

        private bool editnabled;

        public bool Editnable
        {
            get { return editnabled; }
            set { editnabled = value;OnPropertyChanged("Editnable"); }
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

        private SolidColorBrush _color;

        public SolidColorBrush Coloring
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged("Coloring"); }
        }

        private bool _visibility;

        public bool Visibility
        {
            get { return _visibility; }
            set { _visibility = value;OnPropertyChanged("Visibility"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }



        private async void AddData(object obj)
        {
            
            _katmodel.KategoriHall = Katname;
            _katmodel.katNumber = Katnumber;

            if (String.IsNullOrEmpty(Katname) || String.IsNullOrEmpty(Katnumber.ToString()) )
            {
                Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Visibility = true;
                Message = " Input wajib di isi ";
                var cs = await delayid();
                if (cs)
                    Visibility = false;
            }
            else
            {
                var dataadd = _services.SaveData(_katmodel);

                Kategosris = (ObservableCollection<KategoriModels>)obj;

                if (dataadd["df"] == "0" )
                {
                    Kategosris.Add(new KategoriModels() { KategoriHall = Katname, katNumber = Katnumber });
                    Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                    Visibility = true;
                    Message = dataadd["el"];
                    var cs = await delayid();
                    getataKat();
                    if (cs)
                        Visibility = false;
                }
                else
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = dataadd["el"];
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                }
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

        private ICommand saveedit;
        public ICommand Saveeditcommand
        {
            get
            {
                if (saveedit == null)
                    saveedit = new RelayCommand<object>(Saveedit);
                return saveedit;
            }

        }

        private ICommand deleteData;
        public ICommand Deletecommand
        {
            get
            {
                if (deleteData == null)
                    deleteData = new RelayCommand<object>(deletekat);
                return deleteData;
            }
        }


        public void deletekat(object obj)
        {
            Ids = SelectedItem.KategoriId;

            var confirm = MessageBox.Show(string.Format("this data {0} has ben deleted are you sure ?", SelectedItem.KategoriHall), "Confirm", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                var data = _services.deleteData(SelectedItem.KategoriId);
                if (data["df"] == "1" )
                {
                    getataKat();
                    Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                    Visibility = true;
                    Message = data["el"] ;

                }
                else
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = data["el"];
                }
            }

        }

        public async void Saveedit(object obj)
        {
            _katmodel.KategoriHall = Katname;
            _katmodel.katNumber = Katnumber;
            _katmodel.KategoriId = Ids;
            

            if (String.IsNullOrEmpty(Katname) || String.IsNullOrEmpty(Katnumber.ToString()))
            {
                Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Visibility = true;
                Message = " Input wajib di isi ";
                var cs = await delayid();
                if (cs)
                    Visibility = false;
            }
            else
            {
                var dataadd = _services.EditSave(_katmodel);

                KategoriModels kms = Kategosris.Where(xc => xc.KategoriId == _katmodel.KategoriId).First();


                if (dataadd["df"] != "0")
                {
                    getataKat();
                    Katname = "";
                    Katnumber = 0;
                    Ids = 0;
                    Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                    Visibility = true;
                    Message = dataadd["el"];
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                }
                else
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = dataadd["el"];
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                }
            }

        }

        private ICommand resetcommand;
        public ICommand Resetcommand
        {
            get
            {
                if (resetcommand == null)
                    resetcommand = new RelayCommand(Resetng);
                return resetcommand;
            }
        }

        private void Resetng()
        {
            binenable = true;
            Editnable = false;
            Katname = "";
            Katnumber = 0;
            Ids = 0;
        }


        async Task<bool> delayid()
        {
            await Task.Delay(3000);
            return true;
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
            binenable = false;
            Editnable = true;
            Katname = SelectedItem.KategoriHall;
            Katnumber = SelectedItem.katNumber;
            Ids = SelectedItem.KategoriId;
        }

        private bool _enabled;

        public bool binenable
        {
            get { return _enabled; }
            set { _enabled = value; OnPropertyChanged("binenable"); }
        }


        #endregion

        


    }
}
