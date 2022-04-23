using System.Net;
using System.Runtime.InteropServices;
using static CemuhookUDP.Shared.Constants;
using Force.Crc32;

namespace CemuhookUDP.Shared;

[StructLayout(LayoutKind.Explicit, Size = 16, CharSet = CharSet.Ansi)]
public class Header

{
    [FieldOffset(0)] public uint magic;

    [FieldOffset(4)] public ushort protocolVersion;

    [FieldOffset(6)] public ushort payloadLength;

    [FieldOffset(8)] public uint crc;

    [FieldOffset(12)] public uint id;
}