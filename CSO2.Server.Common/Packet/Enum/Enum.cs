using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Packet.Enum
{
    public enum PacketID
    {
        ClientConnect = -1,
        VersionInfo = 0,
        UnknownPacket01,
        Login,

        
    }

    public enum PacketSignature
    {
        TCPSignature = 85
    }
}
