using RezerwacjeClient.ReserversionsServiceReference;
using RezerwacjeClient.UsersServiceReference;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            //ReserverionsDataGrid.ItemsSource = client.FindAll(sessionId);
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

        private void ReserversionsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
