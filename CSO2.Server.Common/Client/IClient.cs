
using CSO2.Server.Common.Packet;
using DotNetty.Transport.Channels;

namespace CSO2.Server.Common.Client
{
    public interface IClient
    {
        public IChannel Channel { get; set; }
        void Send(IPacket _packet);
    }
}
