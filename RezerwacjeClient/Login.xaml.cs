using RezerwacjeClient.AuthServiceReference;
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

namespace RezerwacjeClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void butLoggin_Click(object sender, RoutedEventArgs e)
        {
            String login = TBoxLogin.Text;
            String password = TBoxPass.Password;

            AuthServiceClient client = new AuthServiceClient();

            String sessionId = client.Login(login, password);
            if(sessionId != null)
            {
                App.Current.Properties[App.sessionPropertyName] = sessionId;
                App.Current.Properties[App.loginPropertyName] = login;

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                LabelErrorLogin.Visibility = Visibility.Visible;
            }

        }

        private void butExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
