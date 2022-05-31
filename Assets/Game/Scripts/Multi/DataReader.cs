using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class DataReader
    {
        private byte[] data;
        private int Current = 0;
        public DataReader(byte[] data)
        {
            this.data = data;
        }

        #region ëgÇ›çûÇ›
        public bool GetBool()
        {
            return BitConverter.ToBoolean(Next(sizeof(bool)), 0);
        }
        public byte GetByte()
        {
            return Next(1)[0];
        }
        public char GetChar()
        {
            return BitConverter.ToChar(Next(sizeof(char)), 0);
        }
        public double GetDouble()
        {
            return BitConverter.ToDouble(Next(sizeof(double)), 0);
        }
        public float GetFloat()
        {
            return BitConverter.ToSingle(Next(sizeof(float)), 0);
        }
        public int GetInt()
        {
            return BitConverter.ToInt32(Next(sizeof(int)), 0);
        }
        public uint GetUInt()
        {
            return BitConverter.ToUInt32(Next(sizeof(uint)), 0);
        }
        public long GetLong()
        {
            return BitConverter.ToInt64(Next(sizeof(long)), 0);
        }
        public ulong GetULong()
        {
            return BitConverter.ToUInt64(Next(sizeof(ulong)), 0);
        }
        public short GetShort()
        {
            return BitConverter.ToInt16(Next(sizeof(short)), 0);
        }
        public ushort GetUShort()
        {
            return BitConverter.ToUInt16(Next(sizeof(ushort)), 0);
        }
        public string GetString()
        {
            int length = GetInt();
            return Encoding.UTF8.GetString(Next(length));
        }
        #endregion

        #region UnityëgÇ›çûÇ›
        public Vector4 GetVector4()
        {
            Vector4 ret;
            ret.x = GetFloat();
            ret.y = GetFloat();
            ret.z = GetFloat();
            ret.w = GetFloat();
            return ret;
        }
        public Vector3 GetVector3()
        {
            Vector3 ret;
            ret.x = GetFloat();
            ret.y = GetFloat();
            ret.z = GetFloat();
            return ret;
        }
        public Vector2 GetVector2()
        {
            Vector2 ret;
            ret.x = GetFloat();
            ret.y = GetFloat();
            return ret;
        }
        #endregion

        #region îzóÒ
        public byte[] GetBytes()
        {
            int length = GetInt();
            return Next(length);
        }
        #endregion

        public byte[] Next(int size)
        {
            byte[] ret = new byte[size];
            Buffer.BlockCopy(data, Current, ret, 0, size);
            Current += size;
            return ret;
        }
    }
}