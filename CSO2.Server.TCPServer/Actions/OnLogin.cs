using CSO2.Server.TCPServer.Packet.Helper;
using Action = CSO2.Server.Common.Action.Action;

namespace CSO2.Server.TCPServer.Actions
{
    public class OnLogin : Action
    {
        private readonly LoginHelper _loginHelper;
        public OnLogin()
        {
            _loginHelper = new LoginHelper();
        }

        public override void Execute()
        {
            
        }

        public override void Setup()
        {
            throw new NotImplementedException();
        }
    }
}
