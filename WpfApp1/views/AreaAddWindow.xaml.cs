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
using WpfApp1.Interface;
using WpfApp1.Models;
using WpfApp1.ViewModel.Area;

namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for areaModel.xaml
    /// </summary>
    public partial class AreaAddWindow : Window, IClosable
    {
        public AddAreaViewModels addareaviewmodel;
        public AreaAddWindow(AreaModel m_area)
        {
            InitializeComponent();
            addareaviewmodel = new AddAreaViewModels(m_area);
            DataContext = addareaviewmodel;
        }

        public void Dispose()
        {
            addareaviewmodel = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
