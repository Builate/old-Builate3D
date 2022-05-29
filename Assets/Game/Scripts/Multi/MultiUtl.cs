using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using LiteNetLib;
using LiteNetLib.Utils;

namespace KYapp.Builate
{
    public static class MultiUtil
    {
        /// <summary>
        /// Serverをスタートする関数
        /// </summary>
        /// <param name="Server">スタートするNetManagerのインスタンス</param>
        /// <param name="Port">使用するポート</param>
        /// <param name="UpdateTime">アップデートする時の時間（ミリ秒）</param>
        public static void StartServer(NetManager Server,int Port,int UpdateTime)
        {
            Debug.Log("StartServer");
            Server.Start(Port);
            Server.UpdateTime = UpdateTime;
        }

        /// <summary>
        /// Clientをスタートする関数
        /// </summary>
        /// <param name="Client">スタートするNetManagerのインスタンス</param>
        /// <param name="UpdateTime">アップデートするときの時間（ミリ秒）</param>
        public static void StartClient(NetManager Client, int UpdateTime)
        {
            Debug.Log("StartClient");
            Client.UnconnectedMessagesEnabled = true;
            Client.UpdateTime = UpdateTime;
            Client.Start();
        }
    }
}