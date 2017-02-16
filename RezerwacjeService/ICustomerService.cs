using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<CustomerWraper> FindAll(String sessionId);

        [OperationContract]
        CustomerWraper FindById(String sessionId, int id);

        [OperationContract]
        int Save(String sessionId, CustomerWraper customer);
    }

    [DataContract]
    public class CustomerWraper
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
