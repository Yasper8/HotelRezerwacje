using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    public class ReserversionsService : IReserversionsService
    {
        /*public List<Reserversions> FindAll(string sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            return ReserversionsFactory.Instance.FindAll();
        }

        public Reserversions FindById(string sessionId, int id)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            return ReserversionsFactory.Instance.FindById(id);
        }

        public int Save(string sessionId, Reserversions reserversions)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return 0;
            }
            return ReserversionsFactory.Instance.Save(reserversions);
        }*/
    }
}
