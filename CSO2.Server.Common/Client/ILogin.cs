using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Client
{
    public interface ILogin
    {
        public string UserName { get; }
        public string Password { get; }
    }
}
