using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using communicationLibrary;

namespace communicationLibrary
{
    public class ClientConnectionThread
    {
        int clientID;
        int threadID;

        int threadSleepValue = 1;

        // Thread thread;
        Thread readThread;
        TcpClient connection;
        BinaryReader inputStream;
        BinaryWriter outputStream;

        DataTransfer dataTransferConnection;

        bool dataRead;
        bool hasThreadData;
        bool exceptionCaught;
        DTO recievedData;
        Exception exception;

        List<object> sentData;

        public ClientConnectionThread(TcpClient connection, int clientID, int threadID)
        {
            try
            {
                this.connection = connection;
                inputStream = new BinaryReader(this.connection.GetStream());
                outputStream = new BinaryWriter(this.connection.GetStream());

                dataTransferConnection = new DataTransfer(connection);

                //  thread = new Thread(run);
                ///   thread.Start();

                outputStream.Write(threadID);

                dataRead = false;
                hasThreadData = false;
                recievedData = new DTO();
                readThread = null;
                exceptionCaught = false;
                this.clientID = clientID;
                this.threadID = threadID;

                sentData = new List<object>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void setTimeoutTESTS_ONLY()
        {
            dataTransferConnection.setTimeoutTESTS_ONLY();
        }

        // public void run()
        // {
        //     outputStream.Write("Hello!");
        // }

        public bool isDataRead()
        {
            return dataRead;
        }

        public bool hasDataSend()
        {
            return hasThreadData;
        }

        public int getThreadID()
        {
            return threadID;
        }

        public int getClientID()
        {
            return clientID;
        }

        public void terminateReadThread()
        {
            //dataTransferConnection.abortRead();
            dataTransferConnection.abortRead();
        }

        public void clearSentDataList()
        {
            sentData.Clear();
        }

        public List<object> getSentData()
        {
            return sentData;
        }

        private void EndOfStreamHandler()
        {
            terminateReadThread();
            ClientConnections.Instance().RemoveByThreadID(threadID);
        }

        private void SocketExceptionHandler()
        {
            terminateReadThread();
            ClientConnections.Instance().RemoveByThreadID(threadID);
        }

        #region readSimple
        public void recieveBool()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveBoolThread);
                readThread.Name = "recieveBoolThread";
                readThread.Start();
            }
        }
        private void recieveBoolThread()
        {
            recievedData = new DTO();
            try
            {
                bool data = dataTransferConnection.recieveBool();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Bool = data;
                    dataRead = true;
                }

            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }

            dataRead = true;
        }
        public bool readBool()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }

            return recievedData.Bool;
        }

        public void recieveShort()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveShortThread);
                readThread.Name = "recieveShortThread";
                readThread.Start();
            }
        }
        private void recieveShortThread()
        {
            recievedData = new DTO();
            try
            {
                short data = dataTransferConnection.recieveShort();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Short = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public short readShort()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.Short;
        }

        public void recieveInt()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    //dataTransferConnection.abortRead();
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveIntThread);
                readThread.Name = "recieveIntThread";
                readThread.Start();
            }
        }
        private void recieveIntThread()
        {
            recievedData = new DTO();
            try
            {
                int data = dataTransferConnection.recieveInt();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Int = data;
                    dataRead = true;
                }

            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public int readInt()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.Int;
        }


        public void recieveLong()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveLongThread);
                readThread.Name = "recieveLongThread";
                readThread.Start();
            }
        }
        private void recieveLongThread()
        {
            recievedData = new DTO();
            try
            {
                long data = dataTransferConnection.recieveLong();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Long = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public long readLong()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.Long;
        }


        public void recieveUShort()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveUShortThread);
                readThread.Name = "recieveUShortThread";
                readThread.Start();
            }
        }
        private void recieveUShortThread()
        {
            recievedData = new DTO();
            try
            {
                ushort data = dataTransferConnection.recieveUShort();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.UShort = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public ushort readUShort()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.UShort;
        }


        public void recieveUInt()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveUIntThread);
                readThread.Name = "recieveUIntThread";
                readThread.Start();
            }
        }
        private void recieveUIntThread()
        {
            recievedData = new DTO();
            try
            {
                uint data = dataTransferConnection.recieveUInt();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.UInt = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public uint readUInt()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.UInt;
        }


        public void recieveULong()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveULongThread);
                readThread.Name = "recieveULongThread";
                readThread.Start();
            }
        }
        private void recieveULongThread()
        {
            recievedData = new DTO();
            try
            {
                ulong data = dataTransferConnection.recieveULong();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.ULong = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public ulong readULong()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.ULong;
        }


        public void recieveByte()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveByteThread);
                readThread.Name = "recieveByteThread";
                readThread.Start();
            }
        }
        private void recieveByteThread()
        {
            recievedData = new DTO();
            try
            {
                byte data = dataTransferConnection.recieveByte();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Byte = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public byte readByte()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.Byte;
        }


        public void recieveSByte()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveSByteThread);
                readThread.Name = "recieveSByteThread";
                readThread.Start();
            }
        }
        private void recieveSByteThread()
        {
            recievedData = new DTO();
            try
            {
                sbyte data = dataTransferConnection.recieveSByte();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.SByte = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public sbyte readSByte()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.SByte;
        }

        public void recieveChar()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveCharThread);
                readThread.Name = "recieveCharThread";
                readThread.Start();
            }
        }
        private void recieveCharThread()
        {
            recievedData = new DTO();
            try
            {
                char data = dataTransferConnection.recieveChar();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Char = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public char readChar()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.Char;
        }


        public void recieveString()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveStringThread);
                readThread.Name = "recieveStringThread";
                readThread.Start();
            }
        }
        private void recieveStringThread()
        {
            recievedData = new DTO();
            try
            {
                string data = dataTransferConnection.recieveString();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.String = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public string readString()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.String;
        }


        public void recieveDecimal()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveDecimalThread);
                readThread.Name = "recieveDecimalThread";
                readThread.Start();
            }
        }
        private void recieveDecimalThread()
        {
            recievedData = new DTO();
            try
            {
                decimal data = dataTransferConnection.recieveDecimal();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Decimal = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public decimal readDecimal()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.Decimal;
        }


        public void recieveFloat()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveFloatThread);
                readThread.Name = "recieveFloatThread";
                readThread.Start();
            }
        }
        private void recieveFloatThread()
        {
            recievedData = new DTO();
            try
            {
                float data = dataTransferConnection.recieveFloat();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Float = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public float readFloat()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.Float;
        }


        public void recieveDouble()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveDoubleThread);
                readThread.Name = "recieveDoubleThread";
                readThread.Start();
            }
        }
        private void recieveDoubleThread()
        {
            recievedData = new DTO();
            try
            {
                double data = dataTransferConnection.recieveDouble();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.Double = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public double readDouble()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.Double;
        }

        #endregion

        #region readArray
        public void recieveBoolArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveBoolArrayThread);
                readThread.Name = "recieveBoolArrayThread";
                readThread.Start();
            }
        }
        private void recieveBoolArrayThread()
        {
            recievedData = new DTO();
            try
            {
                bool[] data = dataTransferConnection.recieveArrayOfBools();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.BoolArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public bool[] readBoolArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.BoolArray;
        }


        public void recieveShortArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveShortArrayThread);
                readThread.Name = "recieveShortArrayThread";
                readThread.Start();
            }
        }
        private void recieveShortArrayThread()
        {
            recievedData = new DTO();
            try
            {
                short[] data = dataTransferConnection.recieveArrayOfShorts();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.ShortArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public short[] readShortArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }

            return recievedData.ShortArray;
        }

        public void recieveIntArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    //dataTransferConnection.abortRead();
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveIntArrayThread);
                readThread.Name = "recieveIntArrayThread";
                readThread.Start();
            }
        }
        private void recieveIntArrayThread()
        {
            recievedData = new DTO();
            try
            {
                int[] data = dataTransferConnection.recieveArrayOfInts();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.IntArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public int[] readIntArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.IntArray;
        }

        public void recieveLongArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveLongArrayThread);
                readThread.Name = "recieveLongArrayThread";
                readThread.Start();
            }
        }
        private void recieveLongArrayThread()
        {
            recievedData = new DTO();
            try
            {
                long[] data = dataTransferConnection.recieveArrayOfLongs();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.LongArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }

            dataRead = true;
        }
        public long[] readLongArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.LongArray;
        }


        public void recieveUShortArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveUShortArrayThread);
                readThread.Name = "recieveUShortArrayThread";
                readThread.Start();
            }
        }
        private void recieveUShortArrayThread()
        {
            recievedData = new DTO();
            try
            {
                ushort[] data = dataTransferConnection.recieveArrayOfUShorts();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.UShortArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public ushort[] readUShortArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.UShortArray;
        }


        public void recieveUIntArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveUIntArrayThread);
                readThread.Name = "recieveUIntArrayThread";
                readThread.Start();
            }
        }
        private void recieveUIntArrayThread()
        {
            recievedData = new DTO();
            try
            {
                uint[] data = dataTransferConnection.recieveArrayOfUInts();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.UIntArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public uint[] readUIntArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.UIntArray;
        }


        public void recieveULongArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveULongArrayThread);
                readThread.Name = "recieveULongArrayThread";
                readThread.Start();
            }
        }
        private void recieveULongArrayThread()
        {
            recievedData = new DTO();
            try
            {
                ulong[] data = dataTransferConnection.recieveArrayOfULongs();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.ULongArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public ulong[] readULongArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.ULongArray;
        }


        public void recieveByteArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveByteArrayThread);
                readThread.Name = "recieveByteArrayThread";
                readThread.Start();
            }
        }
        private void recieveByteArrayThread()
        {
            recievedData = new DTO();
            try
            {
                byte[] data = dataTransferConnection.recieveArrayOfBytes();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.ByteArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public byte[] readByteArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.ByteArray;
        }


        public void recieveSByteArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveSByteArrayThread);
                readThread.Name = "recieveSByteArrayThread";
                readThread.Start();
            }
        }
        private void recieveSByteArrayThread()
        {
            recievedData = new DTO();
            try
            {
                sbyte[] data = dataTransferConnection.recieveArrayOfSBytes();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.SByteArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public sbyte[] readSByteArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.SByteArray;
        }


        public void recieveCharArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveCharArrayThread);
                readThread.Name = "recieveCharArrayThread";
                readThread.Start();
            }
        }
        private void recieveCharArrayThread()
        {
            recievedData = new DTO();
            try
            {
                char[] data = dataTransferConnection.recieveArrayOfChars();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.CharArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public char[] readCharArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.CharArray;
        }


        public void recieveStringArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveStringArrayThread);
                readThread.Name = "recieveStringArrayThread";
                readThread.Start();
            }
        }
        private void recieveStringArrayThread()
        {
            recievedData = new DTO();
            try
            {
                string[] data = dataTransferConnection.recieveArrayOfStrings();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.StringArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public string[] readStringArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.StringArray;
        }


        public void recieveDecimalArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveDecimalArrayThread);
                readThread.Name = "recieveDecimalArrayThread";
                readThread.Start();
            }
        }
        private void recieveDecimalArrayThread()
        {
            recievedData = new DTO();
            try
            {
                decimal[] data = dataTransferConnection.recieveArrayOfDecimals();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.DecimalArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public decimal[] readDecimalArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.DecimalArray;
        }


        public void recieveFloatArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveFloatArrayThread);
                readThread.Name = "recieveFloatArrayThread";
                readThread.Start();
            }
        }
        private void recieveFloatArrayThread()
        {
            recievedData = new DTO();
            try
            {
                float[] data = dataTransferConnection.recieveArrayOfFloats();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.FloatArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public float[] readFloatArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.FloatArray;
        }


        public void recieveDoubleArray()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveDoubleArrayThread);
                readThread.Name = "recieveDoubleArrayThread";
                readThread.Start();
            }
        }
        private void recieveDoubleArrayThread()
        {
            recievedData = new DTO();
            try
            {
                double[] data = dataTransferConnection.recieveArrayOfDoubles();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.DoubleArray = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public double[] readDoubleArray()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.DoubleArray;
        }


        #endregion

        #region readList
        public void recieveBoolList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveBoolListThread);
                readThread.Name = "recieveBoolListThread";
                readThread.Start();
            }
        }
        private void recieveBoolListThread()
        {
            recievedData = new DTO();
            try
            {
                List<bool> data = dataTransferConnection.recieveListOfBools();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.BoolList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<bool> readBoolList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.BoolList;
        }

        public void recieveShortList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveShortListThread);
                readThread.Name = "recieveShortListThread";
                readThread.Start();
            }
        }
        private void recieveShortListThread()
        {
            recievedData = new DTO();
            try
            {
                List<short> data = dataTransferConnection.recieveListOfShorts();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.ShortList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<short> readShortList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.ShortList;
        }


        public void recieveIntList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveIntListThread);
                readThread.Name = "recieveIntListThread";
                readThread.Start();
            }
        }
        private void recieveIntListThread()
        {
            recievedData = new DTO();
            try
            {
                List<int> data = dataTransferConnection.recieveListOfInts();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.IntList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<int> readIntList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.IntList;
        }


        public void recieveLongList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveLongListThread);
                readThread.Name = "recieveLongListThread";
                readThread.Start();
            }
        }
        private void recieveLongListThread()
        {
            recievedData = new DTO();
            try
            {
                List<long> data = dataTransferConnection.recieveListOfLongs();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.LongList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                exceptionCaught = true;
            }
            dataRead = true;
        }
        public List<long> readLongList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.LongList;
        }


        public void recieveUShortList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveUShortListThread);
                readThread.Name = "recieveUShortListThread";
                readThread.Start();
            }
        }
        private void recieveUShortListThread()
        {
            recievedData = new DTO();
            try
            {
                List<ushort> data = dataTransferConnection.recieveListOfUShorts();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.UShortList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<ushort> readUShortList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.UShortList;
        }


        public void recieveUIntList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveUIntListThread);
                readThread.Name = "recieveUIntListThread";
                readThread.Start();
            }
        }
        private void recieveUIntListThread()
        {
            recievedData = new DTO();
            try
            {
                List<uint> data = dataTransferConnection.recieveListOfUInts();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.UIntList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<uint> readUIntList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.UIntList;
        }


        public void recieveULongList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveULongListThread);
                readThread.Name = "recieveULongListThread";
                readThread.Start();
            }
        }
        private void recieveULongListThread()
        {
            recievedData = new DTO();
            try
            {
                List<ulong> data = dataTransferConnection.recieveListOfULongs();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.ULongList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<ulong> readULongList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.ULongList;
        }


        public void recieveByteList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveByteListThread);
                readThread.Name = "recieveByteListThread";
                readThread.Start();
            }
        }
        private void recieveByteListThread()
        {
            recievedData = new DTO();
            try
            {
                List<byte> data = dataTransferConnection.recieveListOfBytes();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.ByteList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<byte> readByteList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.ByteList;
        }


        public void recieveSByteList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveSByteListThread);
                readThread.Name = "recieveSByteListThread";
                readThread.Start();
            }
        }
        private void recieveSByteListThread()
        {
            recievedData = new DTO();
            try
            {
                List<sbyte> data = dataTransferConnection.recieveListOfSBytes();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.SByteList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<sbyte> readSByteList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.SByteList;
        }


        public void recieveCharList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveCharListThread);
                readThread.Name = "recieveCharListThread";
                readThread.Start();
            }
        }
        private void recieveCharListThread()
        {
            recievedData = new DTO();
            try
            {
                List<char> data = dataTransferConnection.recieveListOfChars();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.CharList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<char> readCharList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.CharList;
        }


        public void recieveStringList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveStringListThread);
                readThread.Name = "recieveStringListThread";
                readThread.Start();
            }
        }
        private void recieveStringListThread()
        {
            recievedData = new DTO();
            try
            {
                List<string> data = dataTransferConnection.recieveListOfStrings();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.StringList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<string> readStringList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.StringList;
        }


        public void recieveDecimalList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveDecimalListThread);
                readThread.Name = "recieveDecimalListThread";
                readThread.Start();
            }
        }
        private void recieveDecimalListThread()
        {
            recievedData = new DTO();
            try
            {
                List<decimal> data = dataTransferConnection.recieveListOfDecimals();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.DecimalList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<decimal> readDecimalList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.DecimalList;
        }


        public void recieveFloatList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveFloatListThread);
                readThread.Name = "recieveFloatListThread";
                readThread.Start();
            }
        }
        private void recieveFloatListThread()
        {
            recievedData = new DTO();
            try
            {
                List<float> data = dataTransferConnection.recieveListOfFloats();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.FloatList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<float> readFloatList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.FloatList;
        }


        public void recieveDoubleList()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    dataTransferConnection.abortRead();
                }
                while (readThread.IsAlive)
                {
                    Thread.Sleep(threadSleepValue);
                }
            }
            if (!dataRead)
            {
                readThread = new Thread(recieveDoubleListThread);
                readThread.Name = "recieveDoubleListThread";
                readThread.Start();
            }
        }
        private void recieveDoubleListThread()
        {
            recievedData = new DTO();
            try
            {
                List<double> data = dataTransferConnection.recieveListOfDoubles();
                if (dataTransferConnection.isDataRead())
                {
                    recievedData.DoubleList = data;
                    dataRead = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is EndOfStreamException)
                {
                    EndOfStreamHandler();
                }
                else if (ex is SocketException)
                {
                    SocketExceptionHandler();
                }
                else
                {
                    exceptionCaught = true;
                    exception = ex;
                }
            }
            dataRead = true;
        }
        public List<double> readDoubleList()
        {
            dataRead = false;
            hasThreadData = false;
            if (exceptionCaught)
            {
                exceptionCaught = false;
                throw exception;
            }
            return recievedData.DoubleList;
        }


        #endregion

        #region sendSimple
        public void sendBool(bool data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendShort(short data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendInt(int data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendLong(long data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendUShort(ushort data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }

        public void sendUInt(uint data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendULong(ulong data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendByte(byte data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendSByte(sbyte data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendChar(char data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendString(string data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendDecimal(decimal data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendFloat(float data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendDouble(double data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        #endregion

        #region sendArray
        public void sendBoolArray(bool[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendShortArray(short[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendIntArray(int[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendLongArray(long[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendUShortArray(ushort[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendUIntArray(uint[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendULongArray(ulong[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendByteArray(byte[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendSByteArray(sbyte[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendCharArray(char[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendStringArray(string[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendDecimalArray(decimal[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendFloatArray(float[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendDoubleArray(double[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        #endregion

        #region sendList
        public void sendBoolList(List<bool> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendShortList(List<short> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendIntList(List<int> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendLongList(List<long> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendUShortList(List<ushort> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendUIntList(List<uint> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendULongList(List<ulong> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendByteList(List<byte> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendSByteList(List<sbyte> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendCharList(List<char> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendStringList(List<string> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendDecimalList(List<decimal> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendFloatList(List<float> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        public void sendDoubleList(List<double> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            try
            {
                dataTransferConnection.send(data);
            }
            catch (EndOfStreamException e)
            {
                EndOfStreamHandler();
            }
            catch (SocketException e)
            {
                SocketExceptionHandler();
            }
        }
        #endregion

    }
}
