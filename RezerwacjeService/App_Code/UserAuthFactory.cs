using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RezerwacjeService.Factory;
using System.ServiceModel;

namespace RezerwacjeService
{
    public class UserAuthFactory
    {
        private static UserAuthFactory instance;

        private UserAuthFactory() { }

        public static UserAuthFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserAuthFactory();
                }
                return instance;
            }
        }

        private Dictionary<String, Users> sessions = new Dictionary<String, Users>();

        public String loginUser(String login, String password)
        {
            Users user = UsersFactory.Instance.FindByLogin(login);
            if (user != null && user.Password.Equals(password))
            {
                String sessionId = OperationContext.Current.SessionId;
                sessions.Add(sessionId, user);
                return sessionId;
            }

            return null;
        }

        public bool logoutUser(String sessionId)
        {
            if (sessionId == null)
            {
                return true;
            }
            return sessions.Remove(sessionId);
        }

        public bool isAuth(String sessionId)
        {
            return sessions.ContainsKey(sessionId);
        }

        public Users getUser(String SessionId)
        {
            return sessions[SessionId];
        }
    }
}