using RezerwacjeService.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RezerwacjeService
{
   
    public class UsersService : IUsersService
    {

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            return null;
        }

        public String Login(string login, string password)
        {
            return UserAuthFactory.Instance.loginUser(login, password);
        }

        List<Users> IUsersService.FindAll()
        {
            return UsersFactory.Instance.FindAll();
        }

        Users IUsersService.FindByLogin(string login)
        {
            return UsersFactory.Instance.FindByLogin(login);
        }

        bool IUsersService.isAdmin(string login)
        {
            return UsersFactory.Instance.isAdmin(login);
        }
    }
}
