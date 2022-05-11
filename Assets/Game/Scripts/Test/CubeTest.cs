using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CubeTest : MonoBehaviour
{
    [Range(0,1)]
    public float Threshold;
    public MeshFilter mf;

    public Cube cube;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mf.sharedMesh = MarchingCubes.GetCubeMesh(cube,Threshold);
    }

    [ContextMenu("ResetCube")]
    public void CubeReset()
    {
        Node[] nodes = new Node[8];

        cube = new Cube(nodes);
    }
}
