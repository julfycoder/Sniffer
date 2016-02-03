using System.Net.Sockets;

namespace NetSniffer.Model
{
    abstract class SocketBuilder
    {
        protected AddressFamily addressFamily;
        protected SocketType socketType;
        protected ProtocolType protocolType;
        
        public Socket CreateSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            SetAddressFamily(addressFamily);
            SetProtocolType(protocolType);
            SetSocketType(socketType);
            return new Socket(this.addressFamily, this.socketType, this.protocolType);
        }
        protected abstract void SetAddressFamily(AddressFamily addressFamily);
        protected abstract void SetSocketType(SocketType socketType);
        protected abstract void SetProtocolType(ProtocolType protocolType);
    }
}
