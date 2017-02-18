using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace RezerwacjeService.Factory
{
    public class UsersFactory
    {
        private static UsersFactory instance;

        private UsersFactory() { }

        public static UsersFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsersFactory();
                }
                return instance;
            }
        }

        public List<Users> FindAll()
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                List<Users> users = dbContext.Users.ToList();
                return users;
            }
        }

        public Users FindByLogin(string login)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                Users user = (from u in dbContext.Users where u.Login == login select u).FirstOrDefault();
                return user;
            }
        }

        public bool isAdmin(string login)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                Boolean userIsAdmin = (from u in dbContext.Users where u.Login == login && u.Type == UserType.ADMIN select u).Any();
                return userIsAdmin;
            }
        }

        public int Save(Users user)
        {
            using (var dbContext = new RezerwacjeDatabaseEntities())
            {
                dbContext.Entry(user).State = user.Id == 0 ? EntityState.Added : EntityState.Modified;
                return dbContext.SaveChanges();
            }
        }
    }
}