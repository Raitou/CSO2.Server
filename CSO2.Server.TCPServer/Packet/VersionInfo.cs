using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using System.Text;
using AbstractPacket = CSO2.Server.Common.Packet.Packet;
namespace CSO2.Server.TCPServer.Packet
{
    internal class VersionInfo : AbstractPacket
    {
        private readonly string _version;
        private readonly bool _isBadhash;

        public VersionInfo(string versionHash, bool isBadHash = false) : base(PacketID.VersionInfo)
        {
            _version = versionHash;
            _isBadhash = isBadHash;
        }

        public override IPacket BuildPacket()
        {
            ByteBuffer.Clear();
            ByteBuffer.WriteByte((int)PacketID);
            ByteBuffer.WriteBoolean(_isBadhash);
            ByteBuffer.WriteString(_version, Encoding.ASCII);
            return this;
        }
    }
}
