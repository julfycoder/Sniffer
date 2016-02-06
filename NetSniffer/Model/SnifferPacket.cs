using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetSniffer.Model
{
    class SnifferPacket:Packet
    {
        public SnifferPacket(byte[] fullPacket,int recv) : base(fullPacket,recv) { }
        public override string GetFullPacket()
        {
            return Encoding.UTF8.GetString(fullPacket, 0, volume);
        }
        public override IPAddress GetDestinationIPAddress()
        {
            return new IPAddress((long)BitConverter.ToUInt32(fullPacket, 16));
        }
        public override IPAddress GetSenderIPAddress()
        {
            return new IPAddress((long)BitConverter.ToUInt32(fullPacket, 12));
        }
        public override int GetProtocolType()
        {
            return (int)fullPacket[9];
        }
        public override int GetVolume()
        {
            return volume;
        }
    }
}
