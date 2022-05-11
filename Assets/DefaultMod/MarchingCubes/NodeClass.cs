using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node
{
    /// <summary>
    /// ƒpƒ[
    /// 0‚©‚ç1‚Ü‚Å‚ÌŠÔ‚Å‚â‚é
    /// </summary>
    [Range(0,1)]
    public float p;

    public Node()
    {
        p = 0;
    }
}
