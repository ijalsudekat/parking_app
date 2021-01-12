using System;
using System.Drawing;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using Emgu.CV;
using Emgu.CV.Structure;




using IronOcr;
using Emgu.CV.Util;
using Emgu.Util;
using WpfApp1;
using WpfApp1.converters;
using Application = System.Windows.Forms.Application;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using WpfApp1.ViewModel.Scanner;
using Newtonsoft.Json;

namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for ScannerMgm.xaml
    /// </summary>
    public partial class ScannerMgm : Page
    {
       
        Image<Bgr, byte> imgInput;
        Image<Gray, byte> binaris;
        private string filedirs;
        ScannerViewModel sacnnervm;


        public ScannerMgm()
        {
            InitializeComponent();
            sacnnervm = new ScannerViewModel();
            DataContext = sacnnervm;
        }

        private void GridopenScann_window(object sender, MouseButtonEventArgs e)
        {
           
        }


        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //OpenFileDialog opf = new OpenFileDialog();
            //if (opf.ShowDialog() == DialogResult.OK)
            //{
            //    imgInput = new Image<Bgr, byte>(opf.FileName);
            //    pictureBox1.Image = imgInput.ToBitmap();
            //}
            
            //callApi(opf);
         
        }

     

      
        
        public void plate_recognize()
        {
          
            //Bitmap mastImg = new Bitmap(pictureBox2.Image);
            //Image<Bgr, byte> imgBit = mastImg.ToImage<Bgr, byte>();
            


            //Mat hsv = new Mat();

            //CvInvoke.CvtColor(imgBit, hsv, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);
            //Mat[] channels = hsv.Split();
              
            //RangeF H = channels[0].GetValueRange();
            //RangeF S = channels[1].GetValueRange();
            //RangeF V = channels[2].GetValueRange();

            //Console.WriteLine(string.Format("Max S {0} Min S {1}", S.Max, S.Min));
            //Console.WriteLine(string.Format("Max V {0} Min V {1}", V.Max, V.Min));
            //Console.WriteLine(string.Format("Max H {0} Min H {1}", H.Max, H.Min));
           

            //MCvScalar mean = CvInvoke.Mean(hsv);

            //Console.WriteLine(string.Format("Mean V {0} Mean S {1} Mean V {2} ", mean.V0, mean.V1, mean.V2)); ;
            //var chanel1 = channels[1].Rows;

            //binaris = channels[1].ToImage<Gray, byte>();

            //if (V.Max > 200 && S.Max > 200 && H.Max > 150 && V.Min < 50 && S.Min < 50 && H.Min < 100 )
            //{
              
             
            //    binaris._ThresholdBinaryInv(new Gray(153), new Gray(255));
            //    binaris._SmoothGaussian(5);
            //    binaris._ThresholdBinary(new Gray(164), new Gray(255));
            //}
            //else if (V.Max < 198 && S.Max < 200 && H.Max < 200 )
            //{
              

            //    binaris._ThresholdBinary(new Gray(20), new Gray(255));


            //    //imgae background
            //    //imgGray = channels[0].ToImage<Gray, byte>();
            //    //imgGray._SmoothGaussian(3);
            //    //imgGray._ThresholdBinary(new Gray(10), new Gray(255));

            //    //thresholdvalue = 120;
            //    //binaris = imgBit.Convert<Gray, byte>().ThresholdBinaryInv(new Gray(thresholdvalue), new Gray(255));
            //}
            //else
            //{
               
            //    binaris._ThresholdBinary(new Gray(40), new Gray(255));
            //}


            //var Ocr = new IronTesseract();
            //using (var Input = new OcrInput(binaris.ToBitmap()))
            //{
            //    //Input.Deskew();
            //     // only use if accuracy <97%
            //    var Result = Ocr.Read(Input);
              
            //}

            //CvInvoke.Imshow("S 3", binaris);
            
                    
        }

        public static T DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }



        public void appluRangeFilter(int aa,int bb)
        {
           

        }

        public void pictclicked(object sender, EventArgs e)
        {
            Window1 ove = new Window1(this);

            ove.Show();
        }

        private static string GenerateNewRandom()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateNewRandom();
            }
            return r;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //var plain = Encoding.UTF8.GetBytes(Convert.ToString(GenerateNewRandom()) + Convert.ToString(licenseP.Text));
            //var qrcode = licenseP.Text;
            //var username = "Parker#" + GenerateNewRandom();
            //var password = Convert.ToBase64String(plain);

           
        }
    }
}
