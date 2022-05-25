using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

namespace KYapp.Builate
{
    public class MultiClient
    {
        private string host;
        private int port;
        private UdpClient client;

        public MultiClient(string host,int port)
        {
            this.host = host;
            this.port = port;

            client = new UdpClient();
            client.Connect(host, port);
        }

        public byte[] Send(byte[] ms)
        {
            client.Send(ms, ms.Length);

            IPEndPoint ServerEp = new IPEndPoint(IPAddress.Any, 0);
            byte[] resbyte = client.Receive(ref ServerEp);

            return resbyte;
        }
    }
    public class MultiServer
    {

    }
}