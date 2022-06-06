using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace KYapp.Builate
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public bool isMulti;
        public bool isServer;
        public string networkAddress;
        
        void Start()
        {
            if (isMulti)
            {
                if (isServer)
                {
                    //Serverオンリー
                    NetworkManager.Instance.serverTickRate = 30;
                    NetworkManager.Instance.StartServer();
                }
                else
                {
                    //Client + ip
                    NetworkManager.Instance.networkAddress = networkAddress;
                    NetworkManager.Instance.serverTickRate = 0;
                    NetworkManager.Instance.StartClient();
                }
            }
            else
            {
                //ローカルプレイ
                NetworkManager.Instance.serverTickRate = 0;
                NetworkManager.Instance.StartHost();
            }
        }

        void Update()
        {
            EntityData.Update();
        }

        public void DebugModLoad()
        {
            SystemMod sysmod = new SystemMod();
            sysmod.Init();
            ModLoader.SetEntityData(sysmod);
            sysmod.Start();
        }

        public void OnConnectedToServer()
        {
            Debug.Log("aaaa");
        }
    }
}