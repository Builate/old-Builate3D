using System.Collections;
using System.Collections.Generic;
using KYapp.Builate;
using UnityEngine;

namespace KYapp.Builate
{
    public class TestEntity : EntityBase
    {
        public override void Init()
        {

        }

        public override void Start()
        {
            GameObject.Destroy(gameObject);
            gameObject = GameObject.Instantiate(SystemModResource.Instance.TestEntity);
        }

        public override void Update()
        {
            
        }

        public override void Deserialize(DataReader dataReader)
        {

        }

        public override DataWriter Serialize()
        {
            return null;
        }
    }
}