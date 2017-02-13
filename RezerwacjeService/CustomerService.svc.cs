using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        List<Customers> ICustomerService.FindAll(string sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            return CustomerFactory.Instance.FindAll();
        }

        public Customers FindById(string sessionId, int id)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            return CustomerFactory.Instance.FindById(id);
        }

        public int Save(string sessionId, Customers customer)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return 0;
            }
            return CustomerFactory.Instance.Save(customer);
        }
    }
}
