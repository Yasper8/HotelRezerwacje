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
            reserversionEntity.Users = UserAuthFactory.Instance.getUser(sessionId);
            return ReserversionsFactory.Instance.Save(reserversionEntity);
        }

        public List<RoomWraper> FindAllRooms(string sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            List<Rooms> roomsEntities = RoomsFactory.Instance.FindAll();
            return roomsEntities.Select(RoomsService.convert).ToList();
        }

        public List<CustomerWraper> FindAllCustomers(string sessionId)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            List<Customers> customersEntites = CustomerFactory.Instance.FindAll();
            return customersEntites.Select(CustomerService.convert).ToList();
        }

        public bool isRoomVacant(string sessionId, ReserversionWraper reserversions)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return false;
            }
            Reserversions reserversionEntity = reconvert(reserversions);
            return RoomsFactory.Instance.IsRoomVacant(reserversionEntity);
        }
    }
}
