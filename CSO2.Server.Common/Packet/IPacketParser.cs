using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Packet
{
    public interface IPacketParser : IPacket
    {
        IPacketParser ParsePacket();
    }
}
