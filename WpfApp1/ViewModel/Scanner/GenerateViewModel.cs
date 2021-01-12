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
using WpfApp1.views;

namespace WpfApp1.ViewModel.Scanner
{
    public class GenerateViewModel : INotifyPropertyChanged
    {

        private ScannerModel _imSource;

        public ScannerModel ImageSource
        {
            get { return _imSource; }
            set { _imSource = value; OnPropertyChanged("ImageSource"); }
        }

        private ICommand closedwin;

        public ICommand ClosedScanCommand
        {
            get
            {
                if (closedwin == null)
                    closedwin = new RelayCommand(closedWin);
                return closedwin;
            }
        }
        ScannerPage winscan;

        public void closedWin()
        {
            winscan.Close();
        }


        public GenerateViewModel(ScannerModel scanner)
        {
            ImageSource = scanner;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler scaneropen;

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
