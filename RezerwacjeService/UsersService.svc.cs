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
        public Func<Users, UserWraper> convert = user => new UserWraper()
        {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            Type = user.Type,
            Firstname = user.Firstname,
            Surname = user.Surname
        };

        List<UserWraper> IUsersService.FindAll(String sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            List<Users> usersEntitises = UsersFactory.Instance.FindAll();
            return usersEntitises.Select(convert).ToList();
        }

        UserWraper IUsersService.FindByLogin(String sessionId, String login)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            Users userEntity = UsersFactory.Instance.FindByLogin(login);
            return convert(userEntity);
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
