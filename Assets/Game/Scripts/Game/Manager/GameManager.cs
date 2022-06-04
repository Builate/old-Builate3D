using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace KYapp.Builate
{
    public class GameManager : Singleton<GameManager>
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
                    //ServerÉIÉìÉäÅ[
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
            
            DebugModLoad();
        }

        void Update()
        {
            if (isMulti)
            {
                
            }
            EntityData.Update();
        }

        public void DebugModLoad()
        {
            SystemMod sysmod = new SystemMod();
            sysmod.Init();
            ModLoader.SetEntityData(sysmod);
            sysmod.Start();
        }
    }
}