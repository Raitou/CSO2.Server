using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using TCPServer.Packet.Core;

namespace TCPServer.Packet
{
    internal class Login : IPacketParser
    {
        public PacketData PacketData { get; }

        public IByteBuffer ByteBuffer { get; set; }

        public PacketID PacketID { get; }

        public Login(PacketData packetData)
        {
            PacketData = packetData;
            ByteBuffer = Unpooled.Buffer(1024);
        }

        public IPacketParser ParsePacket()
        {
            throw new NotImplementedException();
        }

        public IPacket BuildPacket()
        {
            throw new NotImplementedException();
        }

        public IPacket? GetPacket()
        {
            throw new NotImplementedException();
        }
    }
}
