using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class Entity
    {
        public Guid EntityID;
        public EntityBase EntityBase;
        private bool IsStart = true;

        public Entity(EntityBase entitybase)
        {
            EntityBase = entitybase;
            EntityID = Guid.NewGuid();
            EntityBase.gameObject = new GameObject(EntityBase.Data.Name);
        }

        public void Update()
        {
            if (IsStart)
            {
                EntityBase.Start();
                IsStart = false;
            }
            else
            {
                EntityBase.Update();
            }
        }
    }

}