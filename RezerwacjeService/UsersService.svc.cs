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

        List<Users> IUsersService.FindAll(String sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            return UsersFactory.Instance.FindAll();
        }

        Users IUsersService.FindByLogin(String sessionId, String login)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            return UsersFactory.Instance.FindByLogin(login);
        }

        bool IUsersService.isAdmin(String sessionId, String login)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return false;
            }
            return UsersFactory.Instance.isAdmin(login);
        }
    }
}
