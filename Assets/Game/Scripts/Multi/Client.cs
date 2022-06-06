using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

namespace KYapp.Builate
{
    public class Client : NetworkBehaviourSingleton<Client>
    {
        public void CreateEntity((string, int) id, Guid guid)
        {
            Debug.Log(guid);
            CmdCreateEntity(id.Item1, id.Item2, guid);
        }
        [Command]
        private void CmdCreateEntity(string id1, int id2, Guid guid)
        {
            (string, int) id = (id1, id2);
            Debug.Log(id);
            EntityBase eb = (EntityBase)Activator.CreateInstance(EntityData.EntityDataList[id].GetType());
            eb.Data = EntityData.EntityDataList[id].Data;
            Entity entity = new Entity(eb, guid);
            EntityData.EntityList.Add(entity.EntityID, entity);
        }
    }
}