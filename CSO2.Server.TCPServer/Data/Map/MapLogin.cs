using CSO2.Server.Common.Data.Map;
using CSO2.Server.Common.Packet.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.TCPServer.Data.Map
{
    public class MapLogin : IDataMap
    {
        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedDataIn { get; set; }

        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedDataOut { get; set; }

        public MapLogin()
        {
            MappedDataIn = new Dictionary<string, Dictionary<MappedDataTypes, object>>();
            MappedDataOut = new Dictionary<string, Dictionary<MappedDataTypes, object>>();

            #region MappedDataIn

            MappedDataIn.Add("strNexonUsername", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.String, "" } });
            MappedDataIn.Add("strGameUsername", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.String, "" } });
            MappedDataIn.Add("byteUnk1", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.Byte, 0 } });
            MappedDataIn.Add("strPassword", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.String_LenShort, "" } });
            MappedDataIn.Add("vecHardwareID", new Dictionary<MappedDataTypes, object> { { MappedDataTypes.Bytes_NoLen, new byte[16] } }); //HardwareID is 16 bytes in length.

            //There is still more but we dont really need them eg. (NetCafeID, UserSN, etc.)
            #endregion

            #region MappedDataOut




            #endregion
        }
    }
}
