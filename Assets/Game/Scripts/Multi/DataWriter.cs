using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class DataWriter
    {
        public List<byte> data
        {
            get;
            private set;
        } = new List<byte>();

        #region ëgÇ›çûÇ›
        public void Put(bool value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        public void Put(byte value)
        {
            data.Add(value);
        }

        public void Put(char value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        public void Put(double value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        public void Put(float value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        public void Put(int value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        public void Put(uint value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        public void Put(long value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        public void Put(ulong value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        public void Put(short value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }
        public void Put(ushort value)
        {
            data.AddRange(BitConverter.GetBytes(value));
        }

        #endregion

        #region UnityëgÇ›çûÇ›
        public void Put(Vector4 value)
        {
            data.AddRange(BitConverter.GetBytes(value.x));
            data.AddRange(BitConverter.GetBytes(value.y));
            data.AddRange(BitConverter.GetBytes(value.z));
            data.AddRange(BitConverter.GetBytes(value.w));
        }
        public void Put(Vector3 value)
        {
            data.AddRange(BitConverter.GetBytes(value.x));
            data.AddRange(BitConverter.GetBytes(value.y));
            data.AddRange(BitConverter.GetBytes(value.z));
        }
        public void Put(Vector2 value)
        {
            data.AddRange(BitConverter.GetBytes(value.x));
            data.AddRange(BitConverter.GetBytes(value.y));
        }
        #endregion 
    }
}