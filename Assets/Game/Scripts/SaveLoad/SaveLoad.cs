using System;
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

        private static string GetPath(string filename)
        {
            return Application.persistentDataPath + "/" + filename;
        }
        
        public static void Save()
        {
            DataWriter dataWriter = new DataWriter();

            int c = EntityData.EntityList.Count;

            dataWriter.Put(c);
            for (int i = 0; i < c; i++)
            {
                Entity entity = EntityData.EntityList[EntityData.EntityList.Keys.ToArray()[i]];
                dataWriter.Put(entity.EntityBase.Data.EntityDataID.Item1);
                dataWriter.Put(entity.EntityBase.Data.EntityDataID.Item2);
                dataWriter.Put(entity.EntityID.ToByteArray());
                dataWriter.Put(entity.EntityBase.Serialize().GetData());
            }
            
            Debug.Log( string.Join(',',dataWriter.GetData().ToArray()));

            BytesSave(dataWriter.GetData(), GetPath("test.BuilateEntityData"));
        }

        public static void Load()
        {
            DataReader dataReader = new DataReader(BytesLoad(GetPath("test.BuilateEntityData")));

            int c = dataReader.GetInt();
            
            for (int i = 0; i < c; i++)
            {
                (string, int) id;
                id.Item1 = dataReader.GetString();
                id.Item2 = dataReader.GetInt();
                Guid entityID = new Guid(dataReader.GetBytes());
                Entity entity = new Entity(EntityData.EntityDataList[id], entityID);
                entity.EntityBase.Deserialize(new DataReader(dataReader.GetBytes()));
                EntityData.AddEntity(entity);
            }
        }
    }
}