using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace communicationLibrary
{
    public class DataTransfer
    {
        private BinaryReader inStream;
        private BinaryWriter outStream;

        public DataTransfer(BinaryReader inputStream, BinaryWriter outputStream)
        {
            inStream = inputStream;
            outStream = outputStream;
        }

        #region exceptionHandlers
        private void IOExceptionHandler(IOException IOEx)
        {
            throw IOEx;
        }
        private void ArgumentNullExceptionHandler(ArgumentNullException ArgNullEx)
        {
            throw ArgNullEx;
        }
        private void ObjectDisposedExceptionHandler(ObjectDisposedException ObjDisposedEx)
        {
            throw ObjDisposedEx;
        }
        private void EndOfStreamExceptionHandler(EndOfStreamException EOSEx)
        {
            throw EOSEx;
        }

        #endregion

        #region simpleTypeSend
        public void send(bool data)
        {
            try
            {
                outStream.Write(Messages.boolTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(short data)
        {
            try
            {
                outStream.Write(Messages.shortTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(int data)
        {
            try
            {
                outStream.Write(Messages.intTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(long data)
        {
            try
            {
                outStream.Write(Messages.longTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(ushort data)
        {
            try
            {
                outStream.Write(Messages.ushortTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(uint data)
        {
            try
            {
                outStream.Write(Messages.uintTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(ulong data)
        {
            try
            {
                outStream.Write(Messages.ulongTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(byte data)
        {
            try
            {
                outStream.Write(Messages.byteTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(sbyte data)
        {
            try
            {
                outStream.Write(Messages.sbyteTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(char data)
        {
            try
            {
                outStream.Write(Messages.charTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(string data)
        {
            try
            {
                outStream.Write(Messages.stringTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(decimal data)
        {
            try
            {
                outStream.Write(Messages.decimalTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(float data)
        {
            try
            {
                outStream.Write(Messages.floatTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        public void send(double data)
        {
            try
            {
                outStream.Write(Messages.doubleTransfer);
                outStream.Write(data);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);

            }
            catch (ArgumentNullException ArgNullEx)
            {
                ArgumentNullExceptionHandler(ArgNullEx);

            }
            catch (ObjectDisposedException ObjDisposedEx)
            {
                ObjectDisposedExceptionHandler(ObjDisposedEx);
            }
        }

        #endregion

        #region arrayTypeSend
        public void send(bool[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.boolArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }

        }

        public void send(short[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.shortArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(int[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.intArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(long[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.longArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(ushort[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.ushortArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(uint[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.uintArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(ulong[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.ulongArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(byte[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.byteArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(sbyte[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.sbyteArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(char[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.charArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(string[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.stringArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(decimal[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.decimalArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(float[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.floatArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(double[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.doubleArrayTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        
        #endregion

        #region listTypeSend
        public void send(List<bool> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.boolListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<short> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.shortListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<int> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.intListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<long> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.longListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<ushort> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.ushortListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<uint> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.uintListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<ulong> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.ulongListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<byte> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.byteListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<sbyte> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.sbyteListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<char> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.charListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<string> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.stringListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<decimal> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.decimalListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<float> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.floatListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        public void send(List<double> data)
        {
            int count = data.Count;

            if (count > 0)
            {
                try
                {
                    outStream.Write(Messages.doubleListTransfer);
                    outStream.Write(count);

                    for (int i = 0; i < count; i++)
                    {
                        outStream.Write(data[i]);
                    }

                }
                catch (IOException IOEx)
                {
                    IOExceptionHandler(IOEx);

                }
                catch (ArgumentNullException ArgNullEx)
                {
                    ArgumentNullExceptionHandler(ArgNullEx);

                }
                catch (ObjectDisposedException ObjDisposedEx)
                {
                    ObjectDisposedExceptionHandler(ObjDisposedEx);
                }
            }
        }

        // not sure if working
        //public void send(List<object> data)
        //{
        //    int count = data.Count;

        //    if (count > 0)
        //    {
        //        try
        //        {
        //            outStream.Write(Messages.objectListTransfer);
        //            outStream.Write(count);

        //            for (int i = 0; i < count; i++)
        //            {
        //                outStream.Write(data[i]);
        //            }

        //        }
        //        catch (IOException IOEx)
        //        {
        //            IOExceptionHandler(IOEx);

        //        }
        //        catch (ArgumentNullException ArgNullEx)
        //        {
        //            ArgumentNullExceptionHandler(ArgNullEx);

        //        }
        //        catch (ObjectDisposedException ObjDisposedEx)
        //        {
        //            ObjectDisposedExceptionHandler(ObjDisposedEx);
        //        }
        //    }
        //}
        #endregion

        #region simpleTypeRecieve
        public bool recieveBool()
        {
            bool result=false;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.boolTransfer))
                {
                    result = inStream.ReadBoolean();   
                }
                else
                {
                    throw new TypeNotMatchException("Expected: "+Messages.boolTransfer+"Recieved: "+message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;

        }

        public short recieveShort()
        {
            short result = 0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.shortTransfer))
                {
                    result = inStream.ReadInt16();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.shortTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }

        public int recieveInt()
        {
            int result=0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.intTransfer))
                {
                    result = inStream.ReadInt32();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.intTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }

        public long recieveLong()
        {
            long result=0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.longTransfer))
                {
                    result = inStream.ReadInt64();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.longTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public ushort recieveUShort()
        {
            ushort result=0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.ushortTransfer))
                {
                    result = inStream.ReadUInt16();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.ushortTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public uint recieveUInt()
        {
            uint result=0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.uintTransfer))
                {
                    result = inStream.ReadUInt32();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.uintTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public ulong recieveULong()
        {
            ulong result=0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.ulongTransfer))
                {
                    result = inStream.ReadUInt64();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.ulongTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public byte recieveByte()
        {
            byte result=0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.byteTransfer))
                {
                    result = inStream.ReadByte();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.byteTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public sbyte recieveSByte()
        {
            sbyte result=0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.sbyteTransfer))
                {
                    result = inStream.ReadSByte();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.sbyteTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public char recieveChar()
        {
            char result='0';

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.charTransfer))
                {
                    result = inStream.ReadChar();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.charTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public string recieveString()
        {
            string result = "";

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.stringTransfer))
                {
                    result = inStream.ReadString();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.stringTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public decimal recieveDecimal()
        {
            decimal result=0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.decimalTransfer))
                {
                    result = inStream.ReadDecimal();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.decimalTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public float recieveFloat()
        {
            float result=0.0f;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.floatTransfer))
                {
                    result = inStream.ReadSingle();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.floatTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public double recieveDouble()
        {
            double result=0.0;

            try
            {
                string message;

                message = inStream.ReadString();

                if (message.Equals(Messages.doubleTransfer))
                {
                    result = inStream.ReadDouble();
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.doubleTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        //public object recieveObject()
        //{
        //    object result;

        //    try
        //    {
        //        string message;

        //        message = inStream.ReadString();

        //        if (message.Equals(Messages.boolTransfer))
        //        {
        //            result = //inStream.ReadBoolean();
        //        }
        //        else
        //        {
        //            throw new TypeNotMatchException("Expected: " + Messages.boolTransfer + "Recieved: " + message);
        //        }

        //    }
        //    catch (EndOfStreamException EOSEx)
        //    {
        //        EndOfStreamExceptionHandler(EOSEx);
        //    }
        //    catch (ObjectDisposedException ObjDispEx)
        //    {
        //        ObjectDisposedExceptionHandler(ObjDispEx);
        //    }
        //    catch (IOException IOEx)
        //    {
        //        IOExceptionHandler(IOEx);
        //    }
        //    catch (TypeNotMatchException TypeNotMatchEx)
        //    {
        //        throw TypeNotMatchEx;
        //    }

        //    return result;
        //}
        #endregion

        #region arrayTypeRecieve
        public bool[] recieveArrayOfBools()
        {
            bool[] result = new bool[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.boolArrayTransfer))
                {
                    count = inStream.ReadInt32();
                    
                    if(count>=0)
                    {
                        result = new bool[count];

                        for(int i=0;i<count;i++)
                        {
                            result[i] = inStream.ReadBoolean();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.boolArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;

        }

        public short[] recieveArrayOfShorts()
        {
            short[] result = new short[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.shortArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new short[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadInt16();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.shortArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }

        public int[] recieveArrayOfInts()
        {
            int[] result = new int[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.intArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new int[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadInt32();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.intArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }

        public long[] recieveArrayOfLongs()
        {
            long[] result = new long[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.longArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new long[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadInt64();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.longArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public ushort[] recieveArrayOfUShorts()
        {
            ushort[] result = new ushort[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.ushortArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new ushort[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadUInt16();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.ushortArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public uint[] recieveArrayOfUInts()
        {
            uint[] result = new uint[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.uintArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new uint[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadUInt32();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.uintArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public ulong[] recieveArrayOfULongs()
        {
            ulong[] result = new ulong[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.ulongArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new ulong[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadUInt64();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.ulongArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public byte[] recieveArrayOfBytes()
        {
            byte[] result = new byte[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.byteArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                       // result = new byte[count];

                        result = inStream.ReadBytes(count);

                        //for (int i = 0; i < count; i++)
                        //{
                        //    result[i] = inStream.ReadInt32();
                        //}

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.byteArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public sbyte[] recieveArrayOfSBytes()
        {
            sbyte[] result = new sbyte[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.sbyteArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new sbyte[count];


                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadSByte();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.sbyteArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }

        public char[] recieveArrayOfChars()
        {
            char[] result = new char[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.charArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                       // result = new int[count];

                        result = inStream.ReadChars(count);

                      //  for (int i = 0; i < count; i++)
                      //  {
                     //       result[i] = inStream.ReadInt32();
                     //   }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.charArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public string[] recieveArrayOfStrings()
        {
            string[] result = new string[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.stringArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new string[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadString();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.stringArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public decimal[] recieveArrayOfDecimals()
        {
            decimal[] result = new decimal[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.decimalArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new decimal[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadDecimal();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.decimalArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public float[] recieveArrayOfFloats()
        {
            float[] result = new float[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.floatArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new float[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadSingle();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.floatArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public double[] recieveArrayOfDoubles()
        {
            double[] result = new double[1];

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.doubleArrayTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {
                        result = new double[count];

                        for (int i = 0; i < count; i++)
                        {
                            result[i] = inStream.ReadDouble();
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.doubleArrayTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        //public object recieveObject()
        //{
        //    object result;

        //    try
        //    {
        //        string message;

        //        message = inStream.ReadString();

        //        if (message.Equals(Messages.boolTransfer))
        //        {
        //            result = //inStream.ReadBoolean();
        //        }
        //        else
        //        {
        //            throw new TypeNotMatchException("Expected: " + Messages.boolTransfer + "Recieved: " + message);
        //        }

        //    }
        //    catch (EndOfStreamException EOSEx)
        //    {
        //        EndOfStreamExceptionHandler(EOSEx);
        //    }
        //    catch (ObjectDisposedException ObjDispEx)
        //    {
        //        ObjectDisposedExceptionHandler(ObjDispEx);
        //    }
        //    catch (IOException IOEx)
        //    {
        //        IOExceptionHandler(IOEx);
        //    }
        //    catch (TypeNotMatchException TypeNotMatchEx)
        //    {
        //        throw TypeNotMatchEx;
        //    }

        //    return result;
        //}
        #endregion

        #region listTypeRecieve
        public List<bool> recieveListOfBools()
        {
            List<bool> result = new List<bool>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.boolListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add (inStream.ReadBoolean());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.boolListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;

        }

        public List<short> recieveListOfShorts()
        {
            List<short> result = new List<short>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.shortListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadInt16());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.shortListTransfer + "Recieved: " + message);
                }


            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }

        public List<int> recieveListOfInts()
        {
            List<int> result = new List<int>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.intListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadInt32());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.intListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }

        public List<long> recieveListOfLongs()
        {
           List< long> result = new List<long>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.longListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadInt64());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.longListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<ushort> recieveListOfUShorts()
        {
            List<ushort> result = new List<ushort>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.ushortListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadUInt16());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }

                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.ushortListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<uint> recieveListOfUInts()
        {
            List<uint> result = new List<uint>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.uintListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadUInt32());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.uintListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<ulong> recieveListOfULongs()
        {
           List< ulong> result = new List<ulong>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.ulongListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadUInt64());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.ulongListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<byte> recieveListOfBytes()
        {
            List<byte> result = new List<byte>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.byteListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadByte());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.byteListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<sbyte> recieveListOfSBytes()
        {
           List< sbyte> result = new List<sbyte>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.sbyteListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadSByte());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.sbyteListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }

        public List<char> recieveListOfChars()
        {
            List<char> result = new List<char>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.charListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadChar());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.charListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<string> recieveListOfStrings()
        {
            List<string> result = new List<string>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.stringListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadString());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.stringListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<decimal> recieveListOfDecimals()
        {
            List<decimal> result = new List<decimal>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.decimalListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadDecimal());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.decimalListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<float> recieveListOfFloats()
        {
            List<float> result = new List<float>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.floatListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadSingle());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.floatListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }


        public List<double> recieveListOfDoubles()
        {
            List<double> result = new List<double>();

            try
            {
                string message;
                int count;

                message = inStream.ReadString();

                if (message.Equals(Messages.doubleListTransfer))
                {
                    count = inStream.ReadInt32();

                    if (count >= 0)
                    {

                        for (int i = 0; i < count; i++)
                        {
                            result.Add(inStream.ReadDouble());
                        }

                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                    }


                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.doubleListTransfer + "Recieved: " + message);
                }

            }
            catch (EndOfStreamException EOSEx)
            {
                EndOfStreamExceptionHandler(EOSEx);
            }
            catch (ObjectDisposedException ObjDispEx)
            {
                ObjectDisposedExceptionHandler(ObjDispEx);
            }
            catch (IOException IOEx)
            {
                IOExceptionHandler(IOEx);
            }
            catch (TypeNotMatchException TypeNotMatchEx)
            {
                throw TypeNotMatchEx;
            }

            return result;
        }
        #endregion

    }
}
