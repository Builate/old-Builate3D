using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            gameObject = GameObject.Instantiate(SystemModResource.Instance.PlayerCam1);
        }

        public override void Update()
        {

        }
    }

}