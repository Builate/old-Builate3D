using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KYapp.Builate;

public class SystemMod : Mod
{
    public override void Init()
    {
        modID = "SystemMod";
        ModEntityDataList.Add(new CameraEntity());
        ModEntityDataList.Add(new PlayerEntity());
    }

    public override void Start()
    {
        CreateEntity(0);
    }
}
