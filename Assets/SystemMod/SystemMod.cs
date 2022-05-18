using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KYapp.Builate;

public class DefaultMod : Mod
{
    public override void Init()
    {
        modID = "SystemMod";
        ModEntityDataList.Add(new PlayerEntity());
        ModEntityDataList.Add(new CameraEntity());
    }

    public override void Start()
    {
        CreateEntity(0);
    }
}
