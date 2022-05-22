using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KYapp.Builate;

namespace KYapp.Builate
{
    public enum SystemModEntityData
    {
        [EntityData(typeof(CameraEntity), "Camera")]
        CameraEntity,
        [EntityData(typeof(PlayerEntity), "Player")]
        PlayerEntity,
        [EntityData(typeof(TestEntity))]
        TestEntity,
    }

    public class SystemMod : Mod
    {
        public override void Init()
        {
            modID = "SystemMod";
        }

        public override void Start()
        {
            CreateEntity(0);
            CreateEntity(2);
        }
    }

}