using System.Runtime.InteropServices;

namespace CemuhookUDP.Response;

[StructLayout(LayoutKind.Explicit, Size = 6)]
public struct TouchPad
{
    [FieldOffset(0)] public byte isActive;
    [FieldOffset(1)] public byte id;
    [FieldOffset(2)] public ushort x;
    [FieldOffset(4)] public ushort y;
}

[StructLayout(LayoutKind.Explicit, Size = 12)]
public struct MultiTouchPadData
{
    [FieldOffset(0)]public TouchPad first;
    [FieldOffset(6)]public TouchPad second;
}

public enum DigitalButton : ushort
{
    Share = 0x01,
    u8 = 0x02,
    R3 = 0x04,
    Options = 0x08,
    Up = 0x10,
    Right = 0x20,
    Down = 0x40,
    Left = 0x80,
    L2 = 0x0100,
    R2 = 0x0200,
    L1 = 0x0400,
    R1 = 0x0800,
    X = 0x1000,
    A = 0x2000,
    B = 0x4000,
    Y = 0x8000
}

[StructLayout(LayoutKind.Explicit, Size = 12)]
public struct Accelerometer
{
    [FieldOffset(0)] public float x;
    [FieldOffset(4)] public float y;
    [FieldOffset(8)] public float z;
}

[StructLayout(LayoutKind.Explicit, Size = 12)]
public struct Gyroscope
{
    [FieldOffset(0)] public float pitch;
    [FieldOffset(4)] public float yaw;
    [FieldOffset(8)] public float roll;
}

[StructLayout(LayoutKind.Explicit, Size = 12)]
public struct AnalogButton
{
    [FieldOffset(0)] public byte analogLeft;
    [FieldOffset(1)] public byte analogDown;
    [FieldOffset(2)] public byte analogRight;
    [FieldOffset(3)] public byte analogUp;

    [FieldOffset(4)] public byte analogY;
    [FieldOffset(5)] public byte analogB;
    [FieldOffset(6)] public byte analogA;
    [FieldOffset(7)] public byte analogX;

    [FieldOffset(8)] public byte analogR1;
    [FieldOffset(9)] public byte analogL1;
    [FieldOffset(10)] public byte analogR2;
    [FieldOffset(11)] public byte analogL2;
}

[StructLayout(LayoutKind.Explicit, Size = 80)]
public struct PadData
{
    [FieldOffset(0)] public PortInfo portInfo;
    [FieldOffset(12)] public uint packetCounter;
    [FieldOffset(16)] public DigitalButton digitalButton;

    /// <summary>
    /// HOME button (0 or 1)
    /// </summary>
    [FieldOffset(18)] public byte home;

    [FieldOffset(19)] public byte leftStickX;
    [FieldOffset(20)] public byte leftStickY;

    [FieldOffset(21)] public byte rightStickX;
    [FieldOffset(22)] public byte rightStickY;
    /// <summary>
    /// 1 when touchpad clicked
    /// </summary>
    [FieldOffset(23)] public byte touchHardPress;

    [FieldOffset(24)] public AnalogButton analogButton;

    [FieldOffset(36)] public  MultiTouchPadData touch;

    [FieldOffset(48)] public ulong motionTimestamp;

    [FieldOffset(56)] public Accelerometer accel;

    [FieldOffset(68)] public Gyroscope gyro;

}