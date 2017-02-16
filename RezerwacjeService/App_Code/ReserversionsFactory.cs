using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RezerwacjeService
{
    public class ReserversionsFactory
    {
        private static ReserversionsFactory instance;

        private ReserversionsFactory() { }

        public static ReserversionsFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReserversionsFactory();
                }
                return instance;
            }
        }

        /*public List<Reserversions> FindAll()
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                List<Reserversions> reserversions = dbContext.Reserversions.ToList();
                return reserversions;
            }
        }

        public Reserversions FindById(int id)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                Reserversions reserversions = (from u in dbContext.Reserversions where u.Id == id select u).FirstOrDefault();
                return reserversions;
            }
        }

        public int Save(Reserversions reserversion)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                dbContext.Entry(reserversion).State = reserversion.Id == 0 ? EntityState.Added : EntityState.Modified;
                return dbContext.SaveChanges();
            }
        }*/
    }
}