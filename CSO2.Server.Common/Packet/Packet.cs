using CSO2.Server.Common.Data.Map;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Packet
{
    public abstract class Packet : IPacket
    {
        public IByteBuffer ByteBuffer { get; set; }
        public PacketID PacketID { get; set; }
        public IDataMap DataMap { get; set; }

        protected Packet(PacketID packetID, IDataMap dataMap)
        {
            ByteBuffer = Unpooled.Buffer(1024);
            PacketID = packetID;
            DataMap = dataMap;
        }

        public virtual IPacket BuildPacket()
        {
            ByteBuffer.Clear();
            ByteBuffer.WriteByte((int)PacketID);
            foreach (var item in DataMap.MappedData.Select(item => item.Value))
            {
                switch (item.First().Key)
                {
                    case MappedDataTypes.Integer:
                        {
                            ByteBuffer.WriteInt((int)item.First().Value);
                        } 
                        break;
                    case MappedDataTypes.IntegerLE:
                        {
                            ByteBuffer.WriteIntLE((int)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.Short:
                        {
                            ByteBuffer.WriteShort((short)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.ShortLE:
                        {
                            ByteBuffer.WriteShortLE((short)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.Long:
                        {
                            ByteBuffer.WriteLong((long)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.LongLE:
                        {
                            ByteBuffer.WriteLongLE((long)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.Float:
                        {
                            ByteBuffer.WriteFloat((float)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.FloatLE:
                        {
                            ByteBuffer.WriteFloat((float)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.Char:
                        {
                            ByteBuffer.WriteChar((char)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.Boolean:
                        {
                            ByteBuffer.WriteBoolean((bool)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.String_UTF8:
                        {
                            ByteBuffer.WriteString(item.First().Value.ToString(), Encoding.UTF8);
                        }
                        break;
                    case MappedDataTypes.String_ASCII:
                        {
                            ByteBuffer.WriteString(item.First().Value.ToString(), Encoding.ASCII);
                        }
                        break;
                }
            }
            return this;
        }

        public virtual IPacket? GetPacket()
        {
            if (ByteBuffer.ReadableBytes <= 0)
                return null;
            return this;
        }
    }
}
