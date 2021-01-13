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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel.Slot;

namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for ParkingSlot.xaml
    /// </summary>
    public partial class ParkingSlot : Page
    {
        private SlotViewModels _slotvm;
        public ParkingSlot()
        {
            InitializeComponent();
            _slotvm = new SlotViewModels();
            this.DataContext = _slotvm;
        }
    }
}
