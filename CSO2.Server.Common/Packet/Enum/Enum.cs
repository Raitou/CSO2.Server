using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSO2.Server.Common.Packet.Enum
{
    public enum PacketID
    {
        ClientConnect = -1,
        VersionInfo = 0,
        Unknown2 = 2,
        Login = 3,
        ServerList = 5,
        Character = 6,
        RequestRoomList = 7,
        RequestChannels = 10,
        Nickname = 15,
        PlayerInfo = 69,
        Udp = 70,
        Shop = 72,
        BlackMarket = 73,
        Ban = 74,
        Option = 76,
        Favorite = 77,
        UseItem = 78,
        QuickJoin = 80,
        Report = 83,
        Signature = 85,
        QuickStart = 86,
        Automatch = 88,
        Friend = 89,
        Unlock = 90,
        UnReadedMessage = 91,
        GZBigCity = 95,
        Achievement = 96,
        Combination = 101,
        Supply = 102,
        Remove = 103,
        Disassemble = 104,
        Broadcasts = 105,
        ConfigInfo = 106,
        Lobby = 107,
        Empowerment = 108,
        ChatChannel1 = 110,
        ChatChannelSearch = 111,
        ChatChannel3 = 112,
        UserStart = 150,
        RoomList = 151,
        Inventory_Add = 152,
        Inventory_Create = 154,
        UserInfo = 157,
        RelayServer = 254,
    }

    public enum PacketSignature
    {
        TCPSignature = 85
    }

    public enum MessageType
    {
        Congratulate = 11,
        SystemImportant = 20,
        DialogBox = 21,
        Notice = 22,
        System = Notice,
        DialogBoxExit = 60,
    }

    public enum MappedDataTypes
    {
        Integer = 0,
        IntegerLE,
        Short,
        ShortLE,
        Long,
        LongLE,
        Float,
        FloatLE,
        Char,
        Boolean,
        String,
        String_LenShort,
        Byte,
        Bytes,
        Bytes_NoLen,
    }

    public enum LoginReturnTypes
    {
        USER_LOGIN_SUCCESS = 0,
        USER_ALREADY_LOGIN,
        USER_NOT_FOUND,
        USER_PASSWD_ERROR,
        USER_UNKOWN_ERROR,
    }
}
