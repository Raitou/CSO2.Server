using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Action
{
    public abstract class Action : IAction
    {
        public abstract void Setup(); // TODO: Inject DBContext
        public abstract void Execute();
        
    }
}
