using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

namespace KYapp.Builate
{
    public static class SaveLoad
    {
        private static void BytesSave(byte[] data,string path)
        {
            Debug.Log(path);
            File.WriteAllBytes(path, data);
        }

        private static byte[] BytesLoad(string path)
        {
            return File.ReadAllBytes(path);
        }
        
        public static void Save()
        {
            DataWriter dataWriter = new DataWriter();

            for (int i = 0; i < EntityData.EntityList.Count; i++)
            {
                EntityBase eb = EntityData.EntityList[EntityData.EntityList.Keys.ToArray()[i]].EntityBase;
                dataWriter.Put(eb.Data.EntityDataID.Item1);
                dataWriter.Put(eb.Data.EntityDataID.Item2);
                dataWriter.Put(eb.Serialize());
            }
            
            Debug.Log( string.Join(',',dataWriter.GetData().ToArray()));
            
            BytesSave(dataWriter.GetData(), Application.persistentDataPath + "/" + "test.BuilateEntityData");
        }

        public static void Load()
        {
            
        }
    }
}