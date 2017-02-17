using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{

    public class CustomerService : ICustomerService
    {
        public static Func<Customers, CustomerWraper> convert = customer => new CustomerWraper()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            Surname = customer.Surname,
            Telephone = customer.Telephone,
            Email = customer.Email
        };

        public static Func<CustomerWraper, Customers> reconvert = customer => new Customers()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            Surname = customer.Surname,
            Telephone = customer.Telephone,
            Email = customer.Email
        };

        List<CustomerWraper> ICustomerService.FindAll(string sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            List<Customers> customersEntites = CustomerFactory.Instance.FindAll();
            return customersEntites.Select(convert).ToList();
        }

        public CustomerWraper FindById(string sessionId, int id)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            Customers customerEntity = CustomerFactory.Instance.FindById(id);
            return convert(customerEntity);
        }

        public int Save(string sessionId, CustomerWraper customer)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return 0;
            }
            Customers customerEntity = reconvert(customer);
            return CustomerFactory.Instance.Save(customerEntity);
        }
    }
}
