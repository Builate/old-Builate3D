using System;
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
        public NetPeer NetPeer;

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
            NetManager = new NetManager(this);
            if (IsServer)
            {   
                MultiUtil.StartServer(NetManager, Port, 15);
            }
            else
            {
                MultiUtil.StartClient(NetManager, 15);
                Connect();
            }
        }
        public void Update()
        {
            NetManager.PollEvents();
            NetDataWriter.Reset();

            //サーバーにつながっているなら
            if (NetPeer?.ConnectionState == ConnectionState.Connected)
            {
                if (IsServer)
                {

                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.H))
                    {

                        List<byte> data = new List<byte>();
                        foreach (var item in EntityData.EntityList.Keys)
                        {
                            DataWriter dw = new DataWriter();
                            dw.Put(item.ToByteArray());
                            dw.Put(EntityData.EntityList[item].EntityBase.Serialize());
                            data.AddRange(dw.GetData());
                        }
                        NetDataWriter.PutBytesWithLength(data.ToArray());

                        Send(DeliveryMethod.ReliableSequenced);
                    }
                }
            }
        }

        public void Send(DeliveryMethod deliveryMethod)
        {
            NetPeer.Send(NetDataWriter.Data, deliveryMethod);
        }

        public void Connect()
        {
            NetManager.Connect(Address, Port, "Builate");
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
            DataReader dr = new DataReader(reader.GetBytesWithLength());
            if (IsServer)
            {
                Debug.Log(new Guid(dr.GetBytes()));
                Debug.Log(dr.GetVector3());
                Debug.Log(dr.GetVector3());
            }
            else
            {

            }
        }

        public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType)
        {
            Debug.Log(remoteEndPoint.ToString());
            if (IsServer)
            {
                
            }
            else
            {
                Connect();
            }
        }

        public void OnPeerConnected(NetPeer peer)
        {
            Debug.Log("Connected!!! : " + peer.EndPoint);
            NetPeer = peer;
            if (IsServer)
            {

            }
            else
            {

            }
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