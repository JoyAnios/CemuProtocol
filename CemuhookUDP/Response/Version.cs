using System.Runtime.InteropServices;

namespace CemuhookUDP.Response;

[StructLayout(LayoutKind.Explicit, Size = 2)]
public class Version
{
   [FieldOffset(0)] public ushort version;
}