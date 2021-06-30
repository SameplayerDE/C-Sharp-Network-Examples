using System.Net.Sockets;

namespace TCPClientSide_Single_Threaded_Async
{
    public class NetworkClient
    {
        public TcpClient TcpClient;
        public readonly string ServerHostname;
        public readonly int ServerPort;
        
        public NetworkClient(string hostname, int port)
        {
            // Connection stuff
            ServerHostname = hostname;
            ServerPort = port;
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            TcpClient = new TcpClient(ServerHostname, ServerPort);

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            byte[] bytes = {
                0x00
            };

            TcpClient.GetStream().Write(bytes); //writes data to stream
            TcpClient.GetStream().Flush(); //sends data

        }
    }
}