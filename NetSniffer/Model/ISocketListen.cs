using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetSniffer.Model
{
    interface ISocketListen
    {
        void Listen(string address, int port);
    }
}
