using RezerwacjeClient.RoomsServiceReference;
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
    /// Interaction logic for Room.xaml
    /// </summary>
    public partial class Room : Window
    {
        public Room()
        {
            InitializeComponent();
            InitializeComponent();
            RoomsServiceClient client = new RoomsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            CustomersDataGrid.ItemsSource = client.FindAll(sessionId);
        }

        private void CustomersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rooms selectedRoom = (Rooms)CustomersDataGrid.SelectedItem;

            if (selectedRoom != null)
            {
                textBoxNumber.Text = selectedRoom.Number.ToString();
                textBoxFloor.Text = selectedRoom.Floor.ToString();
                textBoxBedNo.Text = selectedRoom.BedNo.ToString();
                textBoxBathNo.Text = selectedRoom.BathNo.ToString();
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Rooms room = (Rooms)CustomersDataGrid.SelectedItem;

            room.Number = Int32.Parse(textBoxNumber.Text);
            room.Floor = Int32.Parse(textBoxFloor.Text);
            room.BedNo = Int32.Parse(textBoxBedNo.Text);
            room.BathNo = Int32.Parse(textBoxBathNo.Text);

           RoomsServiceClient client = new RoomsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            client.Save(sessionId, room);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Rooms room = new Rooms();
            room.Number = Int32.Parse(textBoxNumber.Text);
            room.Floor = Int32.Parse(textBoxFloor.Text);
            room.BedNo = Int32.Parse(textBoxBedNo.Text);
            room.BathNo = Int32.Parse(textBoxBathNo.Text);

            RoomsServiceClient client = new RoomsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            int savedCustomersQuantity = client.Save(sessionId, room);
            if (savedCustomersQuantity == 1)
            {
                CustomersDataGrid.ItemsSource = client.FindAll(sessionId);
            }

        }
    }
}
