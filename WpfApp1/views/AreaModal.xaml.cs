using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for areaModel.xaml
    /// </summary>
    public partial class AreaModal : Window
    {
        private AreavIewModels _areaModel;
        
        public AreaModal(AreavIewModels areaModel)
        {
            InitializeComponent();
            _areaModel = areaModel;
            this.DataContext = _areaModel;
            _areaModel.LoadFees();
            _areaModel.LoadKategori();
            
         
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var a = String.IsNullOrEmpty(txtNum.Text) ? "Required " : "";
            var b = String.IsNullOrEmpty((string)cbFees.SelectedItem) ? "Required " : "";
            var c = String.IsNullOrEmpty((string)cbKat.SelectedItem) ? "Required" : "";
            
            txtAlert.Content = a;
            txtCbk.Content = b;
            txtCbf.Content = c;
        }

        private void txtNum_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Label lb = (Label)FindName(tb.Tag.ToString());
            DateTime endRunAt = DateTime.Now.AddSeconds(3);

            if (Regex.IsMatch(e.Key.ToString(), "^[a-zA-Z]"))
            {
                lb.Content = "Input must be a number ";
            }

            
        }

       

    }
}
