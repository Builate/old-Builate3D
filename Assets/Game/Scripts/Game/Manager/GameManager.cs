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
            Mod sysmod = new SystemMod();
            sysmod.Init();
            sysmod.SetEntityData();
            sysmod.Start();
        }

        // Update is called once per frame
        void Update()
        {
            EntityData.Update();
        }
    }
}