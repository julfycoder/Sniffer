using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NetSniffer.Model
{
    abstract class Packet
    {
        protected byte[] fullPacket;
        public Packet(byte[] fullPacket, int volume) { this.fullPacket = fullPacket; this.Volume=volume; }
        public abstract string GetFullPacket();
        public abstract IPAddress GetDestinationIPAddress();
        public abstract IPAddress GetSenderIPAddress();
        public abstract int Volume { get; protected set; }
        public abstract int GetProtocolType();
        public abstract byte GetSenderPort();
        public abstract byte GetDestinationPort();
    }
}
