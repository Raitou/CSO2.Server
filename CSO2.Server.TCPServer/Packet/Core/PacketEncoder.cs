using CSO2.Server.Common.Packet;
using CSO2.Server.Common.Packet.Enum;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using TCPServer.Client;

namespace CSO2.Server.TCPServer.Packet.Core
{
    internal class PacketEncoder : MessageToByteEncoder<IPacket>
    {
        private readonly TcpClient _client;
        public PacketEncoder(TcpClient client)
        {
            _client = client;
        }

        private readonly object _lock = new object();
        protected override void Encode(IChannelHandlerContext context, IPacket message, IByteBuffer output)
        {
            lock (_lock)
            {
                try
                {
                    if (message.GetBuiltPacket() == null)
                        throw new Exception("Packet is Empty");

                    if(message.PacketID != PacketID.ClientConnect)
                    {
                        output.WriteByte(createHeader());
                        output.WriteByte(getSequence());
                        output.WriteShortLE(message.ByteBuffer.ReadableBytes);
                    }
                    output.WriteBytes(message.ByteBuffer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (message.GetBuiltPacket() != null)
                        message.ByteBuffer.Clear();
                }
            }
        }

        private byte createHeader()
        {
            return (byte)PacketSignature.TCPSignature;
        }

        private byte getSequence()
        {
            return _client.Sequence++;
        }
    }
}
