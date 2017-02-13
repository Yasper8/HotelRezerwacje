using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RezerwacjeService
{
    public class RoomsFactory
    {
        private static RoomsFactory instance;

        private RoomsFactory() { }

        public static RoomsFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomsFactory();
                }
                return instance;
            }
        }

        public List<Rooms> FindAll()
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                List<Rooms> rooms = dbContext.Rooms.ToList();
                return rooms;
            }
        }

        public Rooms FindById(int id)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                Rooms room = (from u in dbContext.Rooms where u.Id == id select u).FirstOrDefault();
                return room;
            }
        }

        public int Save(Rooms room)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                dbContext.Entry(room).State = room.Id == 0 ? EntityState.Added : EntityState.Modified;
                return dbContext.SaveChanges();
            }
        }
    }
}