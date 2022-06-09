using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace KYapp.Builate
{
    public class CameraEntity : EntityBase
    {
        public static CinemachineVirtualCamera CvCamera;
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

        public override void Deserialize(DataReader dataReader)
        {
            GameObject.Destroy(gameObject);
            gameObject = GameObject.Instantiate(SystemModResource.Instance.PlayerCam1);

            CvCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
            
            D_Transform(dataReader.GetBytes());
        }
        public override DataWriter Serialize()
        {
            DataWriter dw = new DataWriter();
            dw.Put(S_Transform());
            return dw;
        }
    }
}