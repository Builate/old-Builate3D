using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public MCTest mctest;
    public float Size;

    public Vector3[] NodeDir = new Vector3[]
    {
        new Vector3(1,0,0),
        new Vector3(-1,0,0),
        new Vector3(0,1,0),
        new Vector3(0,-1,0),
        new Vector3(0,0,1),
        new Vector3(0,0,-1),
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < mctest.map.GetLength(0); x++)
        {
            for (int y = 0; y < mctest.map.GetLength(1); y++)
            {
                for (int z = 0; z < mctest.map.GetLength(2); z++)
                {
                    //”ÍˆÍ“à‚Ì“_‚Í‚·‚×‚Ä1
                    if ((new Vector3(x, y, z) - transform.position).sqrMagnitude < (Vector3.one * Size).sqrMagnitude)
                    {
                        mctest.map[x, y, z].p += 1 * Time.deltaTime;
                    }
                }
            }
        }
    }
}
