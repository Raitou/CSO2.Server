﻿using Common.Packet;
using DotNetty.Buffers;
using System.Text;

namespace TCPServer.Packet.Info
{
    internal class ServerConnected : IPacket
    {
        public String StrMessage { get; set; }
        private IByteBuffer _buffer = Unpooled.Buffer(1024);
        public ServerConnected(string strMessage)
        {
            StrMessage = strMessage;
        }

        public IPacket BuildPacket()
        {
            _buffer.Clear();
            _buffer.WriteString(StrMessage, Encoding.UTF8);
            return this;
        }

        public IByteBuffer? GetPacket()
        {
            if (_buffer.ReadableBytes <= 0)
                return null;
            return _buffer;
        }
    }
}
