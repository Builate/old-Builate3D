using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KYapp.Builate;

public class DefaultMod : Mod
{
    public override void Init()
    {
        modID = "DefaultMod";
        ModEntityDataList.Add(new PlayerEntity());
    }

    public override void Start()
    {
        CreateEntity(0);
    }
}
