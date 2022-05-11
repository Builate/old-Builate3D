using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Utility.KYAPPrefab
{
    /// <summary>
    /// このクラスを継承して使用する。
    /// 継承先のクラスは代表オブジェクト一つにアタッチする。
    /// 継承先クラスによって生成されたオブジェクトは全て、代表オブジェクトのパラメーター、代表オブジェクトの責任によって実行される。
    /// </summary>
    public abstract class KYAPPrefabManager : MonoBehaviour
    {
        public GameObject Prefab;
        public List<GameObject> GameObjects;
        public GameObject MyGameObject
        {
            get
            {
                return GameObjects[Index];
            }
        }
        public int Index;

        public void Update()
        {
            for (Index = 0; Index < GameObjects.Count; Index++)
            {
                KYAPPrefabUpdate();
            }
        }

        public void KYAPPInstantiate()
        {
            if (Prefab != null)
            {
                GameObjects.Add(Instantiate(Prefab));
                Index = GameObjects.Count - 1;
                KYAPPrefabStart();
            }
        }

        public abstract void KYAPPrefabStart();
        public abstract void KYAPPrefabUpdate();
    }
}