using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class TerrainGenerator : MonoBehaviour
    {
        public Node[,,] map = new Node[10, 10, 10];
        public float[,] heightmap = new float[10, 10];

        public MeshFilter mf;
        public MeshCollider mc;

        // Start is called before the first frame update
        void Start()
        {


            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        map[x, y, z] = new Node();
                    }
                }
            }

            map[4, 4, 4].p = 1;
            map[4, 5, 4].p = 1;
        }

        // Update is called once per frame
        void Update()
        {
            Mesh mesh = MarchingCubes.GetMesh(map, 0.5f);
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mf.sharedMesh = mesh;
            mc.sharedMesh = mesh;
        }
    }

}