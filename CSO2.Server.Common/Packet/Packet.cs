using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Packet
{
    public abstract class Packet : IPacket
    {
        public IByteBuffer ByteBuffer { get; set; }
        public PacketID PacketID { get; set; }

        protected Packet(PacketID packetID)
        {
            ByteBuffer = Unpooled.Buffer(1024);
            PacketID = packetID;
        }

        public abstract IPacket BuildPacket();

        public virtual IPacket? GetPacket()
        {
            if (ByteBuffer.ReadableBytes <= 0)
                return null;
            return this;
        }
    }
}
