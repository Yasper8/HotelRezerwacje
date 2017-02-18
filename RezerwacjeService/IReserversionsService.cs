using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    [ServiceContract]
    public interface IReserversionsService
    {
        [OperationContract]
        List<ReserversionWraper> FindAll(String sessionId);

        [OperationContract]
        ReserversionWraper FindById(String sessionId, int id);

        [OperationContract]
        int Save(String sessionId, ReserversionWraper reserversion);

        [OperationContract]
        List<RoomWraper> FindAllRooms(String sessionId);

        [OperationContract]
        List<CustomerWraper> FindAllCustomers(String sessionId);
    }

    [DataContract]
    public class ReserversionWraper
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime From { get; set; }
        [DataMember]
        public DateTime To { get; set; }
        [DataMember]
        public int RoomId { get; set; }
        [DataMember]
        public CustomerWraper Customers { get; set; }
        [DataMember]
        public UserWraper Users { get; set; }
        [DataMember]
        public RoomWraper Rooms { get; set; }
    }
}
