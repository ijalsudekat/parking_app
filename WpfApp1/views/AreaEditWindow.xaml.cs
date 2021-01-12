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
using WpfApp1.Models;
using WpfApp1.ViewModel.Area;


namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for AreaEditModal.xaml
    /// </summary>
    public partial class AreaEditWindow : Window, IDisposable
    {
        public EditAreaViewModels EditAreaViewModels;
        public AreaEditWindow(AreaModel selecteditem)
        {
            InitializeComponent();
            EditAreaViewModels = new EditAreaViewModels(selecteditem);
            DataContext = EditAreaViewModels;
        }

        public void Dispose()
        {
            EditAreaViewModels = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
