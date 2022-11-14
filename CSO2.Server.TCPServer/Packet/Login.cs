using CSO2.Server.Common.Data.Map;
using CSO2.Server.Common.Packet.Enum;
using CSO2.Server.TCPServer.Data.Map;
using AbstractPacket = CSO2.Server.Common.Packet.Packet;

namespace CSO2.Server.TCPServer.Packet
{
    internal class Login : AbstractPacket
    {
        public Login() : base(PacketID.Login, new MapLogin())
        { }
    }
}
