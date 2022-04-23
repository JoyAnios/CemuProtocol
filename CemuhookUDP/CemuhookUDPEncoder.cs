using System.Runtime.InteropServices;

namespace CemuhookUDP;

public class CemuhookUDPDecoder
{
    public static T? Decode<T>(byte[] packet) where T: new()  
    {
        var t = new T();
        var size = Marshal.SizeOf(t);
        IntPtr p = Marshal.AllocHGlobal(size);
        Marshal.Copy(packet, 0, p, size);
        try
        {
            return Marshal.PtrToStructure<T>(p);
        }
        finally
        {
            Marshal.FreeHGlobal(p);
        }
    }
    
    // public static 
}