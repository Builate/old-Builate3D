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
            BaseMod baseMod = new BaseMod();
            sysMod.Init();
            baseMod.Init();
            ModLoader.SetEntityData(sysMod);
            ModLoader.SetEntityData(baseMod);
            if (load)
            {
                SaveLoad.Load();
            }
            else
            {
                sysMod.Start();
                baseMod.Start();
            }
        }
    }
}