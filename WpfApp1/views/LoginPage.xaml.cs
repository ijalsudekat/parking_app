using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp1.ViewModel;

namespace WpfApp1.views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        private UserModels auth;
        AuthViewModels _auth;
        public LoginPage()
        {
            InitializeComponent();
            auth = new UserModels();
            _auth = new AuthViewModels();
           
        }

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("oh hello");
        }

       
        MainWindow MainWindow { get => Application.Current.MainWindow as MainWindow; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.email.Text;
            var passwordd = PPassword.passBox.Password;
            var cd = _auth.Login(username, passwordd);
            if (cd)
            {  
                txtAlertb.Visibility = Visibility.Visible;
                lblAlert.Content = "Login success";
                txtAlertb.Background = new SolidColorBrush(Color.FromRgb(85, 239, 196));
                Task.Delay(1000);
                MainWindow.mainFrame.Navigate(new Uri("/views/DashboardPage.xaml", UriKind.RelativeOrAbsolute));
                txtUser.email.Text = "";
                PPassword.passBox.Password = "";
            }
            else
            {
                txtAlertb.Visibility = Visibility.Visible;
                lblAlert.Content = "Username or password not match";
                txtAlertb.Background = new SolidColorBrush(Color.FromRgb(231, 76, 60));
            }

        }

       

        private void Upassword_KeyDown(object sender, KeyEventArgs e)
        {
            
           

        }
    }
}
