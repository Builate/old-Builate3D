using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public abstract class ItemBase : EntityBase
    {
        public override void Init()
        {
            
        }

        public override void Start()
        {
            MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshCollider.sharedMesh = CreateCube();
            
            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        private Mesh CreateCube () {
            Vector3[] vertices = {
                new Vector3 (0, 0, 0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, 1, 0),
                new Vector3 (0, 1, 0),
                new Vector3 (0, 1, 1),
                new Vector3 (1, 1, 1),
                new Vector3 (1, 0, 1),
                new Vector3 (0, 0, 1),
            };

            int[] triangles = {
                0, 2, 1, //face front
                0, 3, 2,
                2, 3, 4, //face top
                2, 4, 5,
                1, 2, 5, //face right
                1, 5, 6,
                0, 7, 4, //face left
                0, 4, 3,
                5, 4, 7, //face back
                5, 7, 6,
                0, 6, 7, //face bottom
                0, 1, 6
            };
			
            Mesh mesh = gameObject.GetComponent<MeshFilter> ().mesh;
            mesh.Clear ();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.Optimize ();
            mesh.RecalculateNormals ();

            return mesh;
        }
    }
}