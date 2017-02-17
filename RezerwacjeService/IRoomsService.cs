using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    [ServiceContract]
    public interface IRoomsService
    {
        [OperationContract]
        List<RoomWraper> FindAll(String sessionId);

        [OperationContract]
        RoomWraper FindById(String sessionId, int id);

        [OperationContract]
        int Save(String sessionId, RoomWraper room);
    }

    [DataContract]
    public class RoomWraper
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public int Floor { get; set; }
        [DataMember]
        public int BedNo { get; set; }
        [DataMember]
        public int BathNo { get; set; }

    }
}
