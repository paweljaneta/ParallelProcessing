using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace communicationLibrary
{
    public class DataTransfer
    {
        private BinaryReader inStream;
        private BinaryWriter outStream;
        private TcpClient connection;

        private int inStreamTimeout = 1;

        private static object sendLock = new object();
        private static object recieveLock = new object();

        //public DataTransfer(BinaryReader inputStream, BinaryWriter outputStream)
        //{
        //    inStream = inputStream;
        //    outStream = outputStream;
        //}

        public DataTransfer(TcpClient connection)
        {
            inStream = new BinaryReader(connection.GetStream());
            outStream = new BinaryWriter(connection.GetStream());
            this.connection = connection;

            inStream.BaseStream.ReadTimeout = inStreamTimeout;

        }

        public void CloseInStream()
        {
            inStream.Dispose();
        }

        public void CloseOutStream()
        {
            outStream.Dispose();
        }

        public void CloseStreams()
        {
            CloseInStream();
            CloseOutStream();
        }

        public void OpenInStream()
        {
            inStream = new BinaryReader(connection.GetStream());
        }

        public void OpenOutStream()
        {
            outStream = new BinaryWriter(connection.GetStream());
        }

        public void OpenStreams()
        {
            OpenInStream();
            OpenOutStream();
        }

        #region exceptionHandlers
        private void IOExceptionHandler(IOException IOEx)
        {
            // if(!checkIfTimeout(IOEx))
            // {
            throw IOEx;
            // }     
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


        private bool checkIfTimeout(IOException IOEx)
        {
            SocketException s = new SocketException();
            Type sockEx = s.GetType();
            if (IOEx.InnerException.GetType() == sockEx)
            {
                s = (SocketException)IOEx.InnerException;
                if (s.SocketErrorCode == SocketError.TimedOut)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region simpleTypeSend
        public void send(bool data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.boolTransfer);
                    outStream.Write(data);
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

        public void send(short data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.shortTransfer);
                    outStream.Write(data);
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

        public void send(int data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.intTransfer);
                    outStream.Write(data);
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

        public void send(long data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.longTransfer);
                    outStream.Write(data);
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

        public void send(ushort data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.ushortTransfer);
                    outStream.Write(data);
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

        public void send(uint data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.uintTransfer);
                    outStream.Write(data);
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

        public void send(ulong data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.ulongTransfer);
                    outStream.Write(data);
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

        public void send(byte data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.byteTransfer);
                    outStream.Write(data);
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

        public void send(sbyte data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.sbyteTransfer);
                    outStream.Write(data);
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

        public void send(char data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.charTransfer);
                    outStream.Write(data);
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

        public void send(string data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.stringTransfer);
                    outStream.Write(data);
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

        public void send(decimal data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.decimalTransfer);
                    outStream.Write(data);
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

        public void send(float data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.floatTransfer);
                    outStream.Write(data);
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

        public void send(double data)
        {
            try
            {
                lock (sendLock)
                {
                    outStream.Write(Messages.doubleTransfer);
                    outStream.Write(data);
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

        #endregion

        #region arrayTypeSend
        public void send(bool[] data)
        {
            int count = data.Count();

            if (count > 0)
            {
                try
                {
                    lock (sendLock)
                    {
                        outStream.Write(Messages.boolArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.shortArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.intArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.longArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.ushortArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.uintArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.ulongArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.byteArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.sbyteArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.charArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.stringArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.decimalArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.floatArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.doubleArrayTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.boolListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.shortListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.intListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.longListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.ushortListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.uintListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.ulongListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.byteListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.sbyteListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.charListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.stringListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.decimalListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.floatListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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
                    lock (sendLock)
                    {
                        outStream.Write(Messages.doubleListTransfer);
                        outStream.Write(count);

                        for (int i = 0; i < count; i++)
                        {
                            outStream.Write(data[i]);
                        }

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

        #region simpleTypeRecieve
        public bool recieveBool()
        {
            bool result = false;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }


                if (message.Equals(Messages.boolTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadBoolean();
                    }
                }
                else
                {
                    throw new TypeNotMatchException("Expected: " + Messages.boolTransfer + "Recieved: " + message);
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
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.shortTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadInt16();
                    }
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
            int result = 0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.intTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadInt32();
                    }
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
            long result = 0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.longTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadInt64();
                    }
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
            ushort result = 0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.ushortTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadUInt16();
                    }
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
            uint result = 0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.uintTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadUInt32();
                    }
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
            ulong result = 0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.ulongTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadUInt64();
                    }
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
            byte result = 0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.byteTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadByte();
                    }
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
            sbyte result = 0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.sbyteTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadSByte();
                    }
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
            char result = '0';

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.charTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadChar();
                    }
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
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.stringTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadString();
                    }
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
            decimal result = 0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.decimalTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadDecimal();
                    }
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
            float result = 0.0f;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.floatTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadSingle();
                    }
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
            double result = 0.0;

            try
            {
                string message = null;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.doubleTransfer))
                {
                    lock (recieveLock)
                    {
                        result = inStream.ReadDouble();
                    }
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


        #endregion

        #region arrayTypeRecieve
        public bool[] recieveArrayOfBools()
        {
            bool[] result = new bool[1];

            try
            {
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.boolArrayTransfer))
                {
                    lock (recieveLock)
                    {
                        count = inStream.ReadInt32();

                        if (count >= 0)
                        {
                            result = new bool[count];

                            for (int i = 0; i < count; i++)
                            {
                                result[i] = inStream.ReadBoolean();
                            }

                        }

                        else
                        {
                            throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                        }
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.shortArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.intArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.longArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.ushortArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.uintArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.ulongArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.byteArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.sbyteArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.charArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.stringArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.decimalArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.floatArrayTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.doubleArrayTransfer))
                {
                    lock (recieveLock)
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


        #endregion

        #region listTypeRecieve
        public List<bool> recieveListOfBools()
        {
            List<bool> result = new List<bool>();

            try
            {
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.boolListTransfer))
                {
                    lock (recieveLock)
                    {
                        count = inStream.ReadInt32();

                        if (count >= 0)
                        {

                            for (int i = 0; i < count; i++)
                            {
                                result.Add(inStream.ReadBoolean());
                            }

                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Count of bytes to transfer below zero");
                        }
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.shortListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.intListTransfer))
                {
                    lock (recieveLock)
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
            List<long> result = new List<long>();

            try
            {
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.longListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.ushortListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.uintListTransfer))
                {
                    lock (recieveLock)
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
            List<ulong> result = new List<ulong>();

            try
            {
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.ulongListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.byteListTransfer))
                {
                    lock (recieveLock)
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
            List<sbyte> result = new List<sbyte>();

            try
            {
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.sbyteListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.charListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.stringListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.decimalListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.floatListTransfer))
                {
                    lock (recieveLock)
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
                string message = null;
                int count;

                while (message == null)
                {
                    try
                    {
                        lock (recieveLock)
                        {
                            message = inStream.ReadString();
                        }
                    }
                    catch (IOException IOEx)
                    {
                        if (!checkIfTimeout(IOEx))
                        {
                            throw IOEx;
                        }
                    }
                }

                if (message.Equals(Messages.doubleListTransfer))
                {
                    lock (recieveLock)
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
