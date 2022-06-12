using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        public EntityBaseData Data;

        /// <summary>
        /// EntityDataList追加時に呼ばれます。
        /// mesh,materialの設定などゲーム起動時に行いたい処理を書いてください。
        /// </summary>
        public virtual void Init()
        {
            
        }

        /// <summary>
        /// entityの出現時に一度だけ呼ばれます。
        /// UnityのStart関数と同じように考えてください。
        /// </summary>
        public virtual void Start()
        {
            
        }

        /// <summary>
        /// entity出現後毎フレーム呼ばれます。
        /// UnityのUpdate関数と同じように考えてください。
        /// </summary>
        public virtual void Update()
        {
            
        }

        /// <summary>
        /// ネットワーク通信時や、データのロード時に使用するDeserialize関数です。
        /// </summary>
        public virtual void Deserialize(DataReader dataReader)
        {
            
        }

        /// <summary>
        /// ネットワーク通信時や、データのセーブ時に使用するSerialize関数です。
        /// </summary>
        public virtual DataWriter Serialize()
        {
            return new DataWriter();
        }

        #region SerializeUtility

        public byte[] S_Transform()
        {
            DataWriter dataWriter = new DataWriter();

            dataWriter.Put(gameObject.transform.position);
            dataWriter.Put(gameObject.transform.rotation.eulerAngles);
            dataWriter.Put(gameObject.transform.localScale);
            
            return dataWriter.GetData();
        }

        #endregion

        #region DeserializeUtility

        public void D_Transform(byte[] data)
        {
            DataReader dataReader = new DataReader(data);

            gameObject.transform.position = dataReader.GetVector3();
            gameObject.transform.rotation = Quaternion.Euler(dataReader.GetVector3());
            gameObject.transform.localScale = dataReader.GetVector3();
        }

        #endregion
    }

    public class EntityBaseData
    {
        /// <summary>
        /// EntityのName
        /// 一意である必要はない
        /// </summary>
        public string Name;
        /// <summary>
        /// (modID,entityDataID)
        /// </summary>
        public (string, int) EntityDataID;
        /// <summary>
        /// 親mod
        /// </summary>
        public Mod mod;
    }
}