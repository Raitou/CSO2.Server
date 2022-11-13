using CSO2.Server.Common.Packet;
using CSO2.Server.TCPServer.Packet;
using CSO2.Server.TCPServer.Packet.Core;
using DotNetty.Transport.Channels;

namespace TCPServer.Channel.Helper
{
    internal class ChannelHelper
    {
        public void OnClientConnect(IChannelHandlerContext ctx)
        {
            ClientConnect serverConnected = new ClientConnect(strMessage: "~SERVERCONNECTED\n");
            IPacket? byteBuffer = serverConnected.BuildPacket();
            if (byteBuffer == null)
                throw new Exception("ServerConnected packet is empty!");
            ctx.WriteAndFlushAsync(byteBuffer);

            Console.WriteLine("Client {0} is connected", ctx.Channel.RemoteAddress);
        }

        public void OnVersionInfo(IChannelHandlerContext ctx)
        {
            //client ignores this so there's really no point of putting a hash here but it needs it so yup
            VersionInfo versionInfo = new VersionInfo(versionHash: "6246015df9a7d1f7311f888e7e861f18");

            IPacket? byteBuffer = versionInfo.BuildPacket();
            if (byteBuffer == null)
                throw new Exception("VersionInfo packet is empty!");
            ctx.WriteAndFlushAsync(byteBuffer);

            Console.WriteLine("VersionInfo send to {0}", ctx.Channel.RemoteAddress);
        }

        public void OnLogin(IChannelHandlerContext ctx, PacketData msg)
        {
            //IPacket? byteBuffer = OnLogin.BuildPacket();
            const int USER_LOGIN_SUCCESS = 0;
            const int USER_ALREADY_LOGIN = 1;
            const int USER_NOT_FOUND = 2;
            const int USER_PASSWD_ERROR = 3;
            const int USER_UNKOWN_ERROR = 4;

            int LoginResult = 5; // Packet Identifier from Client to Server
            if (LoginResult == USER_PASSWD_ERROR)
            {

                Console.WriteLine("Send Message to Client User Password Error");
                return;
            }
            else if (LoginResult == USER_ALREADY_LOGIN)
            {
                Console.WriteLine("Send Message to Client User Already Login");
                return;
            }
            else if (LoginResult == USER_NOT_FOUND)
            {
                Console.WriteLine("Send Message to Client User Not Found");
                return;
            }
            else if (LoginResult == USER_UNKOWN_ERROR)
            {
                Console.WriteLine("Send Message to Client Unkown Error");
                return;
            }
            else if (LoginResult == USER_LOGIN_SUCCESS)
            {
                Console.WriteLine("Login Successful Run functions while 5 second hold is running");
                //Add functions here



                //Console.WriteLine("Player", IngameName, " is Logged In.");
            }
            else
            {
                Console.WriteLine("It seems to be related to the Sign In section.");
                Console.WriteLine("Unknown login packet {0}", ctx.Channel.RemoteAddress);
            }

            Console.WriteLine("Login Packet send to {0}", ctx.Channel.RemoteAddress);
        }
    }
}
