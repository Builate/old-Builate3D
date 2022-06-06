using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace KYapp.Builate
{
    public class CameraEntity : EntityBase
    {
        public Guid PlayerGuid = Guid.NewGuid();
        
        public override void Init()
        {
            Data.Name = "CameraEntity";
        }

        public override void Start()
        {
            GameObject.Destroy(gameObject);
            gameObject = GameObject.Instantiate(SystemModResource.Instance.PlayerCam1);
            Debug.Log(PlayerGuid);
            Data.mod.CreateEntity(1, PlayerGuid);
        }

        public override void Update()
        {
            if (EntityData.EntityList.ContainsKey(PlayerGuid))
            {
                gameObject.GetComponent<CinemachineVirtualCamera>().Follow =
                    EntityData.EntityList[PlayerGuid].EntityBase.gameObject.transform;
            }
        }

        public override void Deserialize(DataReader dataReader)
        {
            gameObject.transform.position = dataReader.GetVector3();
            gameObject.transform.rotation = Quaternion.Euler(dataReader.GetVector3());
        }
        public override DataWriter Serialize()
        {
            DataWriter dw = new DataWriter();
            dw.Put(gameObject.transform.position);
            dw.Put(gameObject.transform.rotation.eulerAngles);
            return dw;
        }
    }
}