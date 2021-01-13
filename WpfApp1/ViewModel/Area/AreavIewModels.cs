using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Interface;
using WpfApp1.Models;
using WpfApp1.Services;
using WpfApp1.views;


namespace WpfApp1.ViewModel.Area
{
    public class AreavIewModels : INotifyPropertyChanged
    {
        #region constructor
        AreaModel _aream = new AreaModel();
        AreaServices _services = new AreaServices();
        FeesServices _feeservices = new FeesServices();
        KategoriServices _katservice = new KategoriServices();
        public AreavIewModels()
        {
            getdata();
            LoadFees();
            LoadKategori();
        }
        #endregion

        #region notifikasi
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
        #endregion

        #region showdata

        private AreaModel selectArea;

        public AreaModel SelectArea
        {
            get { return selectArea; }
            set { selectArea = value; OnPropertyChanged("SelectArea"); }
        }

        private ObservableCollection<AreaModel> areasData;
        public ObservableCollection<AreaModel> AreaData
        {
            get { return areasData; }
            set { areasData = value; OnPropertyChanged("AreaData"); }
        }

        private void getdata()
        {
            AreaData = new ObservableCollection<AreaModel>(_services.GetAll());
        }
        #endregion

        #region editdata

        private ICommand editAreaCommand;

        public ICommand EditAreaCommand
        {
            get
            {
                if (editAreaCommand == null)
                    editAreaCommand = new RelayCommand(Edit);
                return editAreaCommand;

            }

        }
        AreaEditWindow EditWindow;
        private void Edit()
        {

           
            if (EditWindow == null)
            {
                LoadFees();
                LoadKategori();
                EditWindow = new AreaEditWindow(SelectArea);
                EditWindow.EditAreaViewModels.AreaEdit += EditAreaViewModelSaved;
                EditWindow.Closing += EditAreaWindowClosing;
                EditWindow.Show();


            }

            else
            {

                EditWindow.Focus();

            }


        }

        private void EditAreaWindowClosing(object sender, CancelEventArgs e)
        {
            EditWindow.Dispose();
            EditWindow = null;
        }

        private void EditAreaViewModelSaved(object sender, EventArgs e)
        {
            EditWindow.Close();


        }

        #endregion

        #region savedata
        private ICommand addDataCommand;
        public ICommand AddDataCommand
        {
            get
            {
                if (addDataCommand == null)
                    addDataCommand = new RelayCommand(SaveArea);
                return addDataCommand;
            }

        }

        AreaAddWindow window;

        private void SaveArea()
        {
            
            if (window == null)
            {

                AreaModel aream = new AreaModel();
                window = new AreaAddWindow(aream);
                window.addareaviewmodel.AreadeSave += AddAreaDataWindow;
                window.Closing += AddAreaWindowClosing;
                window.Show();
            }
            else
            {
                window.Focus();
            }
        }

        private void AddAreaDataWindow(object sender, EventArgs e)
        {
            window.Close();
            AreaData.Add((AreaModel)sender);
        }

        private void AddAreaWindowClosing(object sender, EventArgs e)
        {
            window.Dispose();
            window = null;
        }

        private List<FeesModel> feesModel;
        public List<FeesModel> FeesModels
        {
            get { return feesModel; }
            set { feesModel = value; OnPropertyChanged("FeesModels"); }
        }

        public void LoadFees()
        {
            FeesModels = new List<FeesModel>(_feeservices.GetFees());
           
        }

        private SelectedFeesModel _selectedFees;
        public SelectedFeesModel SelectedFees
        {
            get { return _selectedFees; }
            set
            {
                _selectedFees = value;
                OnPropertyChanged(nameof(SelectedFees));
            }

        }

    
       
        private IEnumerable<KategoriModels> kategoris;
        public IEnumerable<KategoriModels> Kategoris
        {
            get { return kategoris; }
            set { kategoris = value; OnPropertyChanged("kategoris"); }
        }
        public void LoadKategori()
        {
            Kategoris = new List<KategoriModels>(_katservice.GetAll());
        }
        #endregion

        #region deletedata
        private ICommand deleteareacommand;
        public ICommand Deleteareacommand
        {
            get
            {
                if (deleteareacommand == null)
                    deleteareacommand = new RelayCommand(DeleteArea);
                return deleteareacommand;
            }
        }

        private void DeleteArea()
        {
            var confirm = MessageBox.Show(string.Format("this data {0} has ben deleted are you sure ?", SelectArea.AreaNumber), "Confirm", MessageBoxButtons.YesNo);
           
            if (confirm == DialogResult.Yes)
            {
                var data = _services.Delete(SelectArea.AreaId);
                if (data)
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                    Visibility = true;
                    Message = "Delete Data successfull";
                    
                }
                else
                {
                    Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                    Visibility = true;
                    Message = "Delete data failed";
                }
            }
        }


        #endregion

        #region property
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


        //#endregion
      
        //#region delet

        //private AreaModel currentDelete;

        //public AreaModel CurrentDelete
        //{
        //    get { return currentDelete; }
        //    set { currentDelete = value; OnPropertyChanged("CurrentDelete"); }
        //}

        

        //private ownCommand.RelayCommand deleteCommand;

        //public ownCommand.RelayCommand DeleteCommand
        //{
        //    get { return deleteCommand; }
        //}

        //public void Deleted(object id)
        //{

        //    var confirm = MessageBox.Show(string.Format("this data {0} has ben deleted are you sure ?", CurrentDelete.AreaNumber), "Confirm", MessageBoxButtons.YesNo);

        //    if (confirm == DialogResult.Yes)
        //    {
        //        var data = _services.Delete((int)id);
        //        if (data)
        //        {
        //            Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
        //            Visibility = true;
        //            Message = "Delete Data successfull";
        //            LoadData();

        //        }
        //        else
        //        {
        //            Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
        //            Visibility = true;
        //            Message = "Delete data failed";
        //        }
        //    }

        //}

        //#endregion
        //#region edit
        //private ownCommand.RelayCommand getIdCommand;

        //public ownCommand.RelayCommand GetIdCommand
        //{
        //    get { return getIdCommand; }
        //}

        //public RelayCommand<IClosable> EditCommand
        //{
        //    get;
        //    private set;
        //}

        //private AreaModel areabyid;
        //public AreaModel Areabyid
        //{
        //    get { return areabyid; }
        //    set { areabyid = value; OnPropertyChanged("Areabyid"); }
        //}



        //public void GetById(object id)
        //{
        //    int ids = (int)id;
        //    Areabyid =_services.getById(ids);
        //    Console.WriteLine(CurrentArea.AreaNumber);
        //    if (!String.IsNullOrEmpty(Areabyid.AreaId.ToString()))
        //    {

        //        //CurrentArea = Areabyid;
        //        AreaEditModal edited = new AreaEditModal();
        //        edited.Show();
        //    }
        //}

        //public async void Edit(IClosable window)
        //{
        //    var id = currentDelete.AreaId;
        //    if (String.IsNullOrEmpty(CurrentArea.AreaNumber.ToString())
        //        || String.IsNullOrEmpty(CurrentArea.KategoriId.ToString())
        //        || String.IsNullOrEmpty(CurrentArea.FessId.ToString())
        //        )
        //    {
        //        Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
        //        Visibility = true;
        //        Message = "Edit data failed";

        //    }
        //    else
        //    {
        //        Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
        //        Visibility = true;
        //        Message = "Area saved";
        //        var cs = await delayid();
        //        if (cs)
        //        {
        //            window.Close();
        //        }
        //    }
        //}

        //#endregion
        //#region save
        //private AreaModel _areacurrent;
        //public AreaModel CurrentArea
        //{
        //    get { return _areacurrent; }
        //    set { _areacurrent = value; OnPropertyChanged("CurrentArea"); }
        //}

        //public RelayCommand<IClosable> SaveCommand
        //{
        //    get;
        //    private set;
        //}




        //public async void Save(IClosable window)
        //{

        //    var canceakationTokenS = new CancellationTokenSource();
        //    var calcToken = canceakationTokenS.Token;


        //    if (String.IsNullOrEmpty(CurrentArea.AreaNumber.ToString()) 
        //        || String.IsNullOrEmpty(CurrentArea.KategoriId.ToString()) 
        //        || String.IsNullOrEmpty(CurrentArea.FessId.ToString())
        //        )
        //    {
        //        Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
        //        Visibility = true;
        //        Message = "Save data failed";
        //    }
        //    else
        //    {

        //        var saving = _services.SaveData(CurrentArea);
        //        if (saving)
        //        {

        //            Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
        //            Visibility = true;
        //            Message = "Area saved";
        //            AreasList.Add(CurrentArea);
        //            var cs = await delayid();
        //            if (cs)
        //            {
        //                window.Close();
        //            }
        //        }
        //        else
        //        {
        //            Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
        //            Visibility = true;
        //            Message = "Save data failed";
        //        }

        //    }

        //}


        //#endregion
        //#region porperty notify
        //public event PropertyChangedEventHandler PropertyChanged;


        //private void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        //#endregion
        //#region area data
        //private ObservableCollection<AreaModel> areas;
        //public ObservableCollection<AreaModel> AreasList
        //{
        //    get { return areas; }
        //    set
        //    {
        //        areas = value;
        //        OnPropertyChanged("AreasList");
        //    }
        //}

        //private void LoadData()
        //{
        //    AreasList = new ObservableCollection<AreaModel>(_services.GetAll());
        //}
        //#endregion
        //#region data kategori
        //private IEnumerable<KategoriModels> kategoris;
        //public IEnumerable<KategoriModels> Kategoris
        //{
        //    get { return kategoris; }
        //    set { kategoris = value; OnPropertyChanged("kategoris"); }
        //}
        //public void LoadKategori()
        //{
        //    Kategoris = new List<KategoriModels>(_katservice.GetAll());
        //}
        //#endregion
        //#region data fees
        //private IEnumerable<FeesModel> feesModel;
        //private object areasVi;
        //private AreaViews _areaViews;

        //public IEnumerable<FeesModel> FeesModels
        //{
        //    get { return feesModel; }
        //    set { feesModel = value; OnPropertyChanged("feesModel"); }
        //}
        //public void LoadFees()
        //{
        //    FeesModels = new List<FeesModel>(_feeservices.GetFees());
        //}
        //#endregion
    }
}
