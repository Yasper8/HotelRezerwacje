using RezerwacjeClient.AuthServiceReference;
using RezerwacjeClient.ReserversionsServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RezerwacjeClient
{
    class AuthCallback : IAuthServiceCallback
    {
        public void notify()
        {
            ReserversionsServiceClient client = new ReserversionsServiceClient();
            String sessionId = (String)App.Current.Properties[App.sessionPropertyName];
            DataGrid reerversionsDataGrid = (DataGrid)App.Current.Properties[App.reservarsionDataGridPropertyName];
            reerversionsDataGrid.ItemsSource = client.FindAll(sessionId);
        }
    }
}
