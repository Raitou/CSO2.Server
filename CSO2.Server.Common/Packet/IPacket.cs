using CSO2.Server.Common.Data.Map;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using DotNetty.Codecs.Mqtt.Packets;

namespace CSO2.Server.Common.Packet
{
    public interface IPacket
    {
        IByteBuffer ByteBuffer { get; }
        PacketID PacketID { get; }
        IDataMap DataMap { get; }

        IPacket BuildPacket();
        IPacket? GetBuiltPacket();

    }
}
