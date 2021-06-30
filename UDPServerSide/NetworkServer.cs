using System;
using System.Net;
using System.Net.Sockets;

namespace UDPServerSide
{
    public class NetworkServer
    {
        public UdpClient UdpClient;
        public readonly int ServerPort;
        
        public NetworkServer(int port)
        {
            // Connection stuff
            ServerPort = port;
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            UdpClient = new UdpClient(ServerPort, AddressFamily.InterNetwork);

            while (true)
            {
                if (UdpClient.Available > 0)
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
                    byte[] data = UdpClient.Receive(ref ep);

                    Console.WriteLine("Received data");
                }

            }
            
        }
    }
}