using System;
using System.Net;
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
            listenAlgo.Listen(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(), 666);
            Console.WriteLine("Hello, world! Merry Christmass, And happy new year!");
        }
        static void WriteReceivedData(Model.Packet packet)
        {
            number++;
            string s = "", receivedData = packet.GetFullPacket();

            for (int i = 0; i < receivedData.Length; i++)
            {
                if (i < receivedData.Length - 1 && receivedData.Substring(i, 1) != "\a") s += receivedData.Substring(i, 1);
            }
            Console.WriteLine(new string('<', 70) + "\n" + number.ToString() + ") Time: |{0}|, From: {1}, To: {2}, protocol_type: {3}, sender_port: {4}, destination_port: {5}, packet:\n" + "{6}\n" + new string('>', 70),
                DateTime.Now, packet.GetSenderIPAddress(), packet.GetDestinationIPAddress(), packet.GetProtocolType(), packet.GetSenderPort(), packet.GetDestinationPort(), s);
        }
    }
}
