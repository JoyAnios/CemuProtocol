using System;
using System.Runtime.InteropServices;
using CemuhookUDP;
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
    public void TestMagic()
    {
        byte[] msg =
        {
            (byte) 'D',
            (byte) 'S',
            (byte) 'U',
            (byte) 'C'
        };

        Assert.IsTrue(BitConverter.ToInt32(msg) == Constants.ClientMagic);
    }

    [StructLayout(LayoutKind.Explicit, Size = 2, CharSet = CharSet.Ansi)]
    public class DemoMessage
    {
        [FieldOffset(0)] public byte t1;

        [FieldOffset(1)] public byte t2;
    }

    [Test]
    public void TestDecode()
    {
        var td = new byte[] {11, 22};
        var d = CemuhookUDPDecoder.Decode<DemoMessage>(td);
        Assert.IsTrue(d.t1 == 11);
    }

    [Test]
    public void TestDecodeClientHeader()
    {
        byte[] msg =
        {
            0x44, 0x53, 0x55, 0x43, 0xE9, 0x03, 0x0C, 0x00, 0x9F, 0x0A, 0x18, 0x86, 0x75, 0xD7, 0xD7, 0xA3, 0x02, 0x00,
            0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };
        var header = CemuhookUDPDecoder.Decode<Header>(msg);
        Assert.IsTrue(header != null);
        Assert.IsTrue(header?.magic == Constants.ClientMagic);
        Assert.IsTrue(header?.id == 0xa3d7d775);
        Assert.IsTrue(header?.crc == 0x86180a9f);
        Assert.IsTrue(header?.protocolVersion == 1001);
        Assert.IsTrue(header?.payloadLength == 0x0000001c - Constants.HeaderSize);
    }
}