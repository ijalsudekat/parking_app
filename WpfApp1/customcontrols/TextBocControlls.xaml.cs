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

namespace WpfApp1.customcontrols
{
    /// <summary>
    /// Interaction logic for TextBocControlls.xaml
    /// </summary>
    public partial class TextBocControlls : UserControl
    {
        public TextBocControlls()
        {
            InitializeComponent();
        }

     

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register("PlaceHolder", typeof(string), typeof(TextBocControlls));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextBocControlls));

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly DependencyProperty IsPasswordProperty = DependencyProperty.Register("IsPassword", typeof(bool), typeof(TextBocControlls));

        private void passBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            email.Text = passBox.Password;
        }

       
        public string Auth
        {
            get
            {
                return (string)GetValue(AuthProperty);
            }
            set
            {
                SetValue(AuthProperty, value);
            }
        }

        public static readonly DependencyProperty AuthProperty = DependencyProperty.Register("Auth", typeof(string), typeof(TextBocControlls));
    }
}
