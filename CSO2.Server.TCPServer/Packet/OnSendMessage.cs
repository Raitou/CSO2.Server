using CSO2.Server.Common.Data.Map;
using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using System.Text;

namespace TCPServer.Packet
{
    //internal class OnSendMessage : IPacket
    //{
    //    public string ClientMessage { get; set; }
    //    public IByteBuffer ByteBuffer { get; }
    //    public PacketID PacketID { get; }

    //    public IDataMap DataMap => throw new NotImplementedException();

    //    public OnSendMessage(string InGameMessage)
    //    {
    //        ClientMessage = InGameMessage;
    //        ByteBuffer = Unpooled.Buffer(1024);
    //    }
    //    // public BuildMessage(int tp, byte msg)
    //    // {
    //    //ByteBuffer = Unpooled.Buffer(1024);
    //    //    if (tp == MessageCongratulate)
    //    //    {
    //    //ByteBuffer.WriteInt(0); // Type
    //    //ByteBuffer.WriteByte(msg); // String Msg
    //    //}
    //    // ByteBuffer.WriteInt(msg); // Unk
    //    // }


    //    public IPacket BuildPacket()
    //    {
    //        ByteBuffer.Clear();
    //        ByteBuffer.WriteInt(0); // Unk
    //        ByteBuffer.WriteString(ClientMessage, Encoding.UTF8);
    //        return this;
    //    }

    //    public IPacket? GetBuiltPacket()
    //    {
    //        if (ByteBuffer.ReadableBytes <= 0)
    //            return null;
    //        return this;
    //    }
    //}
}
