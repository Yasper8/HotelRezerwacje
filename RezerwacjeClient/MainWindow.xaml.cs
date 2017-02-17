﻿using RezerwacjeClient.CustomerServiceReference;
using RezerwacjeClient.ReserversionsServiceReference;
using RezerwacjeClient.RoomsServiceReference;
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

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bindRoomsComboBox()
        {
            RoomsServiceClient client = new RoomsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            comboBoxRoom.ItemsSource = client.FindAll(sessionId).Select(room => new RoomsComboBoxWraper(room)).ToList();
            comboBoxRoom.SelectedValuePath = "Id";
        }

        private void bindCusstomerComboBox()
        {
            CustomerServiceClient client = new CustomerServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            comboBoxCustomer.ItemsSource = client.FindAll(sessionId).Select(customer => new CustomerComboBoxWraper(customer)).ToList();
            comboBoxCustomer.SelectedValuePath = "Id";
        }

        private class RoomsComboBoxWraper
        {

            private readonly RoomsServiceReference.RoomWraper room;
            public RoomsComboBoxWraper(RoomsServiceReference.RoomWraper room)
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

            private readonly CustomerServiceReference.CustomerWraper customer;
            public CustomerComboBoxWraper(CustomerServiceReference.CustomerWraper customer)
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

    }
}
