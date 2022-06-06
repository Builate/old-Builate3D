using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    /// <summary>
    /// 全てのModが継承するクラス
    /// EntityDataを宣言するにはEntityDataというEnum型の変数を定義します。
    /// </summary>
    public abstract class Mod
    {
        /// <summary>
        /// modIDは一意である必要があります
        /// </summary>
        public string modID;

        /// <summary>
        /// ワールドのロード時に呼ばれる設定用メソッドです
        /// ここでModのIDの設定をしてください
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// ワールドのロード完了時に呼ばれるセットアップ用メソッドです
        /// ここでオブジェクトの生成などをしてください
        /// </summary>
        public abstract void Start();


        public void CreateEntity(int id)
        {
            EntityData.CreateEntity((modID, id));
        }

        public void CreateEntity(string modId,int id)
        {
            EntityData.CreateEntity((modId, id));
        }
        public void CreateEntity(int id,Guid guid)
        {
            EntityData.CreateEntity((modID, id), guid);
        }

        public void CreateEntity(string modId,int id,Guid guid)
        {
            EntityData.CreateEntity((modId, id), guid);
        }
    }
}