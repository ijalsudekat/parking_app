using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModel.Area
{
    public class AddAreaViewModels : INotifyPropertyChanged
    {
        private AreaModel area;
        AreaServices _services = new AreaServices();
        AreavIewModels _areavm = new AreavIewModels();
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
        public AreaModel CurrentArea
        {
            get { return area; }
            set { area = value; OnPropertyChanged("CurrentArea"); }
        }

        public AddAreaViewModels(AreaModel areas)
        {
            CurrentArea = areas;
        }

     
        private ICommand saveareaCommand;
        public ICommand SaveAreaCommand
        {
            get
            {
                if (saveareaCommand == null)
                    saveareaCommand = new RelayCommand(Save);
                return saveareaCommand;
            }
        }

        private AreaModel currentAdd;
        public AreaModel CurrentAdd
        {
            get { return currentAdd; }
            set { currentAdd = value; OnPropertyChanged("CurrentAdd"); }
        }

        public async void Save()
        {            
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
                var saving = _services.SaveData(CurrentArea);
                if (saving != null)
                {
                    
                    Coloring = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                    Visibility = true;
                    Message = "Area saved";
                    var cs = await delayid();
                    if (cs)
                    {
                        AreadeSave(saving, null);
                    }
                }
                else
                {
                   Coloring = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                   Visibility = true;
                   Message = "Save data failed";
                    var cs = await delayid();
                    if (cs)
                        Visibility = false;
                }
            }
        }
        async Task<bool> delayid()
        {
            await Task.Delay(1000);
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler AreadeSave;

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
