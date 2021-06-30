namespace TCPClientSide_Single_Threaded_Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            NetworkClient c = new NetworkClient("127.0.0.1", 25565);
        }
    }
}