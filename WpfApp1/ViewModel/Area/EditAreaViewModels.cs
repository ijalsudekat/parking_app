
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Services;


namespace WpfApp1.ViewModel.Area
{
    public class EditAreaViewModels : INotifyPropertyChanged
    {
        AreaServices _services = new AreaServices();
        FeesServices _feesServices = new FeesServices();
        AreavIewModels areav = new AreavIewModels();
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
            CurrentArea = seletItem;
            
        }

        private int _katNumber;

        public int KatNumber
        {
            get { return _katNumber; }
            set { _katNumber = value; OnPropertyChanged("katNumber"); }
        }


        private AreaModel _currentArea;

        public AreaModel CurrentArea
        {
            get { return _currentArea; }
            set {
                _currentArea = value;
                OnPropertyChanged("CurrentArea"); }
        }

        private SolidColorBrush colorBrush;

        public SolidColorBrush Coloring
        {
            get { return colorBrush; }
            set { colorBrush = value; OnPropertyChanged("Coloring"); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private bool visibility;

        public bool Visibility
        {
            get { return visibility; }
            set { visibility = value; OnPropertyChanged("Visibility"); }
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

        private KategoriModels _kamodel;

        public KategoriModels Kamodel
        {
            get { return _kamodel; }
            set { _kamodel = value; OnPropertyChanged("Kamodel"); }
        }

        private FeesModel _feemodel;

        public FeesModel Feesmodel
        {
            get { return _feemodel; }
            set { _feemodel = value; OnPropertyChanged("Feesmodel"); }
        }


        private async void Save()
        {

         

            //CurrentArea.KategoriId =  ? CurrentArea.KategoriId : Kamodel.KategoriId;
            //CurrentArea.ParkFeesId = String.IsNullOrEmpty(Feesmodel.ParkFeesId.ToString())? CurrentArea.ParkFeesId : Feesmodel.ParkFeesId;

            if (String.IsNullOrEmpty(CurrentArea.AreaNumber.ToString())
                || String.IsNullOrEmpty(CurrentArea.KategoriId.ToString())
                || String.IsNullOrEmpty(CurrentArea.ParkFeesId.ToString())
                )
            {
                Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Visibility = true;
                Message = "Save failed, check your data";
                var cs = await delayid();
                if (cs)
                    Visibility = false;
            }
            else
            {
                var saving = _services.editData(CurrentArea, CurrentArea.AreaId);
                if (saving["od"] == "1")
                {

                    Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                    Visibility = true;
                    Message = saving["ef"];
                    var cs = await delayid();
                    if (cs)
                    {
                      
                        AreaEdit(saving, null);
                        Visibility = false;
                    }
                }
                else
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = saving["ef"];
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                }
            }
        }
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        async Task<bool> delayid()
        {
            await Task.Delay(2000);
            return true;
        }



    }
}
