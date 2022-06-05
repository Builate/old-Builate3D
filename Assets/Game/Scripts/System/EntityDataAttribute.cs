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
        public bool isLocal;

        public EntityDataAttribute(Type type, string name, bool isLocal)
        {
            this.type = type;
            this.name = name;
            this.isLocal = isLocal;
        }
        public EntityDataAttribute(Type type, bool isLocal)
        {
            this.type = type;
            this.name = null;
            this.isLocal = isLocal;
        }
        public EntityDataAttribute(Type type, string name)
        {
            this.type = type;
            this.name = name;
            this.isLocal = false;
        }
        public EntityDataAttribute(Type type)
        {
            this.type = type;
            this.name = null;
            this.isLocal = false;
        }
    }
}