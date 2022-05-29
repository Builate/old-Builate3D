using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCTest : MonoBehaviour
{
    public int Size;

    public Node[,,] map = new Node[20, 20, 20];

    public MeshFilter mf;
    public MeshCollider mc;

    [Range(0f,1f)]
    public float threshold;
    // Start is called before the first frame update
    void Start()
    {

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int z = 0; z < map.GetLength(2); z++)
                {
                    map[x, y, z] = new Node();
                }
            }
        }

        map[4, 4, 4].p = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = MarchingCubes.GetMesh(map,threshold);
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mf.sharedMesh = mesh;
        mc.sharedMesh = mesh;
    }
}
