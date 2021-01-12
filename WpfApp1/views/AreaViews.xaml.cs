using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.ViewModel.Area;


namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for AreaViews.xaml
    /// </summary>
    public partial class AreaViews : Page
    {
        private AreavIewModels _areaModel;

        public AreaViews()
        {
            InitializeComponent();
            _areaModel = new AreavIewModels();
            this.DataContext = _areaModel;
        }

    }
}
