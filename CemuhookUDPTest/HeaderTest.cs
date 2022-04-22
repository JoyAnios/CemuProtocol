using CemuhookUDP.Shared;
using NUnit.Framework;

namespace CemuhookUDPTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestDecodeClientHeader()
    {
        byte[] msg =
        {
            0x44, 0x53, 0x55, 0x43, 0xE9, 0x03, 0x0C, 0x00, 0x9F, 0x0A, 0x18, 0x86, 0x75, 0xD7, 0xD7, 0xA3, 0x02, 0x00,
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };
        var header = Header.DecodeClientHeader(msg);
        Assert.IsTrue(header != null);
        Assert.IsTrue(header?.magic == Header.CLIENT_MAGIC);
        Assert.IsTrue(header?.id == 0xa3d7d775);
        Assert.IsTrue(header?.crc == 0x86180a9f);
        Assert.IsTrue(header?.protocolVersion == 1001);
        Assert.IsTrue(header?.payloadLength == 0x0000001c - Header.LENGTH);
    }
}