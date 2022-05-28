using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace KYapp.Builate
{
    public class MultiUtil
    {
        public IPEndPoint EndPoint;
        public UdpClient UdpClient;

        public receive func;

        public delegate void receive(IAsyncResult result);

        public void Init(IPEndPoint endPoint)
        {
            EndPoint = endPoint;
            UdpClient = new UdpClient();
        }

        public void Connect(receive func)
        {
            UdpClient.Connect(EndPoint);
            UdpClient.BeginReceive(Receive,EndPoint);
            this.func = func;
        }

        /// <summary>
        /// データを送る時に使用する関数
        /// </summary>
        /// <param name="data"></param>
        public void Send(byte[] data)
        {
            UdpClient.Send(data, data.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        private void Receive(IAsyncResult result)
        {
            func(result);
        }
    }
}