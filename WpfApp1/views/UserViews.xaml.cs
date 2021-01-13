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
using WpfApp1.ViewModel.Users;

namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for UserViews.xaml
    /// </summary>
    public partial class UserViews : Page
    {
        private UserViewModels userView;
        public UserViews()
        {
            InitializeComponent();
            userView = new UserViewModels();
            this.DataContext = userView;
        }
    }
}
