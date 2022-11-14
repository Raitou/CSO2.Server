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
        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedDataIn { get; set; }
        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedDataOut { get; set; }

        public MapVersionInfo()
        {
            MappedDataIn = new Dictionary<string, Dictionary<MappedDataTypes, object>>();
            MappedDataOut = new Dictionary<string, Dictionary<MappedDataTypes, object>>();

            #region MappedDataOut

            MappedDataOut.Add("bBadHash", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.Boolean, false } });
            MappedDataOut.Add("strVersion", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.Bytes_NoLen, new byte[] { 0 } } });

            #endregion
        }
    }
}
