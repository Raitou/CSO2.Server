using CSO2.Server.Common.Packet;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Action
{
    public abstract class Action : IAction
    {
        public abstract void Execute();    
    }

    public abstract class ActionChannelCtx : Action
    {
        public IChannelHandlerContext ChannelHandlerContext { get; protected set; }
        public PacketData PacketData { get; protected set; }

        protected ActionChannelCtx(IChannelHandlerContext ctx, PacketData packetData)
        {
            ChannelHandlerContext = ctx;
            PacketData = packetData;
        }

        protected virtual void Received(IPacket packet)
        {
            packet.SetMappedPacket(PacketData);
        }

        protected virtual void Send(IPacket packet)
        {
            IPacket? byteBuffer = packet.BuildPacket();
            if (byteBuffer == null)
                throw new Exception(String.Format("{0} packet is empty!", packet.PacketID.ToString()));
            ChannelHandlerContext.WriteAndFlushAsync(byteBuffer);

            Console.WriteLine("{0} send to {1}", packet.PacketID.ToString(), ChannelHandlerContext.Channel.RemoteAddress);
        }  
    }
}
