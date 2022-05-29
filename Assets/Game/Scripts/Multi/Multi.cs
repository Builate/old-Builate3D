using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;
using System.Net;
using System.Net.Sockets;

namespace KYapp.Builate
{
    public class Multi : INetEventListener, INetLogger
    {
        public NetManager NetManager;
        public NetDataWriter NetDataWriter;

        public bool IsServer;
        public string Address;
        public int Port;

        public Multi(bool IsServer, string Address, int Port)
        {
            this.IsServer = IsServer;
            this.Address = Address;
            this.Port = Port;
            NetDataWriter = new NetDataWriter();
            NetDebug.Logger = this;

        }

        public void Start()
        {
            if (IsServer)
            {
                NetManager = new NetManager(this);
                MultiUtil.StartServer(NetManager, Port, 15);
            }
            else
            {
                NetManager = new NetManager(this);
                MultiUtil.StartClient(NetManager, 15);
                NetManager.Connect(Address, Port,"Builate");
            }
        }
        public void Update()
        {
            NetManager.PollEvents();
        }


        public void OnConnectionRequest(ConnectionRequest request)
        {
            request.AcceptIfKey("Builate");
        }

        public void OnNetworkError(IPEndPoint endPoint, SocketError socketError)
        {
        
        }

        public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
        {
        
        }

        public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
        {
            
        }

        public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
        {
            Debug.Log(remoteEndPoint.ToString());
        }

        public void OnPeerConnected(NetPeer peer)
        {
            Debug.Log("Connected!!! : " + peer.EndPoint);
        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Debug.LogError(disconnectInfo.Reason.ToString() + " : " + peer.EndPoint);
        }

        public void WriteNet(NetLogLevel level, string str, params object[] args)
        {
            Debug.Log(str);
        }
    }
}