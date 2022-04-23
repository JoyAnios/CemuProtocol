namespace CemuhookUDP.Shared;

public class Constants
{
    
    public const uint MaxPacketSize = 100;

    public const ushort ProtocolVersion = 1001;
    public const uint ClientMagic = 0x43555344; // DSUC (but flipped for LE)
    public const uint ServerMagic = 0x53555344; // DSUS (but flipped for LE)
    public const int HeaderSize = 16;

}