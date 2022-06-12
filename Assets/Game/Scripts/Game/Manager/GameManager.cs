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
        public bool load;
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
            SystemMod sysMod = new SystemMod();
            sysMod.Init();
            ModLoader.SetEntityData(sysMod);
            if (load)
            {
                SaveLoad.Load();
            }
            else
            {
                sysMod.Start();
            }
        }
    }
}