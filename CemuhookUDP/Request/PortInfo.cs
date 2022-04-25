using System.Runtime.InteropServices;
using CemuhookUDP.Shared;

namespace CemuhookUDP.Request;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct PortInfo
{

    [FieldOffset(0)] public uint padCount;

    [FieldOffset(4)] public unsafe fixed byte port [Constants.MaxPorts];
}