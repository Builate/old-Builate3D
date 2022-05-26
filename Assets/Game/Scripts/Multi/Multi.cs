using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

namespace KYapp.Builate
{
    public class Multi
    {
        public MultiClient MultiClient;
        private MultiServer MultiServer;
        public void Setup(string host, int port)
        {
            if (GameManager.Instance.IsServer)
            {
                MultiServer = new MultiServer(port, server_GetByte);
            }
            else
            {
                MultiClient = new MultiClient(host, port);
            }
        }

        public void Start()
        {
            if (GameManager.Instance.IsServer)
            {
                MultiServer.Start();
            }
            else
            {
                //初期同期
                byte[] res = MultiClient.Send(Encoding.UTF8.GetBytes("init"),ProtocolType.rudp);

                Debug.Log(Encoding.UTF8.GetString(res));
                
            }
        }
        public void Update()
        {
            
        }

        /// <summary>
        /// サーバーがリクエストを受けたときに対応する関数
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public byte[] server_GetByte(byte[] msg)
        {
            if (Encoding.UTF8.GetString(msg) == "init")
            {
                Console.WriteLine("init");
                return Encoding.UTF8.GetBytes("ret init");
            }

            return msg;
        }
    }
    /// <summary>
    /// Client用
    /// </summary>
    public class MultiClient
    {
        private string host;
        private int port;
        private UdpClient UdpClient;

        private TcpClient TcpClient;
        private NetworkStream NetworkStream;
        private bool isConnection;

        public MultiClient(string host,int port)
        {
            this.host = host;
            this.port = port;

            UdpClient = new UdpClient();
            UdpClient.Connect(host, port);

            TcpClient = new TcpClient(host, port);
            NetworkStream = TcpClient.GetStream();
            isConnection = true;
        }

        public byte[] Send(byte[] ms, ProtocolType type)
        {
            switch (type)
            {
                case ProtocolType.udp:
                    UdpClient.Send(ms, ms.Length);

                    IPEndPoint ServerEp = new IPEndPoint(IPAddress.Any, 0);
                    byte[] resbyte = UdpClient.Receive(ref ServerEp);

                    return resbyte;
                case ProtocolType.rudp:

                    NetworkStream.Write(ms, 0, ms.Length);
                    return null;
            }

            return null;
        }

        public void Close()
        {
            UdpClient.Close();
        }
    }
    /// <summary>
    /// Server用
    /// </summary>
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
        }

        public void Start()
        {
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

    public enum ProtocolType
    {
        udp,
        rudp,
    }
}