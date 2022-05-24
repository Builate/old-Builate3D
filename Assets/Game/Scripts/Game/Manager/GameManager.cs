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
        public MultiData MultiData;

        // Start is called before the first frame update
        void Start()
        {
            if (IsMulti)
            {

            }
            DebugModLoad();
        }

        // Update is called once per frame
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
    }
}