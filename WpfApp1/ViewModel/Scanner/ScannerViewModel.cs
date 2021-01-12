using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Services;
using WpfApp1.Models;
using QRCoder;
using System.Drawing;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using WpfApp1.views;
using WpfApp1.helper;
using System.Windows.Forms;
using WpfApp1.converters;

namespace WpfApp1.ViewModel.Scanner
{
    public class ScannerViewModel : INotifyPropertyChanged
    {
        ScannerServices scannerServices = new ScannerServices();
        BitmapToSOurce tsc = new BitmapToSOurce();
        private GenerateQRcode generatecodeQr;
        public ScannerViewModel()
        {
            generatecodeQr = new GenerateQRcode();
        }


        #region upload image
        private ImageSource _sourceres;
        public ImageSource Sourceres
        {
            get { return _sourceres; }
            set { _sourceres = value; OnPropertyChanged("Sourceres"); }
        }

        private ICommand getImage;
        public ICommand GetImage
        {
            get
            {
                if (getImage == null)
                    getImage = new RelayCommand(getImageLicense);
                return getImage;
            }
        }

        public void getImageLicense()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var imagerImageCar = new Bitmap(dlg.FileName);
                Sourceres = tsc.BitmapToImSource(imagerImageCar);

                if (Sourceres != null)
                {
                    License = "ABG9090Y";
                    generateQr();

                }
            }


        }
        #endregion upload image

        
        private string license;
        public string License
        {
            get { return license; }
            set { license = value; OnPropertyChanged("License"); }
        }

        private ScannerModel images;
        public ScannerModel Images
        {
            get { return images; }
            set { images = value; OnPropertyChanged("Images"); }
        }

        private ICommand generateCommand;
        public ICommand GenerateCommand
        {
            get
            {
                if (generateCommand == null)
                    generateCommand = new RelayCommand(generateQr);
                return generateCommand;
            }
        }

        private string _message;

        public string Messages
        {
            get { return _message; }
            set { _message = value; }
        }

        private string _source;

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }


        ScannerPage scanerwindow;

        public void resetForm(ScannerModel scannerModel)
        {
            scanerwindow.Close();
            scanerwindow = new ScannerPage(Images);
            scanerwindow.Show();
        }

        public void generateQr()
        {
            if (Source != null || License != null )
            {
                var dataqu =  scannerServices.reqQrCode(License);
                Images = new ScannerModel {
                    ImageSource = generatecodeQr.makeQrCode(dataqu["kode_parkir"]),
                    License_number = License,
                    AreaKatName = dataqu["areaKatName"],
                    Areanumber = Convert.ToInt32(dataqu["areaNumber"]),
                    FeesValue = Convert.ToInt32(dataqu["fees"]),
                    Kodeparkir = dataqu["kode_parkir"],
                    ImageOri = Sourceres
                };
                
                if (scanerwindow == null)
                {
                    scanerwindow = new ScannerPage(Images);
                    scanerwindow.Show();
                }
                else
                {
                    resetForm(Images);
                }
            }
            else
            {
                Messages = "License manual wajib di isi";
            }
            
            //Console.WriteLine(License);
            //scannerServices.reqQrCode(License);
        }

      

        private void ScannerOpen(object sender, EventArgs e)
        {
            scanerwindow.Close();


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
