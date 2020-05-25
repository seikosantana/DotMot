using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace DotMotServer
{
    class WindowsServer : BaseServer
    {
        TcpListener Server = new TcpListener(IPAddress.Any, 8070);

        public override void Start()
        {
            Server.Start();

            string msg = null;
            byte[] buff = null;

            while (true)
            {
                Console.Write("Waiting for a connection...");

                TcpClient client = Server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = client.GetStream();
                int i;
                while ((i = stream.Read(buff, 0, buff.Length)) != 0)
                {
                    msg = Encoding.ASCII.GetString(buff, 0, i);
                    Console.WriteLine("Received {0}", msg);
                    msg = msg.ToUpper();
                }
            }
        }
    }
}
