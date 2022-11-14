using CSO2.Server.Common.Packet.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Utilities
{
    public static class MappedUtil
    {
        public static void PrintMap(Dictionary<string, Dictionary<MappedDataTypes, object>> map)
        {
            foreach (var item in map)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value.First().Value);
            }
        }
    }
}
