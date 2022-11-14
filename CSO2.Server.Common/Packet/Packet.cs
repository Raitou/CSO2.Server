using CSO2.Server.Common.Data.Map;
using CSO2.Server.Common.Packet.Enum;
using CSO2.Server.Common.Utilities;
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
            foreach (var item in DataMap.MappedDataOut.Select(item => item.Value))
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
                    case MappedDataTypes.String:
                        {
                            byte[] bytes = Encoding.UTF8.GetBytes(item.First().Value.ToString()!);
                            ByteBuffer.WriteByte(bytes.Length);
                            ByteBuffer.WriteBytes(bytes);
                        }
                        break;
                    case MappedDataTypes.Byte:
                        {
                            ByteBuffer.WriteByte((byte)item.First().Value);
                        }
                        break;
                    case MappedDataTypes.Bytes:
                        {
                            byte[] bytes = (byte[])item.First().Value;
                            ByteBuffer.WriteByte(bytes.Length);
                            ByteBuffer.WriteBytes(bytes);
                        }
                        break;
                    case MappedDataTypes.Bytes_NoLen:
                        {
                            byte[] bytes = (byte[])item.First().Value;
                            ByteBuffer.WriteBytes(bytes);
                        }
                        break;
                }
            }
            return this;
        }

        public virtual IPacket? GetBuiltPacket()
        {
            if (ByteBuffer.ReadableBytes <= 0)
                return null;
            return this;
        }

        public virtual void SetMappedPacket(PacketData msg)
        {
            IByteBuffer byteBuffer = Unpooled.CopiedBuffer(msg.RawData);
            foreach (var item in DataMap.MappedDataIn.Select(item => item.Value))
            {
                switch (item.First().Key)
                {
                    case MappedDataTypes.Integer:
                        {
                            item[item.First().Key] = byteBuffer.ReadInt();
                        }
                        break;
                    case MappedDataTypes.IntegerLE:
                        {
                            item[item.First().Key] = byteBuffer.ReadIntLE();
                        }
                        break;
                    case MappedDataTypes.Short:
                        {
                            item[item.First().Key] = byteBuffer.ReadShort();
                        }
                        break;
                    case MappedDataTypes.ShortLE:
                        {
                            item[item.First().Key] = byteBuffer.ReadShortLE();
                        }
                        break;
                    case MappedDataTypes.Long:
                        {
                            item[item.First().Key] = byteBuffer.ReadLong();
                        }
                        break;
                    case MappedDataTypes.LongLE:
                        {
                            item[item.First().Key] = byteBuffer.ReadLongLE();
                        }
                        break;
                    case MappedDataTypes.Float:
                        {
                            item[item.First().Key] = byteBuffer.ReadFloat();
                        }
                        break;
                    case MappedDataTypes.FloatLE:
                        {
                            item[item.First().Key] = byteBuffer.ReadFloatLE();
                        }
                        break;
                    case MappedDataTypes.Char:
                        {
                            item[item.First().Key] = byteBuffer.ReadChar();
                        }
                        break;
                    case MappedDataTypes.Boolean:
                        {
                            item[item.First().Key] = byteBuffer.ReadBoolean();
                        }
                        break;
                    case MappedDataTypes.String:
                        {
                            int strLen = byteBuffer.ReadByte();
                            item[item.First().Key] = byteBuffer.ReadString(strLen, Encoding.UTF8);
                        }
                        break;
                    case MappedDataTypes.String_LenShort:
                        {
                            int strLen = byteBuffer.ReadShortLE();
                            item[item.First().Key] = byteBuffer.ReadString(strLen, Encoding.UTF8);
                        }
                        break;
                    case MappedDataTypes.Byte:
                        {
                            item[item.First().Key] = byteBuffer.ReadByte();
                        }
                        break;
                    case MappedDataTypes.Bytes:
                        {
                            int byteLen = byteBuffer.ReadByte();
                            byte[] bytes = new byte[byteLen];
                            byteBuffer.ReadBytes(bytes);
                            item[item.First().Key] = bytes;
                        }
                        break;
                    case MappedDataTypes.Bytes_NoLen:
                        {
                            item[item.First().Key] = byteBuffer.ReadBytes((byte[])item[item.First().Key]); //if no length is provided then we will use the lenght that is already declared in the mapped data
                        }
                        break;
                }
            }

            //test
            MappedUtil.PrintMap(DataMap.MappedDataIn);

            byteBuffer.Clear();
        }
    }
}
