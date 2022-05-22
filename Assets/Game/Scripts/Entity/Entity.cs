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
            gameObject = new GameObject(EntityBase.Data.Name);
            transform = new ETransform();
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

        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }

        public void SetGameobject(GameObject obj)
        {
            gameObject = obj;
        }
        public C AddComponent<C>() where C : Component
        {
            return gameObject.AddComponent<C>();
        }
        public C GetComponent<C>() where C : Component
        {
            return gameObject.GetComponent<C>();
        }
    }

}