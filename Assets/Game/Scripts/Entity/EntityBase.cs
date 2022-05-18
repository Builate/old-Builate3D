using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public abstract class EntityBase
    {
        /// <summary>
        /// 実体のgameObject
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// 全てのブロックで共有されるべきデータはEntityBaseDataを継承してこのDataに代入してください。
        /// </summary>
        public EntityBaseData Data = new EntityBaseData();

        /// <summary>
        /// EntityDataList追加時に呼ばれます。
        /// mesh,materialの設定などゲーム起動時に行いたい処理を書いてください。
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// entityの出現時に一度だけ呼ばれます。
        /// UnityのStart関数と同じように考えてください。
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// entity出現後毎フレーム呼ばれます。
        /// UnityのUpdate関数と同じように考えてください。
        /// </summary>
        public abstract void Update();
    }

    public class EntityBaseData
    {
        public string Name;
        public (string, int) EntityDataID;
        public Mesh mesh;
        public Material material;
        public Mod mod;
    }
}