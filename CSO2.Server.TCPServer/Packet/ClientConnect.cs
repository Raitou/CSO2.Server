using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using System.Text;
using AbstractPacket = CSO2.Server.Common.Packet.Packet;
namespace CSO2.Server.TCPServer.Packet
{
    internal class ClientConnect : AbstractPacket
    {
        public string StrMessage { get; set; }

        public ClientConnect(string strMessage) : base (PacketID.ClientConnect)
        {
            StrMessage = strMessage;
        }

        public override IPacket BuildPacket()
        {
            ByteBuffer.Clear();
            ByteBuffer.WriteString(StrMessage, Encoding.UTF8);
            return this;
        }
    }
}
