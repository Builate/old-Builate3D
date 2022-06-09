using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class GameManager : Singleton<GameManager>
    {
        public bool IsMulti;
        public bool IsServer;
        void Start()
        {
            if (IsMulti)
            {
                
            }
            DebugModLoad();
        }

        void Update()
        {
            if (IsMulti)
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