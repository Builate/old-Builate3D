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

        public Entity(EntityBase entitybase,string name = "")
        {
            if (name == "")
            {
                _Entity(entitybase, Guid.NewGuid(), new GameObject(entitybase.Data.Name));
            }
            else
            {
                _Entity(entitybase, Guid.NewGuid(), new GameObject(name));
            }
        }

        public Entity(EntityBase entitybase , Guid EntityID, string name = "")
        {
            if (name == "")
            {
                _Entity(entitybase, EntityID, new GameObject(entitybase.Data.Name));
            }
            else
            {
                _Entity(entitybase, EntityID, new GameObject(name));
            }
        }
        public Entity(EntityBase entitybase,GameObject gameObject,string name = "")
        {
            if (name == "")
            {
                _Entity(entitybase, Guid.NewGuid(), gameObject);
            }
            else
            {
                _Entity(entitybase, Guid.NewGuid(), gameObject);
            }
        }

        public Entity(EntityBase entitybase, GameObject gameObject, Guid EntityID, string name = "")
        {
            if (name == "")
            {
                _Entity(entitybase, EntityID, gameObject);
            }
            else
            {
                _Entity(entitybase, EntityID, gameObject);
            }
        }

        public Entity(EntityBase EntityBase, Guid EntityID, GameObject gameObject)
        {
            _Entity(EntityBase, EntityID, gameObject);
        }

        public void _Entity(EntityBase EntityBase, Guid EntityID, GameObject gameObject)
        {
            this.EntityBase = EntityBase;
            this.EntityID = EntityID;
            this.EntityBase.gameObject = gameObject;
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