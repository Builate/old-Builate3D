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
        void Start()
        {
            DebugModLoad();
        }

        void Update()
        {
            EntityData.Update();
            if (Input.GetKeyDown(KeyCode.P))
            {
                SaveLoad.Save();
            }
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