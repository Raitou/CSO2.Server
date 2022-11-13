using CSO2.Server.Common.Action;
using CSO2.Server.TCPServer.Packet.Helper;
using DotNetty.Transport.Channels;
using Action = CSO2.Server.Common.Action.Action;

namespace CSO2.Server.TCPServer.Actions
{
    public class OnLogin : ActionChannelCtx
    {
        public OnLogin(IChannelHandlerContext ctx) : base(ctx)
        { }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
