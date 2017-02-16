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
        /*[OperationContract]
        List<Reserversions> FindAll(String sessionId);

        [OperationContract]
        Reserversions FindById(String sessionId, int id);

        [OperationContract]
        int Save(String sessionId, Reserversions reserversion);*/
    }
}
