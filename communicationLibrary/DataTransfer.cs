using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using communicationLibrary;

namespace communicationLibrary
{
    class DataTransfer
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

        }
        private void ArgumentNullExceptionHandler(ArgumentNullException ArgNullEx)
        {

        }
        private void ObjectDisposedExceptionHandler(ObjectDisposedException ObjDisposedEx)
        {

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

        // not sure if working
        //public void send(object data)
        //{
        //    try
        //    {
        //        outStream.Write(Messages.objectTransfer);
        //        outStream.Write(data);
        //    }
        //    catch (IOException IOEx)
        //    {
        //        IOExceptionHandler(IOEx);

        //    }
        //    catch (ArgumentNullException ArgNullEx)
        //    {
        //        ArgumentNullExceptionHandler(ArgNullEx);

        //    }
        //    catch (ObjectDisposedException ObjDisposedEx)
        //    {
        //        ObjectDisposedExceptionHandler(ObjDisposedEx);
        //    }
        //}
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

        // not sure if working
        //public void send(object[] data)
        //{
        //    int count = data.Count();

        //    if (count > 0)
        //    {
        //        try
        //        {
        //            outStream.Write(Messages.objectArrayTransfer);
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
            bool result;


            return result;
        }
        public short recieveShort()
        {
            short result;


            return result;
        }
        public int recieveInt()
        {
            int result;


            return result;
        }
        public long recieveLong()
        {
            long result;


            return result;
        }
        public ushort recieveUShort()
        {
            ushort result;


            return result;
        }
        public uint recieveUInt()
        {
            uint result;


            return result;
        }
        public ulong recieveULong()
        {
            ulong result;


            return result;
        }
        public byte recieveByte()
        {
            byte result;


            return result;
        }
        public sbyte recieveSByte()
        {
            sbyte result;


            return result;
        }
        public char recieveChar()
        {
            char result;


            return result;
        }
        public string recieveString()
        {
            string result;


            return result;
        }
        public decimal recieveDecimal()
        {
            decimal result;


            return result;
        }
        public float recieveFloat()
        {
            float result;


            return result;
        }
        public double recieveDouble()
        {
            double result;


            return result;
        }
        public object recieveObject()
        {
            object result;


            return result;
        }
        #endregion

    }
}
