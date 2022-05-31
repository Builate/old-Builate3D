using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace KYapp.Builate
{
    public class CameraEntity : EntityBase
    {
        public override void Init()
        {
            Data.Name = "CameraEntity";
        }

        public override void Start()
        {
            GameObject.Destroy(gameObject);
            gameObject = GameObject.Instantiate(SystemModResource.Instance.PlayerCam1);

            Entity PlayerEntity = Data.mod.CreateEntity(1);
            gameObject.GetComponent<CinemachineVirtualCamera>().Follow = PlayerEntity.EntityBase.gameObject.transform;
        }

        public override void Update()
        {

        }

        public override DataWriter Deserialize()
        {
            return null;
        }
        public override void Serialize(DataReader dataReader)
        {

        }
    }
}