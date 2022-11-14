using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using TCPServer.Client;

namespace CSO2.Server.TCPServer.Packet.Core
{
    internal class PacketDecoder : ByteToMessageDecoder
    {
        private readonly TcpClient _client;
        public PacketDecoder(TcpClient client)
        {
            _client = client;
        }

        private readonly object _lock = new object();
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            lock(_lock)
            {
                try
                {
                    if (input == null)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    if (input.ReadableBytes <= 0)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    byte header = input.ReadByte();
                    if (validateHeader(header) != true)
                    {
                        throw new Exception(String.Format("Invalid Header. Header expect {0} but received {1}", 
                            PacketSignature.TCPSignature,
                            header));
                    }
                    byte seq = input.ReadByte();
                    if (validateSequence(seq) != true)
                    {
                        throw new Exception(String.Format("Invalid sequence. Sequence expect {0} but received {1}", 
                            _client.Sequence, 
                            seq));
                    }
                    setSequence(seq);
                    output.Add(new PacketData(parseRawData(input)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if(input != null) input.Clear();
                }
            }
           
        }

        private byte[] parseRawData(IByteBuffer _input)
        {
            int packetLen = _input.ReadShortLE();
            byte[] packetData = new byte[packetLen];
            _input.ReadBytes(packetData);
            return packetData;
        }

        private bool validateSequence(byte _seq)
        {
            if (_client.Sequence == _seq) //if initial sequence
                return true;
            if (_client.Sequence + 1 == _seq) //if not initial
                return true;
            return false;
        }

        private void setSequence(byte _seq)
        {
            _client.Sequence = _seq;
        }

        private bool validateHeader(byte _seq)
        {
            return _seq == (byte)PacketSignature.TCPSignature;
        }
    }
}
