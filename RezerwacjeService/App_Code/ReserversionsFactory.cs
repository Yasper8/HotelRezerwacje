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

        public List<Reserversions> FindAll()
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                List<Reserversions> reserversions = getWithDependences(dbContext).ToList();
                return reserversions;
            }
        }

        public Reserversions FindById(int id)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                Reserversions reserversions = (from u in getWithDependences(dbContext) where u.Id == id select u).FirstOrDefault();
                return reserversions;
            }
        }

        public int Save(Reserversions reserversion)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                Reserversions toSave = getEntityToSave(dbContext, reserversion);
                toSave.From = reserversion.From;
                toSave.To = reserversion.To;
                toSave.Rooms = dbContext.Rooms.Single(r => r.Id == reserversion.Rooms.Id);
                toSave.Customers = dbContext.Customers.Single(c => c.Id == reserversion.Customers.Id);
                toSave.Users = dbContext.Users.Single(u => u.Id == reserversion.Users.Id);

                dbContext.Entry(toSave).State = toSave.Id == 0 ? EntityState.Added : EntityState.Modified;
                return dbContext.SaveChanges();
            }
        }

        private Reserversions getEntityToSave(RezerwacjeDatabaseEntities dbContext, Reserversions reserversion)
        {
            if(reserversion.Id == 0)
            {
                return reserversion;
            }
            
            return dbContext.Reserversions.Single(r => r.Id == reserversion.Id);
        }

        private IQueryable<Reserversions> getWithDependences(RezerwacjeDatabaseEntities dbContext)
        {
            return dbContext.Reserversions.Include(r => r.Customers).Include(r => r.Rooms).Include(r => r.Users);
        }
    }
}
   