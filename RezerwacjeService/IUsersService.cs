using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RezerwacjeService
{
    [ServiceContract]
    public interface IUsersService
    {
        [OperationContract]
        List<UserWraper> FindAll(String sessionId);
        [OperationContract]
        UserWraper FindByLogin(String sessionId, String login);
        [OperationContract]
        bool isAdmin(String sessionID, String login);
        [OperationContract]
        int Save(String sessionId, UserWraper room);
    }

    [DataContract]
    public class UserWraper
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public UserType Type { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Surname { get; set; }
    }
}
