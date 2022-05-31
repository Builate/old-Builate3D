using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KYapp.Builate
{
    public class DataReader
    {
        public byte[] data
        {
            get;
            private set;
        }
        private int Current = 0;
        public DataReader(byte[] data)
        {
            this.data = data;
        }

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

        public byte[] Next(int size)
        {
            byte[] ret = new byte[size];
            Buffer.BlockCopy(data, Current, ret, 0, size);
            Current += size;
            return ret;
        }
    }
}