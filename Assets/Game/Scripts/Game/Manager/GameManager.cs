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
            DataWriter dw = new DataWriter();
            dw.Put(true);
            dw.Put(new Vector2(100, 200));
            dw.Put(40.2f);
            dw.Put(0);
            dw.Put("aiueo‚ ‚¢‚¤‚¦‚¨1234567890");
            byte[] data = dw.GetData();
            Debug.Log(string.Join(',',data));

            DataReader dr = new DataReader(data);
            Debug.Log(dr.GetBool());
            Debug.Log(dr.GetVector2());
            Debug.Log(dr.GetFloat());
            Debug.Log(dr.GetInt());
            Debug.Log(dr.GetString());


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