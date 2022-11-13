using CSO2.Server.Common.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.TCPServer.Packet.Helper
{
    public class LoginHelper
    {
        public void ProcessLogin()
        {

        }


        public bool ValidateLogin(ILogin login)
        {
            //Test Login
            return (login.UserName == login.Password);

            //TODO: Create Repository for User Table @ CSO2.Database
        }

    }
}
