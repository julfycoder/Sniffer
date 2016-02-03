using System.Net.Sockets;

namespace NetSniffer.Model
{
    abstract class SnifferListenAlgorithm:ISocketListen
    {
        protected Socket listenSocket;
        public delegate void ListenDelegate(Packet packet);
        public event ListenDelegate DataIsReceived;
        protected void DataIsReceivedUpdate(Packet packet)
        {
            if (DataIsReceived != null) DataIsReceived(packet);
        }
        public void Listen(string address, int port)
        {
            this.listenSocket = new SnifferSocketBuilder().CreateSocket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Unspecified);
            Bind(address, port);
            SetIOControl(IOControlCode.ReceiveAll, new byte[4] { 1, 0, 0, 0 }, new byte[4] { 1, 0, 0, 0 });
            StartListen();
        }
        protected abstract void Bind(string address, int port);
        protected abstract void SetIOControl(IOControlCode ioControlCode, byte[] inOption, byte[] outOption);
        protected abstract void StartListen();
    }
}
