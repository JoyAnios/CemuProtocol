
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



public class Packet
{
    public Header Header;

    public Type type;

    // public Padinfo
}

public class PortInfo
{
    
    
}