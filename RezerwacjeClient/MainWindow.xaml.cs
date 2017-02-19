using RezerwacjeClient.AuthServiceReference;
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
            bindRoomsComboBox();
            bindCusstomerComboBox();
            ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            ReserverionsDataGrid.ItemsSource = client.FindAll(sessionId);

            UsersServiceClient usersClient = new UsersServiceClient();
            String login = (String)App.Current.Properties[App.loginPropertyName];
            if (usersClient.isAdmin(sessionId, login))
            {
                MenuStaff.Visibility = Visibility.Visible;
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AuthServiceClient authClient = new AuthServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            if (authClient.Logout(sessionId))
            {
                App.Current.Properties[App.sessionPropertyName] = null;
                App.Current.Properties[App.loginPropertyName] = null;
            }
        }

        private void MenuLogout_Click(object sender, RoutedEventArgs e)
        {
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

        private void MenuStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff staffWindow = new Staff();
            staffWindow.Show();
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

            ReserversionWraper newReserversion = new ReserversionWraper();
            newReserversion.Id = selectedReserversion.Id;
            FillAndSave(newReserversion);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            ReserversionWraper newReserversion = new ReserversionWraper();
            FillAndSave(newReserversion);

        }

        private void FillAndSave(ReserversionWraper reserversion)
        {
            reserversion.From = (DateTime)datePickerFrom.SelectedDate;
            reserversion.To = (DateTime)datePickerTo.SelectedDate;
            reserversion.Customers = ((CustomerComboBoxWraper)comboBoxCustomer.SelectedItem).customer;
            reserversion.RoomId = ((RoomsComboBoxWraper)comboBoxRoom.SelectedItem).room.Id;
            reserversion.Rooms = ((RoomsComboBoxWraper)comboBoxRoom.SelectedItem).room;

            if (!Validator.Valid(reserversion))
            {
                return;
            }

            ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            int savedCustomersQuantity = client.Save(sessionId, reserversion);
            if (savedCustomersQuantity > 0)
            {
                ReserverionsDataGrid.ItemsSource = client.FindAll(sessionId);
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            ReserverionsDataGrid.ItemsSource = client.FindAll(sessionId);

            int selectedRoom = (int)comboBoxRoom.SelectedValue;
            comboBoxRoom.ItemsSource = client.FindAllRooms(sessionId).Select(room => new RoomsComboBoxWraper(room)).ToList();
            comboBoxRoom.SelectedValue = selectedRoom;

            int selectedCustomer = (int)comboBoxCustomer.SelectedValue;
            comboBoxCustomer.ItemsSource = client.FindAllCustomers(sessionId).Select(customer => new CustomerComboBoxWraper(customer)).ToList();
            comboBoxCustomer.SelectedValue = selectedCustomer;
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
