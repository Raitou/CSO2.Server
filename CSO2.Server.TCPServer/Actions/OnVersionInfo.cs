using CSO2.Server.Common.Action;
using CSO2.Server.Common.Packet;
using CSO2.Server.TCPServer.Packet;
using DotNetty.Transport.Channels;

namespace CSO2.Server.TCPServer.Actions
{
    public class OnVersionInfo : ActionChannelCtx
    {
        public OnVersionInfo(IChannelHandlerContext ctx, PacketData packetData) : base(ctx, packetData) { }

        public override void Execute()
        {            
            base.Send(new VersionInfo(versionHash: "6246015df9a7d1f7311f888e7e861f18"));
        }
    }
}
