using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace UDPServerSide
{
    public class NetworkServer
    {
        public TcpListener TcpListener;
        public readonly int ServerPort;

        public List<TcpClient> TcpClients = new();
        
        public NetworkServer(int port)
        {
            // Connection stuff
            ServerPort = port;
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            TcpListener = new TcpListener(IPAddress.Any, port);
            TcpListener.Start();

            while (true)
            {
                if (TcpListener.Pending())
                {
                    HandleConnection();
                }

                CheckForData();

            }
            
        }

        private void CheckForData()
        {
            foreach (var client in TcpClients)
            {
                int messageLength = client.Available;
                if (messageLength > 0)
                {
                    // there is one!  get it
                    byte[] msgBuffer = new byte[messageLength];
                    client.GetStream().Read(msgBuffer, 0, msgBuffer.Length);     // Blocks

                    Console.WriteLine("Received data");
                    
                }
            }
        }

        private void HandleConnection()
        {
            var newClient = TcpListener.AcceptTcpClient();      // Blocks
            
            // Print some info
            var endPoint = newClient.Client.RemoteEndPoint;
            Console.WriteLine("Handling a new client from {0}...", endPoint);

            TcpClients.Add(newClient);
        }
    }
}