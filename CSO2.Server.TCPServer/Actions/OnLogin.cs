﻿using CSO2.Server.Common.Action;
using CSO2.Server.Common.Packet;
using CSO2.Server.TCPServer.Channel.Helper;
using DotNetty.Transport.Channels;
using Action = CSO2.Server.Common.Action.Action;

namespace CSO2.Server.TCPServer.Actions
{
    public class OnLogin : ActionChannelCtx
    {
        private readonly LoginHelper _loginHelper;
        public OnLogin(IChannelHandlerContext ctx, PacketData packetData) : base(ctx)
        {
            _loginHelper = new LoginHelper();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
