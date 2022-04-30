using System.Runtime.InteropServices;
using CemuhookUDP.Shared;

namespace CemuhookUDP.Response;

public enum ConnectionType : byte
{
    None,
    Usb,
    Bluetooth
}

public enum State : byte
{
    Disconnected,
    Reserved,
    Connected
}

public enum Model : byte
{
    None,
    PartialGyro,
    FullGyro,
    Generic
}

public enum Battery : byte
{
    None = 0x00,
    Dying = 0x01,
    Low = 0x02,
    Medium = 0x03,
    High = 0x04,
    Full = 0x05,
    Charging = 0xEE,
    Charged = 0xEF,
};


[StructLayout(LayoutKind.Explicit, Size = 12)]
public struct PortInfo
{
    [FieldOffset(0)] public byte id;
    [FieldOffset(1)] public State state;
    [FieldOffset(2)] public Model model;
    [FieldOffset(3)] public ConnectionType connectionType;
    [FieldOffset(4)] public unsafe fixed byte mac[6];
    [FieldOffset(10)] public Battery Battery;
    [FieldOffset(11)] public byte isPadActive;
}