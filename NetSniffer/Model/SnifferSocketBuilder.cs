
namespace NetSniffer.Model
{
    class SnifferSocketBuilder:SocketBuilder
    {
        protected override void SetAddressFamily(System.Net.Sockets.AddressFamily addressFamily)
        {
            this.addressFamily = addressFamily;
        }

        protected override void SetSocketType(System.Net.Sockets.SocketType socketType)
        {
            this.socketType = socketType;
        }

        protected override void SetProtocolType(System.Net.Sockets.ProtocolType protocolType)
        {
            this.protocolType = protocolType;
        }
    }
}
