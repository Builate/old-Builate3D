using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public enum BaseModEntityData
    {
        [EntityData(typeof(TestItem),"TestItem")]
        TestItem,
    }
    
    public class BaseMod : Mod
    {
        public override void Init()
        {
            modID = "BaseMod";
        }

        public override void Start()
        {
            
        }
    }
}