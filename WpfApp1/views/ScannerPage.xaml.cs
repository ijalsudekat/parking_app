using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using WpfApp1.ViewModel.Scanner;
using WpfApp1.Interface;
using WpfApp1.Models;

namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for ScannerPage.xaml
    /// </summary>
    public partial class ScannerPage : Window, IClosable
    {
        public GenerateViewModel generateViewModel;
        public ScannerPage(ScannerModel scanmodel)
        {
            InitializeComponent();
            if (scanmodel != null)
                generateViewModel = new GenerateViewModel(scanmodel);
            DataContext = generateViewModel;
        }

        public void Dispose()
        {
            generateViewModel = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
