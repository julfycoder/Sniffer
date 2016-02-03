using System;
using System.Net.Sockets;
using NetSniffer.Model;

namespace NetSniffer
{
    class Program
    {
        static int number = 0;
        static void Main(string[] args)
        {
            SnifferListenAlgorithm listenAlgo = new SnifferListenAlgorithm1();
            listenAlgo.DataIsReceived += WriteReceivedData;
            listenAlgo.Listen("192.168.1.2", 0);
        }
        static void WriteReceivedData(Model.Packet packet)
        {
            number++;
            string s = "", receivedData = packet.GetFullPacket();

            for (int i = 0; i < receivedData.Length; i++)
            {
                if (i < receivedData.Length - 1 && receivedData.Substring(i, 1) != "\a") s += receivedData.Substring(i, 1);
            }
            Console.WriteLine(new string('<', 60) + "\n" + number.ToString() + ") Time: |{0}|, From: {1}, To: {2}, packet:\n" + "{3}\n" + new string('>', 60),
                DateTime.Now, packet.GetSenderIPAddress(), packet.GetDestinationIPAddress(), s);
        }
    }
}
