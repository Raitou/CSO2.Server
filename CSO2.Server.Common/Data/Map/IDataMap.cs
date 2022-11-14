using CSO2.Server.Common.Packet.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Data.Map
{
    public interface IDataMap
    {
        /**
         * <summary>
         * MappedData maps how the structure of a said packet will look like.
         * We will add a structure by stating first the identifier as the key for
         * the said block of data which when built can just call the Key and append the value.
         * Then you could choose whether to change the default value which is stated 
         * once you implmented the dictionary inside a method.
         * 
         * Add Key Example: MappedData.Add("Key", new Dict(....) { { "MappedDataType", "Value" } }
         * Access Key Example: MappedData["Key"][MappedDataTypes.String] = "Value"
         * </summary>
         */
        public Dictionary<string, Dictionary<MappedDataTypes, object>> MappedData { get; }
    }
}
