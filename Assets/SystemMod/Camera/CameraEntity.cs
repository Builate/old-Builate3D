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
            entity.Destroy();
            entity.SetGameobject(GameObject.Instantiate(SystemModResource.Instance.PlayerCam1));

            Entity PlayerEntity = Data.mod.CreateEntity(1);
            entity.GetComponent<CinemachineVirtualCamera>().Follow = PlayerEntity.EntityBase.entity.gameObject.transform;
        }

        public override void Update()
        {

        }
    }
}