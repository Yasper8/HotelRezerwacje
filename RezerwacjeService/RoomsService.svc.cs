using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    public class RoomsService : IRoomsService
    {
        public List<Rooms> FindAll(string sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            return RoomsFactory.Instance.FindAll();
        }

        public Rooms FindById(string sessionId, int id)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            return RoomsFactory.Instance.FindById(id);
        }

        public int Save(string sessionId, Rooms room)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return 0;
            }
            return RoomsFactory.Instance.Save(room);
        }
    }
}
