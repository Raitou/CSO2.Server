using CSO2.Server.Common.Data.Map;
using CSO2.Server.Common.Packet.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.TCPServer.Data.Map
{
    public class MapVersionInfo : IDataMap
    {
        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedData { get; set; }

        public MapVersionInfo()
        {
            MappedData = new Dictionary<string, Dictionary<MappedDataTypes, object>>();
            MappedData.Add("bBadHash", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.Boolean, false } });
            MappedData.Add("strVersion", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.String_ASCII, "" } });
        }
    }
}
