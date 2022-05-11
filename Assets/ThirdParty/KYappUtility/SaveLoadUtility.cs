using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KYapp.Utility.Standard;

namespace KYapp.Utility.SaveLoad
{
    public static class SaveLoad
    {
        /// <summary>
        /// PlayerPrefsを使用してSaveします。
        /// 
        /// 使用する型はLoadする際と同じである必要があります。
        /// </summary>
        public static void PlayerPrefsSave<T>(T obj)
        {
            PlayerPrefs.SetString("Data",StandardUtility.Serialize(obj));
        }

        /// <summary>
        /// PlayerPrefsを使用してLoadします。
        /// 
        /// 使用する型はSaveする際と同じである必要があります。
        /// </summary>
        public static T PlayerPrefsLoad<T>()
        {
            return StandardUtility.Deserialize<T>(PlayerPrefs.GetString("Data"));
        }

        /// <summary>
        /// PlayerPrefsを使用してSaveします。
        /// 
        /// 使用する型はLoadする際と同じである必要があります。
        /// セーブ時間が異常に長くなる可能性があります。
        /// </summary>
        public static void PlayerPrefsSave_Chaos<T>(T obj)
        {
            int Key = GetKey();

            PlayerPrefs.SetString("Data", StandardUtility.Serialize(obj));
            PlayerPrefs.Save();
        }

        /// <summary>
        /// PlayerPrefsを使用してLoadします。
        /// 
        /// 使用する型はSaveする際と同じである必要があります。
        /// ロード時間が異常に長くなる可能性があります。
        /// </summary>
        public static T PlayerPrefsLoad_Chaos<T>()
        {
            int Key = GetKey();

            return StandardUtility.Deserialize<T>(PlayerPrefs.GetString("Data"));
        }

        /// <summary>
        /// Keyを設定します。
        ///
        /// Keyを上書きした場合セーブデータが復元できない可能性があります。
        /// </summary>
        public static void SetKey()
        {
            PlayerPrefs.SetInt("Key", (int)Random.Range(1000000000000000000, 10000000000000000000));
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Keyを取得します。
        /// </summary>
        /// <returns></returns>
        public static int GetKey()
        {
            return PlayerPrefs.GetInt("Key");
        }
    }
}
