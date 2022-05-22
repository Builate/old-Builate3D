using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class ETransform
    {
        public DVector3 position;
        public Quaternion rotation;
        public Vector3 scale;
        public Transform transform;

        public void SetTransform()
        {
            SetPosition();
            SetRotation();
            SetScale();
        }
        private void SetPosition()
        {
            transform.position =
                new Vector3(
                    (float)(position.x - EntityData.Origin.x),
                    (float)(position.y - EntityData.Origin.y),
                    (float)(position.z - EntityData.Origin.z)
                );
        }
        private void SetRotation()
        {
            transform.rotation = rotation;
        }
        private void SetScale()
        {
            transform.localScale = scale;
        }
    }
}