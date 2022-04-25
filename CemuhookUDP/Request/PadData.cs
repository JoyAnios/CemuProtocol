using System.Runtime.InteropServices;

namespace CemuhookUDP.Request;

public enum RegisterFlags : byte
{
    AllPads,
    PadID,
    PadMACAdddress,
};

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct PadData
{
    [FieldOffset(0)] public RegisterFlags flags;

    [FieldOffset(1)] public byte portId;

    [FieldOffset(2)] public unsafe fixed  byte mac[6] ;
}