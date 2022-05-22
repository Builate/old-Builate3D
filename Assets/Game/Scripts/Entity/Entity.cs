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
        public ETransform transform;
        public GameObject gameObject;
        private bool IsStart = true;

        public Entity(EntityBase entitybase)
        {
            EntityBase = entitybase;
            EntityID = Guid.NewGuid();
            EntityBase.entity = this;
        }

        public void Update()
        {
            if (IsStart)
            {
                EntityBase.Start();
                IsStart = false;
                transform.transform = gameObject.transform;
            }
            else
            {
                EntityBase.Update();
            }

            transform.SetTransform();
        }
    }

}