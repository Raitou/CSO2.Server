using CSO2.Server.TCPServer.Packet.Core;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System.Net;
using TCPServer.Channel.Handler;
using TCPServer.Client;

namespace CSO2.Server.TCPServer.Startup
{
    public static class Startup
    {

        static bool bRunning = true;

        public static void Start()
        {

            MultithreadEventLoopGroup bossGroup = new MultithreadEventLoopGroup(1);
            MultithreadEventLoopGroup workerGroup = new MultithreadEventLoopGroup();

            try
            {
                // https://github.com/Azure/azure-iot-protocol-gateway/blob/master/docs/DeveloperGuide.md
                ServerBootstrap serverBootstrap = new ServerBootstrap();
                serverBootstrap
                    .Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        TcpClient client = new TcpClient(channel);
                        IChannelPipeline pipeline = channel.Pipeline;
                        pipeline.AddLast(
                            new PacketDecoder(client),
                            new PacketEncoder(client),
                            new ChannelHandler()
                            );

                    }))
                    .ChildOption(ChannelOption.TcpNodelay, true)
                    .ChildOption(ChannelOption.SoKeepalive, true);

                // TODO: Move this to config
                IChannel bootstrapChannel = serverBootstrap.BindAsync(
                    IPAddress.Parse("127.0.0.1")
                    , 12000 // avoid known ports
                    ).GetAwaiter()
                    .GetResult();

                Console.WriteLine("Started TCP Server on {0}", bootstrapChannel.LocalAddress.ToString());

                Console.CancelKeyPress += delegate (object? sender, ConsoleCancelEventArgs e)
                {
                    e.Cancel = true;
                    Stop();
                };

                while (bRunning) ;

                bootstrapChannel.CloseAsync().GetAwaiter();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // TODO: make a logger
            }
            finally
            {
                Task.WaitAll(bossGroup.ShutdownGracefullyAsync(), workerGroup.ShutdownGracefullyAsync());
                Console.WriteLine("TCP Server exited gracefully"); // TODO: make a logger
            }
        }

        public static void Stop()
        {
            bRunning = false;
        }
    }
}