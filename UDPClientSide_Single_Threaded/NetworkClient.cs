using System.Net.Sockets;

namespace UDPClientSide
{
    public class NetworkClient
    {
        public UdpClient UdpClient;
        public readonly string ServerHostname;
        public readonly int ServerPort;
        
        public NetworkClient(string hostname, int port)
        {
            // Connection stuff
            ServerHostname = hostname;
            ServerPort = port;
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            UdpClient = new UdpClient(ServerHostname, ServerPort);

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            byte[] bytes = {
                0x00
            };

            UdpClient.Send(bytes, bytes.Length);

        }
    }
}