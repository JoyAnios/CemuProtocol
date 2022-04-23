using CemuhookUDP.Shared;

namespace CemuhookUDP.Request;

public class RequestPacket<T> 
{
    public Header header = new Header(Header.ClientMagic, Header.ProtocolVersion, 0, 0,0 );

    public MessageTye type;

    public T data;
}