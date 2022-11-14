using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.TCPServer.Channel.Helper
{
    public class LoginHelper
    {

        public bool ValidateLogin(String username, String password)
        {
            // temporary, TODO: Use CSO2.Databaase
            return username == password;
        }
    }
}
