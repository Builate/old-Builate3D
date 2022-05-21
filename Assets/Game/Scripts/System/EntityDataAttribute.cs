using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class EntityDataAttribute : Attribute
    {
        public Type type;
        public string name;

        public EntityDataAttribute(Type type, string name)
        {
            this.type = type;
            this.name = name;
        }
    }
}