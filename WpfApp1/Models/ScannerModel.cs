using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.Models
{
    public class ScannerModel
    {
        private ImageSource imageori;

        public ImageSource ImageOri
        {
            get { return imageori; }
            set { imageori = value; }
        }


        private string _license;
        public string License_number
        {
            get { return _license; }
            set { _license = value; }
        }

        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }

        private int feevalue;

        public int FeesValue
        {
            get { return feevalue; }
            set { feevalue = value; }
        }

        private int areaNumber;

        public int Areanumber
        {
            get { return areaNumber; }
            set { areaNumber = value; }
        }

        private string kodep;

        public string Kodeparkir
        {
            get { return kodep; }
            set { kodep = value; }
        }


        private string areaKatName;

        public string AreaKatName
        {
            get { return areaKatName; }
            set { areaKatName = value; }
        }


    }
}
