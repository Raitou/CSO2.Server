
using DotNetty.Transport.Channels;
using TCPServer.Channel.Helper;
using CSO2.Server.Common.Packet.Enum;
using CSO2.Server.Common.Utilities;
using CSO2.Server.TCPServer.Packet.Core;
using CSO2.Server.Common.Action;
using CSO2.Server.TCPServer.Actions;
using CSO2.Server.Common.Packet;

namespace TCPServer.Channel.Handler
{
    internal class ChannelHandler : SimpleChannelInboundHandler<PacketData>
    {
        private IAction? _action;
        public ChannelHandler()
        {
            // Since every connection creates a new set of its own pipeline then we shouldn't
            // really practice static here especially on a helper class so we make it an
            // object member instead
            //_channelHelper = new ChannelHelper(); // Restructured as Actions

        }

        // Initial Connection
        public override void ChannelActive(IChannelHandlerContext context)
        {
            new OnClientConnect(context, new PacketData(new byte[] {0})).Execute();
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, PacketData msg)
        {
            try
            {
                switch (msg.PacketID)
                {
                    case PacketID.VersionInfo:
                        {
                            _action = new OnVersionInfo(ctx, msg);
                        }
                        break;

                    case PacketID.Login:
                        {
                            _action = new OnLogin(ctx, msg);
                        }
                        break;

                    default:
                        {
                            //if packet not found
                            Console.WriteLine(msg.PacketID + ": " + ByteUtil.ByteArrToString(msg.RawData));
                        }
                        break;
                }

                if(_action != null)
                {
                    _action.Execute();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _action = null;
            }
        }
    }
}
