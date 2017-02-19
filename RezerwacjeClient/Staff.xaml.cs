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
using System.Windows.Shapes;

namespace RezerwacjeClient
{
    public partial class Staff : Window
    {
        public Staff()
        {
            InitializeComponent();
            ComboBoxType.ItemsSource = Enum.GetValues(typeof(UserType)).Cast<UserType>();

            UsersServiceClient client = new UsersServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            StaffDataGrid.ItemsSource = client.FindAll(sessionId);
        }

        private void StaffGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserWraper selectedUser = (UserWraper)StaffDataGrid.SelectedItem;

            if (selectedUser != null)
            {
                textBoxLogin.Text = selectedUser.Login;
                textBoxFirstname.Text = selectedUser.Firstname;
                textBoxSurname.Text = selectedUser.Surname;
                ComboBoxType.SelectedItem = selectedUser.Type;
                textBoxPass.Password = selectedUser.Password;
                textBoxPassConfirm.Password = selectedUser.Password;
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UserWraper selectedUser = (UserWraper)StaffDataGrid.SelectedItem;

            String password = textBoxPass.Password;
            String passwordConfirm = textBoxPassConfirm.Password;
            if (!Validator.ValidPassword(password, passwordConfirm)){
                return;
            }

            selectedUser.Login = textBoxLogin.Text;
            selectedUser.Password = password;
            selectedUser.Firstname = textBoxFirstname.Text;
            selectedUser.Surname = textBoxSurname.Text;
            selectedUser.Type = (UserType) ComboBoxType.SelectedItem;

            UsersServiceClient client = new UsersServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            client.Save(sessionId, selectedUser);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            UserWraper newUser = new UserWraper();

            String password = textBoxPass.Password;
            String passwordConfirm = textBoxPassConfirm.Password;
            if (!Validator.ValidPassword(password, passwordConfirm))
            {
                return;
            }

            newUser.Login = textBoxLogin.Text;
            newUser.Password = password;
            newUser.Firstname = textBoxFirstname.Text;
            newUser.Surname = textBoxSurname.Text;
            newUser.Type = (UserType)ComboBoxType.SelectedItem;

            UsersServiceClient client = new UsersServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            int savedQuantity = client.Save(sessionId, newUser);
            if (savedQuantity > 0)
            {
                StaffDataGrid.ItemsSource = client.FindAll(sessionId);
            }

        }
    }

    public class Validator
    {
        public static bool ValidPassword(String password, String passwordConfirm)
        {
            if(!Object.Equals(password, passwordConfirm))
            {
                MessageBox.Show("Hasła muszą się zgadzać");
                return false;
            }

            return true;
        }
    }
}
