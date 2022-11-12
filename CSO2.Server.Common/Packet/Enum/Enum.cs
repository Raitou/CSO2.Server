using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Packet.Enum
{
    public enum PacketID
    {
        VersionInfo = 0,
        ClientConnect = -1,
        PacketTypeUnk2 = 2,
        PacketTypeLogin = 3,
        PacketTypeServerList = 5,
        PacketTypeCharacter = 6,
        PacketTypeRequestRoomList = 7,
        PacketTypeRequestChannels = 10,
        PacketTypeNickname = 15,
        PacketTypePlayerInfo = 69,
        PacketTypeUdp = 70,
        PacketTypeShop = 72,
        PacketTypeBlackMarket = 73,
        PacketTypeBan = 74,
        PacketTypeOption = 76,
        PacketTypeFavorite = 77,
        PacketTypeUseItem = 78,
        PacketTypeQuickJoin = 80,
        PacketTypeReport = 83,
        PacketTypeSignature = 85,
        PacketTypeQuickStart = 86,
        PacketTypeAutomatch = 88,
        PacketTypeFriend = 89,
        PacketTypeUnlock = 90,
        PacketTypeUnReadedMessage = 91,
        PacketTypeGZBigCity = 95,
        PacketTypeAchievement = 96,
        PacketTypeCombination = 101,
        PacketTypeSupply = 102,
        PacketTypeRemove = 103,
        PacketTypeDisassemble = 104,
        PacketTypeBroadcasts = 105,
        PacketTypeConfigInfo = 106,
        PacketTypeLobby = 107,
        PacketTypeEmpowerment = 108,
        PacketTypeChatChannel1 = 110,
        PacketTypeChatChannelSearch = 111,
        PacketTypeChatChannel3 = 112,
        PacketTypeUserStart = 150,
        PacketTypeRoomList = 151,
        PacketTypeInventory_Add = 152,
        PacketTypeInventory_Create = 154,
        PacketTypeUserInfo = 157,
        PacketTypeRelayServer = 254,
    }

    public enum PacketSignature
    {
        TCPSignature = 85
    }
}
