using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    /// <summary>
    /// 全てのModが継承するクラス
    /// </summary>
    public abstract class Mod
    {
        public string modID;

        /// <summary>
        /// Entityを羅列してある
        /// Entityの元データ
        /// </summary>
        public static List<EntityBase> ModEntityDataList = new List<EntityBase>();

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

        public void SetEntityData()
        {
            for (int i = 0; i < ModEntityDataList.Count; i++)
            {
                ModEntityDataList[i].Data.EntityDataID.Item2 = i;
                ModEntityDataList[i].Data.EntityDataID.Item1 = modID;
                ModEntityDataList[i].Data.mod = this;
                EntityData.AddEntityData(ModEntityDataList[i]);
            }
        }

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