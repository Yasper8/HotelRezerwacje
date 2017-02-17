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
        public static Func<Reserversions, ReserversionWraper> convert = reserversion => new ReserversionWraper()
        {
            Id = reserversion.Id,
            From = reserversion.From,
            To = reserversion.To,
            Customers = CustomerService.convert(reserversion.Customers),
            Users = UsersService.convert(reserversion.Users),
            Rooms = RoomsService.convert(reserversion.Rooms)
        };
        public static Func<ReserversionWraper, Reserversions> reconvert = reserversion => new Reserversions()
        {
            Id = reserversion.Id,
            From = reserversion.From,
            To = reserversion.To,
            Customers = CustomerService.reconvert(reserversion.Customers),
            Users = UsersService.reconvert(reserversion.Users),
            Rooms = RoomsService.reconvert(reserversion.Rooms)
        };

        public List<ReserversionWraper> FindAll(string sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            List<Reserversions> reserversionsEntities = ReserversionsFactory.Instance.FindAll();
            return reserversionsEntities.Select(convert).ToList();
        }

        public ReserversionWraper FindById(string sessionId, int id)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            Reserversions reserversionEntity = ReserversionsFactory.Instance.FindById(id);
            return convert(reserversionEntity);
        }

        public int Save(string sessionId, ReserversionWraper reserversions)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return 0;
            }
            Reserversions reserversionEntity = reconvert(reserversions);
            return ReserversionsFactory.Instance.Save(reserversionEntity);
        }
    }
}
