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
        public static Func<Rooms, RoomWraper> convert = room => new RoomWraper()
        {
            Id = room.Id,
            Number = room.Number,
            Floor = room.Floor,
            BedNo = room.BedNo,
            BathNo = room.BathNo
        };

        public static Func<RoomWraper, Rooms> reconvert = roomWraper => new Rooms()
        {
            Id = roomWraper.Id,
            Number = roomWraper.Number,
            Floor = roomWraper.Floor,
            BedNo = roomWraper.BedNo,
            BathNo = roomWraper.BathNo
        };

        public List<RoomWraper> FindAll(string sessionId)
        {
            List<Rooms> roomsEntities = RoomsFactory.Instance.FindAll();
            return roomsEntities.Select(convert).ToList();
        }

        public RoomWraper FindById(string sessionId, int id)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return null;
            }
            Rooms roomEntity = RoomsFactory.Instance.FindById(id);
            return convert(roomEntity);
        }

        public int Save(string sessionId, RoomWraper room)
        {
            if (!UserAuthFactory.Instance.isAuth(sessionId))
            {
                return 0;
            }
            Rooms roomEntity = reconvert(room);
            return RoomsFactory.Instance.Save(roomEntity);
        }
    }
}
