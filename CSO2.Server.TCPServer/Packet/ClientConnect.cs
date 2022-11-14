using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using CSO2.Server.TCPServer.Data.Map;
using DotNetty.Buffers;
using System.Text;
using AbstractPacket = CSO2.Server.Common.Packet.Packet;
namespace CSO2.Server.TCPServer.Packet
{
    public class ClientConnect : AbstractPacket
    {
        public string StrMessage { get; set; }

        public ClientConnect(string strMessage) : base (PacketID.ClientConnect, new MapClientConnect())
        {
            StrMessage = strMessage;

            DataMap.MappedData["strMessage"][MappedDataTypes.String_UTF8] = strMessage;
        }
    }
}
