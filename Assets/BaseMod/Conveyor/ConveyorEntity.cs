using System;
using System.Collections;
using System.Collections.Generic;
using KYapp.Builate;
using UnityEngine;

public class ConveyorEntity : EntityBase, IItemIO
{
    public List<Item> Items = new List<Item>();
    public int Length;

    /// <summary>
    /// パーセンテージでつなぎ目の位置を表す
    /// </summary>
    public float JointPosition;

    public int FirstIndex
    {
        get
        {
            float pos = Length * JointPosition;
            int fPos = (int)Mathf.Floor(pos);
            return fPos;
        }
    }

    public int EndIndex
    {
        get
        {
            return (Length + FirstIndex - 1) % Length;
        }
    }
    
    public IItemIO Out;

    public override void Init()
    {
        
    }

    public override void Start()
    {
        
    }

    public override void Update()
    {
        //JointPositionを少し進める
        JointPosition -= Time.deltaTime;
        if (JointPosition < 0)
        {
            JointPosition += 1;

            if (Out.ItemIn(Items[FirstIndex]))
            {
                Items[FirstIndex] = null;
            }
        }
    }

    public override void Deserialize(DataReader dataReader)
    {
        D_Transform(dataReader.GetBytes());
    }

    public override DataWriter Serialize()
    {
        DataWriter dataWriter = new DataWriter();
        dataWriter.Put(S_Transform());
        return dataWriter;
    }

    public bool ItemIn(Item item)
    {
        if (Items[FirstIndex] == null)
        {
            Items[FirstIndex] = item;
        }
        return true;
    }
}
