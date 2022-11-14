using CSO2.Server.Common.Data.Map;
using CSO2.Server.Common.Packet.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.TCPServer.Data.Map
{
    public class MapClientConnect : IDataMap
    {
        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedData { get; set; }

        public MapClientConnect()
        {
            MappedData = new Dictionary<string, Dictionary<MappedDataTypes, object>>();
            MappedData.Add("strMessage", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.String_UTF8, "" } });
        }
    }
}
