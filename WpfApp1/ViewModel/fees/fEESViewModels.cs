using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Models;
using WpfApp1.Services;
using WpfApp1.ViewModel.Area;
using WpfApp1.ViewModel.Kategori;

namespace WpfApp1.ViewModel.fees
{
    public class fEESViewModels : INotifyPropertyChanged
    {

        private FeesServices _services = new FeesServices();
        private FeesModel _feemodel = new FeesModel();
        private AreavIewModels areaView = new AreavIewModels();
       

        public fEESViewModels()
        {
            getFeesData();
            Ednabled = false;
            savnabled = true;
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
            set { _visibility = value; OnPropertyChanged("Visibility"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

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

        private ICommand deletecmd  ;
        public ICommand Deletecommand
        {
            get
            {
                if (deletecmd == null)
                    deletecmd = new RelayCommand<object>(Delete);
                return deletecmd;
            }

        }

        private ICommand resetng;
        public ICommand Resetng
        {
            get
            {
                if (resetng == null)
                    resetng = new RelayCommand<object>(resetData);
                return resetng;
            }

        }

        private void resetData(object obj)
        {
            Ednabled = false;
            savnabled = true;
            FeesVal = "";
            Ids = 0;
        }

        private ObservableCollection<AreaModel> _armodel;
        public ObservableCollection<AreaModel> Areamodel
        {
            get { return _armodel; }
            set { _armodel = value; OnPropertyChanged("Areamodel"); }
        }


        private async void Delete(object obj)
        {
            areaView.getdata();
            Areamodel = areaView.AreaData;

            var dfs = Areamodel.Where(vc => vc.ParkFeesId == SelectedFess.ParkFeesId).Count();

            if (dfs > 0)
            {
                Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Visibility = true;
                Message = "Restricted action ! data used  ";
                var cs = await delayid();
                if (cs)
                    Visibility = false;
                return;
            }
            else
            {
                var data = _services.deleteData(SelectedFess.ParkFeesId);

                if (data)
                {
                    FeesModel fe = new FeesModel();
                    getFeesData();
                    Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                    Visibility = true;
                    Message = "data berhasil di hapus";
                    FeesVal = "";
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                    return;
                }
                else
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = " data gagal di hapus ";
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                    return;
                }
            }

        }

        public bool IsInteger(double d)
        {
            if (d == (int)d) return true;
            else return false;
        }

        private async void Saveedit(object obj)
        {

          
            if (!Regex.IsMatch(FeesVal.ToString(), "[0-9]"))
            {
                Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Visibility = true;
                Message = " Input wajib berupa nomor ";
                var cs = await delayid();
                if (cs)
                    Visibility = false;
                return;
            }

            if (FeesVal.Equals(0))
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
               
                FeesData = (ObservableCollection<FeesModel>)obj;

                var dft = FeesData.Where(vf => vf.FeesValue.ToString() == FeesVal).Count();

                if (dft >= 0)
                {
                    var dataadd = _services.EditSave(ids,Convert.ToInt32(FeesVal));
                    if (dataadd)
                    {
                        FeesModel fe = new FeesModel();
                        getFeesData();
                        Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                        Visibility = true;
                        Message = "data berhasil disimpan";
                        FeesVal = "";
                        var cs = await delayid();
                        if (cs)
                            Visibility = false;
                    }
                    else
                    {
                        Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                        Visibility = true;
                        Message = "data gagal disimpan";
                        FeesVal = "";
                        var cs = await delayid();
                        if (cs)
                            Visibility = false;
                    }


                }
                else
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = "data sudah ada";
                    FeesVal = "";
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                }


                

            }
        }

        private void EditData(object obj)
        {
            Ednabled = true;
            savnabled = false;
            
            FeesVal = SelectedFess.FeesValue.ToString();
            Ids = SelectedFess.ParkFeesId;
          
        }

        private int ids;

        public int Ids
        {
            get { return ids; }
            set { ids = value; OnPropertyChanged("Ids"); }
        }


        private string _feesval;

        public string FeesVal
        {
            get { return _feesval; }
            set {  _feesval = value; OnPropertyChanged("FeesVal"); }
        }

        private bool _seavenable;

        public bool savnabled
        {
            get { return _seavenable; }
            set { _seavenable = value; OnPropertyChanged("savnabled"); }
        }

        private bool edenbaled;

        public bool Ednabled
        {
            get { return edenbaled; }
            set { edenbaled = value; OnPropertyChanged("Ednabled"); }
        }



        private async void AddData(object obj)
        {

            //_katmodel.KategoriHall = Katname;
            //_katmodel.katNumber = Katnumber;

            
           
            if (string.IsNullOrEmpty(FeesVal))
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

                if (!Regex.IsMatch(FeesVal, "[0-9]"))
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = " Input wajib berupa nomor ";
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                    return;
                }


                FeesData = (ObservableCollection<FeesModel>)obj;

                var cvd = FeesData.Where(cv => cv.FeesValue.ToString() == FeesVal).Count();

                Console.WriteLine(cvd);

                if (cvd < 1)
                {
                    var dataadd = _services.insertData(Convert.ToInt32(FeesVal));
                    if (dataadd)
                    {
                        FeesModel fe = new FeesModel();
                        getFeesData();
                        Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                        Visibility = true;
                        Message = "data berhasil disimpan";
                        FeesVal = "";
                        var cs = await delayid();
                        if (cs)
                            Visibility = false;
                    }
                    else
                    {
                        Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                        Visibility = true;
                        Message = "data gagal disimpan";
                        FeesVal = "";
                        var cs = await delayid();
                        if (cs)
                            Visibility = false;
                    }
                }
                else
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = "data sudah ada";
                    FeesVal = "";
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                }





            }
        }

        async Task<bool> delayid()
        {
            await Task.Delay(3000);
            return true;
        }


        private FeesModel _selectedFee;

        public FeesModel SelectedFess
        {
            get { return _selectedFee; }
            set { _selectedFee = value; OnPropertyChanged("SelectedFees"); }
        }


        public void getFeesData()
        {
            FeesData = new ObservableCollection<FeesModel>(_services.GetFees());
        }

        private ObservableCollection<FeesModel> _feesdata;

        public ObservableCollection<FeesModel> FeesData
        {
            get { return _feesdata; }
            set { _feesdata = value; OnPropertyChanged("FeesData"); }
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
