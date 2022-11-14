using CSO2.Server.Common.Client;
using CSO2.Server.TCPServer.Packet.Helper;
using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using System.Text;
using CSO2.Server.Common.Data.Map;

namespace CSO2.Server.TCPServer.Packet
{
    internal class Login : ILogin, IPacket
    {
        public IByteBuffer ByteBuffer { get; set; }
        public PacketID PacketID { get; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public IDataMap DataMap => throw new NotImplementedException();

        public Login(string username, string password)
        {
            UserName = username;
            Password = password;
            ByteBuffer = Unpooled.Buffer(1024);
        }

        public IPacket BuildPacket()
        {
            ByteBuffer.Clear();
            ByteBuffer.WriteInt(0); // User ID
            ByteBuffer.WriteString("testuser", Encoding.ASCII); 
            ByteBuffer.WriteString("testuser", Encoding.ASCII);
            ByteBuffer.WriteInt(1); // Access
            ByteBuffer.WriteInt(9001); // UDP Port
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
