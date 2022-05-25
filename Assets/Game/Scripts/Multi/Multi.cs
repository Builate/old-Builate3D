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
        private UdpClient UdpClient;

        public MultiClient(string host,int port)
        {
            this.host = host;
            this.port = port;

            UdpClient = new UdpClient();
            UdpClient.Connect(host, port);
        }

        public byte[] Send(byte[] ms)
        {
            UdpClient.Send(ms, ms.Length);

            IPEndPoint ServerEp = new IPEndPoint(IPAddress.Any, 0);
            byte[] resbyte = UdpClient.Receive(ref ServerEp);

            return resbyte;
        }

        public void Close()
        {
            UdpClient.Close();
        }
    }
    public class MultiServer
    {
        private int port;
        private UdpClient UdpClient;
        private Server_GetByte server_GetByte;

        public MultiServer(int port, Server_GetByte server_GetByte)
        {
            this.port = port;
            this.server_GetByte = server_GetByte;
            UdpClient = new UdpClient(port);
            UdpClient.BeginReceive(Receive, UdpClient);
        }

        public void Receive(IAsyncResult result)
        {
            UdpClient getUdp = (UdpClient)result.AsyncState;
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 0);

            byte[] getByte = getUdp.EndReceive(result, ref ipEnd);

            byte[] msg = server_GetByte(getByte);

            getUdp.Send(msg, msg.Length, ipEnd);
            getUdp.BeginReceive(Receive, getUdp);
        }

        public void Close()
        {
            UdpClient.Close();
        }
    }

    public delegate byte[] Server_GetByte(byte[] ClientMsg);
}