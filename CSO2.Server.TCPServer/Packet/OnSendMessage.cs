using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using TCPServer.Packet.Core;
using System.Text;

namespace TCPServer.Packet
{
    internal class OnSendMessage : IPacket
    {
        public string ClientMessage { get; set; }
        public IByteBuffer ByteBuffer { get; }
        public PacketID PacketID { get; }

        const int MessageCongratulate = 11;
        const int MessageSystemImportant = 20;
        const int MessageDialogBox = 21;
        const int MessageNotice = 22;
        const int MessageSystem = 22;
        const int MessageDialogBoxExit = 60;

        public OnSendMessage(string InGameMessage)
        {
            ClientMessage = InGameMessage;
            ByteBuffer = Unpooled.Buffer(1024);
        }
        // public BuildMessage(int tp, byte msg)
        // {
        //ByteBuffer = Unpooled.Buffer(1024);
        //    if (tp == MessageCongratulate)
        //    {
        //ByteBuffer.WriteInt(0); // Type
        //ByteBuffer.WriteByte(msg); // String Msg
        //}
        // ByteBuffer.WriteInt(msg); // Unk
        // }


        public IPacket BuildPacket()
        {
            ByteBuffer.Clear();
            ByteBuffer.WriteInt(0); // Unk
            ByteBuffer.WriteString(ClientMessage, Encoding.UTF8);
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
