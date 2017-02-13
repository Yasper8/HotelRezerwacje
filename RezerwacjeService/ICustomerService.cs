using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customers> FindAll(String sessionId);

        [OperationContract]
        Customers FindById(String sessionId, int id);

        [OperationContract]
        int Save(String sessionId, Customers customer);
    }
}
