using System;
using UDPServerSide;

namespace TCPServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            NetworkServer s = new NetworkServer(25565);
        }
    }
}