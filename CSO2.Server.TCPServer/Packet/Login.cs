using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using System.Text;

namespace TCPServer.Packet
{
    internal class Login : IPacket
    {
        public int _userid;
        public string _UserName;
        public string _IngameName;
        public int _non;
        public int _HolePunchPort;
        public IByteBuffer ByteBuffer { get; set; }
        public PacketID PacketID { get; }

        public Login(int Userid, string UserName, string IngameName, int HolePunchPort)
        {
            _userid = Userid;
            _UserName = UserName;
            _IngameName = IngameName;
            _HolePunchPort = HolePunchPort;
            ByteBuffer = Unpooled.Buffer(1024);
        }


        public IPacket BuildPacket()
        {
            ByteBuffer.Clear();
            ByteBuffer.WriteInt(_userid); // User ID
            ByteBuffer.WriteString(_UserName, Encoding.ASCII); 
            ByteBuffer.WriteString(_IngameName, Encoding.ASCII);
            ByteBuffer.WriteInt(1); // Access
            ByteBuffer.WriteInt(_HolePunchPort); // UDP Port
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
