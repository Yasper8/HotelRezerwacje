using RezerwacjeClient.CustomerServiceReference;
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

    public partial class Customer : Window
    {

        public Customer()
        {
            InitializeComponent();
            CustomerServiceClient client = new CustomerServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            CustomersDataGrid.ItemsSource = client.FindAll(sessionId);
        }

        private void CustomersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerWraper selectedCustomer = (CustomerWraper)CustomersDataGrid.SelectedItem;

            if (selectedCustomer != null)
            {
                textBoxFirstname.Text = selectedCustomer.FirstName;
                textBoxSurname.Text = selectedCustomer.Surname;
                textBoxTelephone.Text = selectedCustomer.Telephone;
                textBoxEmail.Text = selectedCustomer.Email;
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            CustomerWraper customer = (CustomerWraper)CustomersDataGrid.SelectedItem;

            customer.FirstName = textBoxFirstname.Text;
            customer.Surname = textBoxSurname.Text;
            customer.Telephone = textBoxTelephone.Text;
            customer.Email = textBoxEmail.Text;

            CustomerServiceClient client = new CustomerServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            client.Save(sessionId, customer);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            CustomerWraper customer = new CustomerWraper();
            customer.FirstName = textBoxFirstname.Text;
            customer.Surname = textBoxSurname.Text;
            customer.Telephone = textBoxTelephone.Text;
            customer.Email = textBoxEmail.Text;

            CustomerServiceClient client = new CustomerServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            int savedCustomersQuantity = client.Save(sessionId, customer);
            if(savedCustomersQuantity == 1)
            {
                CustomersDataGrid.ItemsSource = client.FindAll(sessionId);
            }

        }
    }
}
