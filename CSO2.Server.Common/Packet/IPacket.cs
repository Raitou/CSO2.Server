using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;

namespace CSO2.Server.Common.Packet
{
    public interface IPacket
    {
        IByteBuffer ByteBuffer { get; }
        PacketID PacketID { get; }
        IPacket BuildPacket();
        IPacket? GetPacket();
       
    }
}
