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
                Console.Clear();
                Console.CursorVisible = false;
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
                    var dw = new DataWriter();

                    dw.Put(EntityData.EntityList.Count);

                    foreach (var item in EntityData.EntityList.Keys)
                    {
                        
                        dw.Put(item.ToByteArray());
                        dw.Put(EntityData.EntityList[item].EntityBase.Serialize());
                        
                    }
                    NetDataWriter.PutBytesWithLength(dw.GetData());

                    Send(DeliveryMethod.ReliableSequenced);
                    
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
            Console.SetCursorPosition(0, 0);
            DataReader dr = new DataReader(reader.GetBytesWithLength());
            if (IsServer)
            {
                int c = dr.GetInt();
                for (int i = 0; i < c; i++)
                {
                    Debug.Log(EntityData.EntityList.ContainsKey(new Guid(dr.GetBytes())));
                    Debug.Log(dr.GetVector3());
                    Debug.Log(dr.GetVector3());
                }
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