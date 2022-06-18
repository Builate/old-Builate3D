using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public abstract class ItemBase
    {
        /// <summary>
        /// 実体のゲームオブジェクト
        /// </summary>
        public GameObject gameObject;
        
        /// <summary>
        /// 全ての共通のアイテムで共有されるべきデータ
        /// </summary>
        public ItemBaseData Data;
    }

    public class ItemBaseData
    {
        /// <summary>
        /// Itemの名前
        /// </summary>
        public string Name;
        /// <summary>
        /// (modID,itemDataID)
        /// </summary>
        public (string, int) ItemDataID;
        /// <summary>
        /// 親mod
        /// </summary>
        public Mod mod;
    }
}