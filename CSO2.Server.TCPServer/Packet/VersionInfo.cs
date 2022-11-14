using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using CSO2.Server.TCPServer.Data.Map;
using DotNetty.Buffers;
using System.Text;
using AbstractPacket = CSO2.Server.Common.Packet.Packet;
namespace CSO2.Server.TCPServer.Packet
{
    internal class VersionInfo : AbstractPacket
    {
        private readonly string _version;
        private readonly bool _isBadhash;

        public VersionInfo(string versionHash, bool isBadHash = false) : base(PacketID.VersionInfo, new MapVersionInfo())
        {
            _version = versionHash;
            _isBadhash = isBadHash;

            DataMap.MappedData["bBadHash"][MappedDataTypes.Boolean] = isBadHash;
            DataMap.MappedData["strVersion"][MappedDataTypes.String_ASCII] = versionHash;
        }
    }
}
