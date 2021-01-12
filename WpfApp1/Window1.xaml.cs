using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.views;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ScannerMgm scm;
        public Window1(ScannerMgm c)
        {
            InitializeComponent();
            scm = c;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (scm != null)
            {
                scm.appluRangeFilter( Convert.ToInt32(tb1.Text), Convert.ToInt32(tb2.Text));
            }
        }
    }
}
