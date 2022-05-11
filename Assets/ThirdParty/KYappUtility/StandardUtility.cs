using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace KYapp.Utility.Standard
{
    /// <summary>
    /// KYappのオレオレライブラリ
    /// </summary>
    public static class StandardUtility
    {
        //=================================================================================
        //取得
        //=================================================================================

        /// <summary>
        /// 項目数を取得
        /// </summary>
        public static int GetTypeNum<T>() where T : struct
        {
            return Enum.GetValues(typeof(T)).Length;
        }

        /// <summary>
        /// 項目をランダムに一つ取得
        /// </summary>
        public static T GetRandom<T>() where T : struct
        {
            int no = UnityEngine.Random.Range(0, GetTypeNum<T>());
            //int no = new System.Random().Next(0, GetTypeNum<T>()); //UnityEngineを使わない場合
            return NoToType<T>(no);
        }

        /// <summary>
        /// 全ての項目が入ったListを取得
        /// </summary>
        public static List<T> GetAllInList<T>() where T : struct
        {
            var list = new List<T>();
            foreach (T t in Enum.GetValues(typeof(T)))
            {
                list.Add(t);
            }
            return list;
        }


        //=================================================================================
        //変換
        //=================================================================================

        /// <summary>
        /// 入力された文字列と同じ項目を取得
        /// </summary>
        public static T KeyToType<T>(string targetKey) where T : struct
        {
            return (T)Enum.Parse(typeof(T), targetKey);
        }

        /// <summary>
        /// 入力された番号の項目を取得
        /// </summary>
        public static T NoToType<T>(int targetNo) where T : struct
        {
            return (T)Enum.ToObject(typeof(T), targetNo);
        }

        /// <summary>
        /// 入力された項目のIndexを取得
        /// </summary>
        public static int TypeToNo<T>(T targetType) where T : struct
        {
            return Array.IndexOf(Enum.GetValues(targetType.GetType()), targetType);
        }


        //=================================================================================
        //判定
        //=================================================================================

        /// <summary>
        /// 入力された文字列の項目が含まれているか
        /// </summary>
        public static bool ContainsKey<T>(string tagetKey) where T : struct
        {
            foreach (T t in Enum.GetValues(typeof(T)))
            {
                if (t.ToString() == tagetKey)
                {
                    return true;
                }
            }

            return false;
        }

        //=================================================================================
        //実行
        //=================================================================================

        /// <summary>
        /// 全ての項目に対してデリゲートを実行
        /// </summary>
        public static void ExcuteActionInAllValue<T>(Action<T> action) where T : struct
        {
            foreach (T t in Enum.GetValues(typeof(T)))
            {
                action(t);
            }
        }




        //=================================================================================
        //Serialize
        //=================================================================================
        /// <summary>
        //Utility.Serialize<List<int>> (list1) 使い方
        /// </summary>
        public static string Serialize<T>(T obj)
        {
            var b = new BinaryFormatter();
            var m = new MemoryStream();
            b.Serialize(m, obj);
            return Convert.ToBase64String(
                m.GetBuffer()
            );
        }
        /// <summary>
        //Utility.Deserialize<List<int>> (string1) 使い方
        /// </summary>
        public static T Deserialize<T>(string str)
        {
            var b = new BinaryFormatter();
            var m = new MemoryStream(Convert.FromBase64String(str));
            return (T)b.Deserialize(m);
        }


        public static void Shuffle<T>(List<T> num)
        {
            for (int i = 0; i < num.Count; i++)
            {
                //（説明１）現在の要素を預けておく
                T temp = num[i];
                //（説明２）入れ替える先をランダムに選ぶ
                int randomIndex = UnityEngine.Random.Range(0, num.Count);
                //（説明３）現在の要素に上書き
                num[i] = num[randomIndex];
                //（説明４）入れ替え元に預けておいた要素を与える
                num[randomIndex] = temp;
            }
        }
        public static void Shuffle<T>(T[] num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                //（説明１）現在の要素を預けておく
                T temp = num[i];
                //（説明２）入れ替える先をランダムに選ぶ
                int randomIndex = UnityEngine.Random.Range(0, num.Length);
                //（説明３）現在の要素に上書き
                num[i] = num[randomIndex];
                //（説明４）入れ替え元に預けておいた要素を与える
                num[randomIndex] = temp;
            }
        }
    }
}