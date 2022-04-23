using CemuhookUDP.Shared;

namespace CemuhookUDP.Request;

public class RequestPacket<T> 
{
    // public Header header = new Header(Constants.ClientMagic, Constants.ProtocolVersion, 0, 0,0 );

    public MessageTye type;

    public T data;
}