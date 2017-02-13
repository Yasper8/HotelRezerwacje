using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RezerwacjeService
{
    public class CustomerFactory
    {
        private static CustomerFactory instance;

        private CustomerFactory() { }

        public static CustomerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerFactory();
                }
                return instance;
            }
        }

        public List<Customers> FindAll()
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                List<Customers> users = dbContext.Customers.ToList();
                return users;
            }
        }

        public Customers FindById(int id)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                Customers user = (from u in dbContext.Customers where u.Id == id select u).FirstOrDefault();
                return user;
            }
        }

        public int Save(Customers customer)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                dbContext.Entry(customer).State = customer.Id == 0 ? EntityState.Added : EntityState.Modified;
                return dbContext.SaveChanges();
            }
        }
    }
}