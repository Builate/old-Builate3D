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
        
        public NetworkManager networkManager;
        void Start()
        {
            if (isMulti)
            {
                if (isServer)
                {
                    //Serverオンリー
                    networkManager.StartServer();
                    networkManager.serverTickRate = 30;
                }
                else
                {
                    //Client + ip
                    networkManager.StartClient();
                    networkManager.networkAddress = networkAddress;
                    networkManager.serverTickRate = 0;
                }
            }
            else
            {
                //ローカルプレイ
                networkManager.StartHost();
            }
            
            DebugModLoad();
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