﻿using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using System.Text;

namespace CSO2.Server.TCPServer.Packet
{
    internal class VersionInfo : IPacket
    {
        public string _version;
        private bool _isBadhash = false;
        public IByteBuffer ByteBuffer { get; set; }
        public PacketID PacketID { get; }

        public VersionInfo(string versionHash, bool isBadHash = false)
        {
            _version = versionHash;
            _isBadhash = isBadHash;
            ByteBuffer = Unpooled.Buffer(1024);
            PacketID = PacketID.VersionInfo;
        }

        public IPacket BuildPacket()
        {
            ByteBuffer.Clear();
            ByteBuffer.WriteByte((int)PacketID);
            ByteBuffer.WriteBoolean(_isBadhash);
            ByteBuffer.WriteString(_version, Encoding.ASCII);
            return this;
        }

        public IPacket? GetPacket()
        {
            if (ByteBuffer.ReadableBytes <= 0)
                return null;
            return this;
        }
    }
}
