namespace CemuhookUDP.Request;

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