namespace CemuhookUDP.Lib;

public class Version
{
    public ushort version;

    public Version(ushort version)
    {
        this.version = version;
    }

    public static Version DecodeVersion(byte[] packet, int cursor = 0)
    {
        return new Version(BitConverter.ToUInt16(packet));
    }
}

public class PortInfo
{
    public static uint MAX_PORTS = 4;

    public uint padCount;

    public byte[] port;

    public PortInfo(uint padCount, byte[] port)
    {
        this.padCount = padCount;
        this.port = port;
    }

    public static PortInfo? DecodePortInfo(byte[] packect, int cursor = 0)
    {
        var padCount = BitConverter.ToUInt32(packect, cursor);

        cursor += 4;

        for (var i = 0; i < padCount; i++)
        {
            var slotIndex = packect[cursor + i];
            if (slotIndex > MAX_PORTS)
            {
                return null;
            }
        }

        byte[] port =
        {
            packect[cursor],
            packect[cursor + 1],
            packect[cursor + 2],
            packect[cursor + 3],
        };

        return new PortInfo(padCount, port);
    }
}

public class PadInfo
{
    // /// Determines which method will be used as a look up for the controller
    // RegisterFlags flags{};
    // /// Index of the port of the controller to retrieve data about
    // u8 port_id{};
    //
    // /// Mac address of the controller to retrieve data about
    // private MacAddress mac;
}

