using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomsService" in both code and config file together.
    [ServiceContract]
    public interface IRoomsService
    {
        [OperationContract]
        List<Rooms> FindAll(String sessionId);

        [OperationContract]
        Rooms FindById(String sessionId, int id);

        [OperationContract]
        int Save(String sessionId, Rooms room);
    }
}
