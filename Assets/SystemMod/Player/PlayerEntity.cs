using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class PlayerEntity : EntityBase
    {
        public override void Init()
        {
            Data.Name = "PlayerEntity";
        }
        public override void Start()
        {
            CharacterController cc = gameObject.AddComponent<CharacterController>();
            PlayerController pc = gameObject.AddComponent<PlayerController>();
            GameObject go = GameObject.Instantiate(SystemModResource.Instance.PlayerModelPrefab);
            go.transform.SetParent(gameObject.transform);
            go.transform.localPosition = Vector3.zero;

            cc.slopeLimit = 45;
            cc.stepOffset = 0.3f;
            cc.skinWidth = 0.08f;
            cc.minMoveDistance = 0;
            cc.center = new Vector3(0, 0, 0);
            cc.radius = 0.5f;
            cc.height = 2;

            pc.WalkSpeed = 7;
            pc.DushSpeed = 14;
            pc.GravityScale = 40f;
            pc.JumpForce = 10;
            pc.Velocity = new Vector3(0, 0, 0);

            gameObject.transform.position = new Vector3(0, 10, 0);

            Data.mod.CreateEntity(1).EntityBase.gameObject.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = gameObject.transform;
        }

        public override void Update()
        {

        }
    }
}