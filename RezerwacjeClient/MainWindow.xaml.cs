using RezerwacjeClient.ReserversionsServiceReference;
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
            bindRoomsComboBox();
            bindCusstomerComboBox();
            ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            ReserverionsDataGrid.ItemsSource = client.FindAll(sessionId);
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
            ReserversionWraper selectedReserversion = (ReserversionWraper)ReserverionsDataGrid.SelectedItem;

            if (selectedReserversion != null)
            {
                datePickerFrom.SelectedDate = selectedReserversion.From;
                datePickerTo.SelectedDate = selectedReserversion.To;
                comboBoxCustomer.SelectedValue = selectedReserversion.Customers.Id;
                comboBoxRoom.SelectedValue = selectedReserversion.Rooms.Id;
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            ReserversionWraper selectedReserversion = (ReserversionWraper)ReserverionsDataGrid.SelectedItem;

            selectedReserversion.From = (DateTime) datePickerFrom.SelectedDate;
            selectedReserversion.To = (DateTime) datePickerTo.SelectedDate;
            selectedReserversion.Customers = ((CustomerComboBoxWraper)comboBoxCustomer.SelectedItem).customer;
            selectedReserversion.RoomId = ((RoomsComboBoxWraper)comboBoxRoom.SelectedItem).room.Id;
            selectedReserversion.Rooms = ((RoomsComboBoxWraper)comboBoxRoom.SelectedItem).room;

            if (!Validator.Valid(selectedReserversion))
            {
                return;
            }

            /*ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            client.Save(sessionId, selectedReserversion);*/
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            ReserversionWraper newReserversion = new ReserversionWraper();

            newReserversion.From = (DateTime)datePickerFrom.SelectedDate;
            newReserversion.To = (DateTime)datePickerTo.SelectedDate;
            newReserversion.Customers = ((CustomerComboBoxWraper)comboBoxCustomer.SelectedItem).customer;
            newReserversion.RoomId = ((RoomsComboBoxWraper)comboBoxRoom.SelectedItem).room.Id;
            newReserversion.Rooms = ((RoomsComboBoxWraper)comboBoxRoom.SelectedItem).room;

            if (!Validator.Valid(newReserversion))
            {
                return;
            }

            /*ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            int savedCustomersQuantity = client.Save(sessionId, newReserversion);
            if (savedCustomersQuantity > 0)
            {
                ReserverionsDataGrid.ItemsSource = client.FindAll(sessionId);
            }*/
        }

        private void bindRoomsComboBox()
        {
            ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            comboBoxRoom.ItemsSource = client.FindAllRooms(sessionId).Select(room => new RoomsComboBoxWraper(room)).ToList();
            comboBoxRoom.SelectedValuePath = "Id";
        }

        private void bindCusstomerComboBox()
        {
            ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            comboBoxCustomer.ItemsSource = client.FindAllCustomers(sessionId).Select(customer => new CustomerComboBoxWraper(customer)).ToList();
            comboBoxCustomer.SelectedValuePath = "Id";
        }

        private class RoomsComboBoxWraper
        {

            public readonly RoomWraper room;
            public RoomsComboBoxWraper(RoomWraper room)
            {
                this.room = room;
            }

            public int Id
            {
                get
                {
                    return room.Id;
                }
            }

            public override String ToString()
            {
                return "Nr:" + room.Number + " (Łóż:" + room.BedNo + ", Łaź:" + room.BathNo + " )";
            }

        }

        private class CustomerComboBoxWraper
        {

            public readonly CustomerWraper customer;
            public CustomerComboBoxWraper(CustomerWraper customer)
            {
                this.customer = customer;
            }

            public int Id
            {
                get
                {
                    return customer.Id;
                }
            }

            public override String ToString()
            {
                return customer.FirstName + " " + customer.Surname;
                }

        }

        public class Validator
        {
            public static bool Valid(ReserversionWraper reserversion)
            {
                if (DateTime.Compare(reserversion.From, reserversion.To) > 0)
                {
                    MessageBox.Show("Data od nie może być poźniejsza od daty do");
                    return false;
                }

                ReserversionsServiceClient client = new ReserversionsServiceClient();
                String sessionId = (String)App.Current.Properties[App.sessionPropertyName]; 
                if(!client.isRoomVacant(sessionId, reserversion))
                {
                    MessageBox.Show("Pokój zajęty w tym okresie");
                    return false;
                }
                return true;
            }
        }

    }
}
