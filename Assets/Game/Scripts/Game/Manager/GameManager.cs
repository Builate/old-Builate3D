using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class GameManager : Singleton<GameManager>
    {
        // Start is called before the first frame update
        void Start()
        {
            SystemMod sysmod = new SystemMod();
            sysmod.Init();
            ModLoader.SetEntityData(sysmod);
            sysmod.Start();
        }

        // Update is called once per frame
        void Update()
        {
            EntityData.Update();
        }
    }
}