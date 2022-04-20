using Force.Crc32;

namespace CemuhookUDP;

// C++ version
// struct Header {
//     u32_le magic{};
//     u16_le protocol_version{};
//     u16_le payload_length{};
//     u32_le crc{};
//     u32_le id{};
//     ///> In the protocol, the type of the packet is not part of the header, but its convenient to
//     ///> include in the header so the callee doesn't have to duplicate the type twice when building
//     ///> the data
//     Type type{};
// };

// constexpr std::size_t MAX_PACKET_SIZE = 100;
// constexpr u16 PROTOCOL_VERSION = 1001;
// constexpr u32 CLIENT_MAGIC = 0x43555344; // DSUC (but flipped for LE)
// constexpr u32 SERVER_MAGIC = 0x53555344; // DSUS (but flipped for LE)
public enum MessageType : uint
{
    Version = 0x00100000,
    PortInfo = 0x00100001,
    PadData = 0x00100002
}

public class Header

{
    public const uint MAX_PACKET_SIZE = 100;

    public const ushort PROTOCOL_VERSION = 1001;
    public const uint CLIENT_MAGIC = 0x43555344; // DSUC (but flipped for LE)
    public const uint SERVER_MAGIC = 0x53555344; // DSUS (but flipped for LE)
    public const int LENGTH = 16;

    public uint magic;

    public ushort protocolVersion;

    public ushort payloadLength;

    public uint crc;

    public uint id;
    
    public Header(uint magic, ushort protocolVersion, ushort payloadLength, uint crc, uint id)
    {
        this.magic = magic;
        this.protocolVersion = protocolVersion;
        this.payloadLength = payloadLength;
        this.crc = crc;
        this.id = id;
    }

    public static uint DecodeMagic(byte[] packet)
    {
        var magic = BitConverter.ToUInt32(packet, 0);
        return magic;
    }

    public static Header? DecodeHeaderAfterMagic(byte[] packet, uint magic)
    {
        int cursor = 4;
        var protocolVersion = BitConverter.ToUInt16(packet, cursor);

        if (protocolVersion > PROTOCOL_VERSION)
        {
            return null;
        }
        
        cursor += 2;
        var payloadLength = BitConverter.ToUInt16(packet, cursor);
        if (payloadLength != packet.Length - LENGTH)
        {
            return null;
        }
        
        cursor += 2;
        var crc = BitConverter.ToUInt32(packet, cursor);
        // crc check
        // Rewirte crc field to 0000
        Array.Copy(BitConverter.GetBytes((uint)0), 0, packet, cursor, 4 );
        // do crc
       var computedCrc =  Crc32Algorithm.Compute(packet);
       if (crc != computedCrc)
       {
           return null;
       } 
        
        cursor += 4;
        var serverId = BitConverter.ToUInt32(packet, cursor);
        cursor += 4;
        
        return new Header(magic, protocolVersion, payloadLength, crc, serverId);
    }

    public static Header? DecodeServerHeader(byte[] packet)
    {
        var magic = DecodeMagic(packet);

        return magic == SERVER_MAGIC
            ? DecodeHeaderAfterMagic(packet, magic)
            : null;
    }

    public static Header? DecodeClientHeader(byte[] packet)
    {
        var magic = DecodeMagic(packet);

        return magic == CLIENT_MAGIC
            ? DecodeHeaderAfterMagic(packet, magic)
            : null;
    }
}