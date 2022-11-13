using CSO2.Server.Common.Action;
using CSO2.Server.Common.Packet;
using CSO2.Server.TCPServer.Packet;
using DotNetty.Transport.Channels;
using Action = CSO2.Server.Common.Action.Action;

namespace CSO2.Server.TCPServer.Actions
{
    internal class OnClientConnect : ActionChannelCtx
    {
        public OnClientConnect(IChannelHandlerContext ctx) : base(ctx) { }

        public override void Execute()
        {
            base.Send(new ClientConnect(strMessage: "~SERVERCONNECTED\n"));
            Console.WriteLine("Client {0} is connected", ChannelHandlerContext.Channel.RemoteAddress);
        }
    }
}
