using RezerwacjeClient.ServiceReference1;
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

namespace RezerwacjeClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //UsersServiceClient client = new UsersServiceClient();

            //bool result = client.isAdmin("Admin");
            //Console.WriteLine("The flipped case is " + result);
            //Console.ReadLine();
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuLogout_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties[App.sessionPropertyName] = null;

            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void MenuCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer cutomerWindow = new Customer();
            cutomerWindow.Show();
        }

        private void MenuRoom_Click(object sender, RoutedEventArgs e)
        {
            Room roomWindow = new Room();
            roomWindow.Show();
        }
    }
}
