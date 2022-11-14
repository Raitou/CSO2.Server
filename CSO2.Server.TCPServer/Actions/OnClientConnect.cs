using CSO2.Server.Common.Action;
using CSO2.Server.Common.Packet;
using CSO2.Server.TCPServer.Packet;
using DotNetty.Transport.Channels;

namespace CSO2.Server.TCPServer.Actions
{
    public class OnClientConnect : ActionChannelCtx
    {
        public OnClientConnect(IChannelHandlerContext ctx, PacketData packetData) : base(ctx, packetData) { }

        public override void Execute()
        {
            base.Send(new ClientConnect(strMessage: "~SERVERCONNECTED\n"));
            Console.WriteLine("Client {0} is connected", ChannelHandlerContext.Channel.RemoteAddress);
        }
    }
}
