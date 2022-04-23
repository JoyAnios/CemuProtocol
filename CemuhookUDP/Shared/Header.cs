using System.Net;
using System.Runtime.InteropServices;
using Force.Crc32;

namespace CemuhookUDP.Shared;

public class Header

{
    public const uint MaxPacketSize = 100;

    public const ushort ProtocolVersion = 1001;
    public const uint ClientMagic = 0x43555344; // DSUC (but flipped for LE)
    public const uint ServerMagic = 0x53555344; // DSUS (but flipped for LE)
    public const int Length = 16;

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

        if (protocolVersion > ProtocolVersion)
        {
            return null;
        }
        
        cursor += 2;
        var payloadLength = BitConverter.ToUInt16(packet, cursor);
        if (payloadLength != packet.Length - Length)
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

        return magic == ServerMagic
            ? DecodeHeaderAfterMagic(packet, magic)
            : null;
    }

    public static Header? DecodeClientHeader(byte[] packet)
    {
        var magic = DecodeMagic(packet);

        return magic == ClientMagic
            ? DecodeHeaderAfterMagic(packet, magic)
            : null;
    }

    // public static byte[] EncodeClientHeader(byte[] packet )
    // {
    //     
    // }
}