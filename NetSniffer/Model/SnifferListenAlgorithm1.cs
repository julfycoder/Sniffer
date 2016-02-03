using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace NetSniffer.Model
{
    class SnifferListenAlgorithm1 : SnifferListenAlgorithm
    {
        protected override void Bind(string address, int port)
        {
            this.listenSocket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
        }

        protected override void SetIOControl(System.Net.Sockets.IOControlCode ioControlCode, byte[] inOption, byte[] outOption)
        {
            this.listenSocket.IOControl(ioControlCode, inOption, outOption);
        }

        protected override void StartListen()
        {
            while (true)
            {
                byte[] buffer = new byte[1000000];
                int recv = this.listenSocket.Receive(buffer);
                DataIsReceivedUpdate(new SnifferPacket(buffer, recv));
            }
        }
    }
}
