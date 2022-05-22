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


        public Entity CreateEntity(int id)
        {
            return EntityData.CreateEntity((modID, id));
        }

        public Entity CreateEntity(string modId,int id)
        {
            return EntityData.CreateEntity((modId, id));
        }
    }
}