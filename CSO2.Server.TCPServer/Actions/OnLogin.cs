using CSO2.Server.Common.Action;
using CSO2.Server.Common.Packet;
using CSO2.Server.TCPServer.Channel.Helper;
using CSO2.Server.TCPServer.Packet;
using DotNetty.Transport.Channels;
using Action = CSO2.Server.Common.Action.Action;

namespace CSO2.Server.TCPServer.Actions
{
    public class OnLogin : ActionChannelCtx
    {
        public OnLogin(IChannelHandlerContext ctx, PacketData packetData) : base(ctx, packetData)
        {
        }

        public override void Execute()
        {
            base.Received(new Login());
        }
    }
}
