using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

namespace KYapp.Builate
{
    public static class Multi
    {
        public static MultiData MultiData;
        public static TcpClient tcpClient;
        public static UdpClient udpClient;

        public static void Init(MultiData multiData)
        {
            MultiData = multiData;

        }
    }
    
    [Serializable]
    public class MultiData
    {
        public string ip;
        public int port;
    }
}