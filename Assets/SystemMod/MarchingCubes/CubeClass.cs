using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cube
{
    //Node‚Í‚±‚Á‚¿
    //    7-----6
    //   /|    /|
    //  4-+---5 |
    //  | 3---+-2
    //  |/    |/
    //  0-----1


    //Side‚Í‚±‚Á‚¿
    //ƒƒ‚Œ©‚ëƒo[ƒJ


    public Node[] Nodes = new Node[8];

    public Cube(Node[] nodes)
    {
        Nodes = nodes;
    }
}
