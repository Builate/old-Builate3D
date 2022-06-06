using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

namespace KYapp.Builate
{
    public class NetworkManager : NetworkManagerSingleton<NetworkManager>
    {
        public override void OnClientConnect()
        {
            base.OnClientConnect();
            GameManager.Instance.DebugModLoad();
        }
    }
}