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
        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedDataIn { get; set; }
        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedDataOut { get; set; }

        public MapClientConnect()
        {
            MappedDataIn = new Dictionary<string, Dictionary<MappedDataTypes, object>>();
            MappedDataOut = new Dictionary<string, Dictionary<MappedDataTypes, object>>();

            #region MappedDataOut

            MappedDataOut.Add("strMessage", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.Bytes_NoLen, new byte[] { 0 } } });

            #endregion
        }

    }
}
