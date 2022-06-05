using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KYapp.Builate;

namespace KYapp.Builate
{
    public enum SystemModEntityData
    {
        [EntityData(typeof(CameraEntity), "Camera",true)]
        CameraEntity,
        [EntityData(typeof(PlayerEntity), "Player", false)]
        PlayerEntity,
    }

    public class SystemMod : Mod
    {
        public override void Init()
        {
            modID = "SystemMod";
        }

        public override void Start()
        {
            if (!GameManager.Instance.isServer)
            {
                CreateEntity(0);
            }
        }
    }
}