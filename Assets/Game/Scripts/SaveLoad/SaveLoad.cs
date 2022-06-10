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

            Debug.Log(c);
            
            dataWriter.Put(c);
            for (int i = 0; i < c; i++)
            {
                Entity entity = EntityData.EntityList[EntityData.EntityList.Keys.ToArray()[i]];
                Debug.Log(entity.EntityBase.gameObject.transform.position);
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
                
                
                EntityBase eb = (EntityBase)Activator.CreateInstance(EntityData.EntityDataList[id].GetType());
                eb.Data = EntityData.EntityDataList[id].Data;
                Entity entity = new Entity(eb, entityID);
                entity.EntityBase.Deserialize(new DataReader(dataReader.GetBytes()));
                EntityData.AddEntity(entity);
            }
        }
    }
}