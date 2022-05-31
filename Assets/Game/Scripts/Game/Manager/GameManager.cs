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

        public Multi Multi;

        void Start()
        {
            if (IsMulti)
            {
                Multi = new Multi(IsServer, "192.168.11.51", 62711);
                Multi.Start();
            }
            DebugModLoad();
        }

        void Update()
        {
            if (IsMulti)
            {
                Multi.Update();
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