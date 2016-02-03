using System;
using System.Net.Sockets;

namespace NetSniffer
{
    class Program
    {
        static int number = 0;
        static void Main(string[] args)
        {
            Model.SnifferListenAlgorithm listenAlgo = new Model.SnifferListenAlgorithm1();
            listenAlgo.DataIsReceived += WriteReceivedData;
            listenAlgo.Listen("192.168.1.2", 0);
        }
        static void WriteReceivedData(Model.Packet packet)
        {
            number++;
            string s = "", receivedData = packet.GetFullPacket();

            //string key = "";
            //bool keyReceived = false;
            for (int i = 0; i < receivedData.Length; i++)
            {
                if (i < receivedData.Length - 1 && receivedData.Substring(i, 1) != "\a") s += receivedData.Substring(i, 1);

                //if (i < receivedData.Length - 5 && receivedData.Substring(i, 5) == "&key=") keyReceived = true;
                //if (keyReceived) key += receivedData.Substring(i, 1);
            }
            Console.WriteLine(new string('<', 60) + "\n" + number.ToString() + ") Time: |{0}|, From: {1}, To: {2}, packet:\n" + "{3}\n" + new string('>', 60),
                DateTime.Now, packet.GetSenderIPAddress(), packet.GetDestinationIPAddress(), s);
            //Console.WriteLine(key);
        }
    }
}
