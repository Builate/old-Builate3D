using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

namespace KYapp.Builate
{
    public class Client : NetworkBehaviourSingleton<Client>
    {
        public void CreateEntity((string, int) id)
        {
            CmdCreateEntity(id.Item1, id.Item2);
        }
        [Command]
        private void CmdCreateEntity(string id1, int id2)
        {
            Debug.Log((id1,id2));
        }
    }
}