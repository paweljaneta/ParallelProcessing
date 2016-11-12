using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace communicationLibrary
{
    class DataTransfer
    {
        private BinaryReader inStream;
        private BinaryWriter outStream;

        public DataTransfer (BinaryReader inputStream,BinaryWriter outputStream)
        {
            inStream = inputStream;
            outStream = outputStream;
        }

        public void send(bool data)
        {

        }

        public void send(short data)
        {

        }

        public void send(int data)
        {

        }

        public void send(long data)
        {

        }

        public void send(ushort data)
        {

        }

        public void send(uint data)
        {

        }

        public void send(ulong data)
        {

        }

        public void send(byte data)
        {

        }

        public void send(sbyte data)
        {

        }

        public void send(char data)
        {

        }

        public void send(string data)
        {

        }

        public void send(decimal data)
        {

        }

        public void send(float data)
        {

        }

        public void send(double data)
        {

        }

        // not sure if working
        public void send(object data)
        {

        }


        public void send(bool[] data)
        {

        }

        public void send(short[] data)
        {

        }

        public void send(int[] data)
        {

        }

        public void send(long[] data)
        {

        }

        public void send(ushort[] data)
        {

        }

        public void send(uint[] data)
        {

        }

        public void send(ulong[] data)
        {

        }

        public void send(byte[] data)
        {

        }

        public void send(sbyte[] data)
        {

        }

        public void send(char[] data)
        {

        }

        public void send(string[] data)
        {

        }

        public void send(decimal[] data)
        {

        }

        public void send(float[] data)
        {

        }

        public void send(double[] data)
        {

        }

        // not sure if working
        public void send(object[] data)
        {

        }


        public void send(List<bool> data)
        {

        }

        public void send(List<short> data)
        {

        }

        public void send(List<int> data)
        {

        }

        public void send(List<long> data)
        {

        }

        public void send(List<ushort> data)
        {

        }

        public void send(List<uint> data)
        {

        }

        public void send(List<ulong> data)
        {

        }

        public void send(List<byte> data)
        {

        }

        public void send(List<sbyte> data)
        {

        }

        public void send(List<char> data)
        {

        }

        public void send(List<string> data)
        {

        }

        public void send(List<decimal> data)
        {

        }

        public void send(List<float> data)
        {

        }

        public void send(List<double> data)
        {

        }

        // not sure if working
        public void send(List<object> data)
        {

        }


    }
}
