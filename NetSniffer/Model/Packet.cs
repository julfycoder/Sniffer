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
        protected int volume;
        public Packet(byte[] fullPacket, int volume) { this.fullPacket = fullPacket; this.volume=volume; }
        public abstract string GetFullPacket();
        public abstract IPAddress GetDestinationIPAddress();
        public abstract IPAddress GetSenderIPAddress();
        public abstract int GetVolume();
    }
}
