using CSO2.Server.Common.Packet.Enum;

namespace CSO2.Server.Common.Packet
{
    public class PacketData
    {
        public byte[] RawData { get; }
        public PacketData(byte[] rawData)
        {
            RawData = rawData;
            PacketID = (PacketID)RawData[0];
            RawData = RawData.Skip(1).ToArray();
        }
        public PacketID PacketID { get; set; }
    }
}
