﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RezerwacjeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IAuthService
    {
        [OperationContract]
        String Login(String login, String password);
        [OperationContract]
        bool Logout(String sessionId);
    }
}
