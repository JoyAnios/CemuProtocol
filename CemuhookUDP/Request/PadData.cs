namespace CemuhookUDP.Request;

public enum RegisterFlags : byte
{
    AllPads,
    PadID,
    PadMACAdddress,
};

public class PadData
{
    public RegisterFlags flags;

    public byte portId;

    public byte[] mac = new byte[8];
}