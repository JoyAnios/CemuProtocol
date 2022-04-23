namespace CemuhookUDP.Request;

public class PortInfo
{
    public const uint MaxPorts = 4;

    
    
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
            if (slotIndex > MaxPorts)
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