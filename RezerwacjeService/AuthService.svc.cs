using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    public class AuthService : IAuthService
    {
        public String Login(string login, string password)
        {
            return UserAuthFactory.Instance.loginUser(login, password);
        }

        public bool Logout(string sessionId)
        {
            return UserAuthFactory.Instance.logoutUser(sessionId);
        }
    }
}
