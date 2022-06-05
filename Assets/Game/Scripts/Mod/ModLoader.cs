using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

namespace KYapp.Builate
{
    public static class ModLoader
    {
        public static void SetEntityData<T>(T mod) where T : Mod
        {
            Array items = Type.GetType(mod.GetType().FullName + "EntityData", true).GetEnumValues();
            for (int i = 0; i < items.Length; i++)
            {
                EntityDataAttribute eda = items.GetValue(i).GetType().GetField(items.GetValue(i).ToString()).GetCustomAttribute<EntityDataAttribute>();
                EntityBase a = (EntityBase)eda.type.GetConstructor(Type.EmptyTypes).Invoke(null);

                a.Data.EntityDataID.Item2 = i;
                a.Data.EntityDataID.Item1 = mod.modID;
                a.Data.mod = mod;
                a.Data.isLocal = eda.isLocal;
                if (eda.name != null)
                {
                    a.Data.Name = eda.name;
                }
                else
                {
                    a.Data.Name = nameof(eda.type);
                }

                EntityData.AddEntityData(a);
            }
        }
    }
}