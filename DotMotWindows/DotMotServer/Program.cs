using System;
using System.Runtime.InteropServices;

namespace DotMotServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                WindowsServer server = new WindowsServer();
                server.Start();
            }
        }
    }
}
