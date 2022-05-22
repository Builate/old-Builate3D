using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class GameManager : Singleton<GameManager>
    {
        public Vector3 origin;

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
            EntityData.Origin = new DVector3(origin);
            EntityData.Update();
        }
    }
}