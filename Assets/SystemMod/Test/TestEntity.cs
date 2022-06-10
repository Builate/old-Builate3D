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
            GameObject go = GameObject.Instantiate(SystemModResource.Instance.TestEntity);
            go.transform.parent = gameObject.transform;
            go.transform.localPosition = Vector3.zero;
        }

        public override void Update()
        {
            
        }

        public override void Deserialize(DataReader dataReader)
        {
            D_Transform(dataReader.GetBytes());
            GameObject go = GameObject.Instantiate(SystemModResource.Instance.TestEntity);
            go.transform.parent = gameObject.transform;
            go.transform.localPosition = Vector3.zero;
        }
        public override DataWriter Serialize()
        {
            DataWriter dw = new DataWriter();
            dw.Put(S_Transform());
            return dw;
        }
    }
}