namespace CemuhookUDP.Shared;

public class Constants
{
    
    public const uint MaxPacketSize = 100;

    public const ushort ProtocolVersion = 1001;
    
    /// DSUC 
    public const uint ClientMagic = 0x43555344; 
    
    /// DSUS 
    public const uint ServerMagic = 0x53555344; 
    public const int HeaderSize = 16;

}