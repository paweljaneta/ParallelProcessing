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

        public void terminateReadThread()
        {
            readThread.Abort();
        }

        public void clearSentDataList()
        {
            sentData.Clear();
        }

        #region readSimple
        public void recieveBool()
        {
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    readThread.Abort();
                }
            }

            readThread = new Thread(recieveBoolThread);
            readThread.Name = "recieveBoolThread";
            readThread.Start();
        }
        private void recieveBoolThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Bool = dataTransferConnection.recieveBool();

            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveShortThread);
            readThread.Name = "recieveShortThread";
            readThread.Start();
        }
        private void recieveShortThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Short = dataTransferConnection.recieveShort();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveIntThread);
            readThread.Name = "recieveIntThread";
            readThread.Start();
        }
        private void recieveIntThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Int = dataTransferConnection.recieveInt();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveLongThread);
            readThread.Name = "recieveLongThread";
            readThread.Start();
        }
        private void recieveLongThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Long = dataTransferConnection.recieveLong();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveUShortThread);
            readThread.Name = "recieveUShortThread";
            readThread.Start();
        }
        private void recieveUShortThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.UShort = dataTransferConnection.recieveUShort();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveUIntThread);
            readThread.Name = "recieveUIntThread";
            readThread.Start();
        }
        private void recieveUIntThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.UInt = dataTransferConnection.recieveUInt();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveULongThread);
            readThread.Name = "recieveULongThread";
            readThread.Start();
        }
        private void recieveULongThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.ULong = dataTransferConnection.recieveULong();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveByteThread);
            readThread.Name = "recieveByteThread";
            readThread.Start();
        }
        private void recieveByteThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Byte = dataTransferConnection.recieveByte();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveSByteThread);
            readThread.Name = "recieveSByteThread";
            readThread.Start();
        }
        private void recieveSByteThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.SByte = dataTransferConnection.recieveSByte();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveCharThread);
            readThread.Name = "recieveCharThread";
            readThread.Start();
        }
        private void recieveCharThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Char = dataTransferConnection.recieveChar();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveStringThread);
            readThread.Name = "recieveStringThread";
            readThread.Start();
        }
        private void recieveStringThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.String = dataTransferConnection.recieveString();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveDecimalThread);
            readThread.Name = "recieveDecimalThread";
            readThread.Start();
        }
        private void recieveDecimalThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Decimal = dataTransferConnection.recieveDecimal();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveFloatThread);
            readThread.Name = "recieveFloatThread";
            readThread.Start();
        }
        private void recieveFloatThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Float = dataTransferConnection.recieveFloat();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveDoubleThread);
            readThread.Name = "recieveDoubleThread";
            readThread.Start();
        }
        private void recieveDoubleThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.Double = dataTransferConnection.recieveDouble();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveBoolArrayThread);
            readThread.Name = "recieveBoolArrayThread";
            readThread.Start();
        }
        private void recieveBoolArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.BoolArray = dataTransferConnection.recieveArrayOfBools();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveShortArrayThread);
            readThread.Name = "recieveShortArrayThread";
            readThread.Start();
        }
        private void recieveShortArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.ShortArray = dataTransferConnection.recieveArrayOfShorts();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveIntArrayThread);
            readThread.Name = "recieveIntArrayThread";
            readThread.Start();
        }
        private void recieveIntArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.IntArray = dataTransferConnection.recieveArrayOfInts();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveLongArrayThread);
            readThread.Name = "recieveLongArrayThread";
            readThread.Start();
        }
        private void recieveLongArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.LongArray = dataTransferConnection.recieveArrayOfLongs();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveUShortArrayThread);
            readThread.Name = "recieveUShortArrayThread";
            readThread.Start();
        }
        private void recieveUShortArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.UShortArray = dataTransferConnection.recieveArrayOfUShorts();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveUIntArrayThread);
            readThread.Name = "recieveUIntArrayThread";
            readThread.Start();
        }
        private void recieveUIntArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.UIntArray = dataTransferConnection.recieveArrayOfUInts();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveULongArrayThread);
            readThread.Name = "recieveULongArrayThread";
            readThread.Start();
        }
        private void recieveULongArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.ULongArray = dataTransferConnection.recieveArrayOfULongs();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveByteArrayThread);
            readThread.Name = "recieveByteArrayThread";
            readThread.Start();
        }
        private void recieveByteArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.ByteArray = dataTransferConnection.recieveArrayOfBytes();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveSByteArrayThread);
            readThread.Name = "recieveSByteArrayThread";
            readThread.Start();
        }
        private void recieveSByteArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.SByteArray = dataTransferConnection.recieveArrayOfSBytes();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveCharArrayThread);
            readThread.Name = "recieveCharArrayThread";
            readThread.Start();
        }
        private void recieveCharArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.CharArray = dataTransferConnection.recieveArrayOfChars();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveStringArrayThread);
            readThread.Name = "recieveStringArrayThread";
            readThread.Start();
        }
        private void recieveStringArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.StringArray = dataTransferConnection.recieveArrayOfStrings();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveDecimalArrayThread);
            readThread.Name = "recieveDecimalArrayThread";
            readThread.Start();
        }
        private void recieveDecimalArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.DecimalArray = dataTransferConnection.recieveArrayOfDecimals();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveFloatArrayThread);
            readThread.Name = "recieveFloatArrayThread";
            readThread.Start();
        }
        private void recieveFloatArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.FloatArray = dataTransferConnection.recieveArrayOfFloats();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveDoubleArrayThread);
            readThread.Name = "recieveDoubleArrayThread";
            readThread.Start();
        }
        private void recieveDoubleArrayThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.DoubleArray = dataTransferConnection.recieveArrayOfDoubles();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveBoolListThread);
            readThread.Name = "recieveBoolListThread";
            readThread.Start();
        }
        private void recieveBoolListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.BoolList = dataTransferConnection.recieveListOfBools();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveShortListThread);
            readThread.Name = "recieveShortListThread";
            readThread.Start();
        }
        private void recieveShortListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.ShortList = dataTransferConnection.recieveListOfShorts();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveIntListThread);
            readThread.Name = "recieveIntListThread";
            readThread.Start();
        }
        private void recieveIntListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.IntList = dataTransferConnection.recieveListOfInts();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveLongListThread);
            readThread.Name = "recieveLongListThread";
            readThread.Start();
        }
        private void recieveLongListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.LongList = dataTransferConnection.recieveListOfLongs();
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveUShortListThread);
            readThread.Name = "recieveUShortListThread";
            readThread.Start();
        }
        private void recieveUShortListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.UShortList = dataTransferConnection.recieveListOfUShorts();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveUIntListThread);
            readThread.Name = "recieveUIntListThread";
            readThread.Start();
        }
        private void recieveUIntListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.UIntList = dataTransferConnection.recieveListOfUInts();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveULongListThread);
            readThread.Name = "recieveULongListThread";
            readThread.Start();
        }
        private void recieveULongListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.ULongList = dataTransferConnection.recieveListOfULongs();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveByteListThread);
            readThread.Name = "recieveByteListThread";
            readThread.Start();
        }
        private void recieveByteListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.ByteList = dataTransferConnection.recieveListOfBytes();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveSByteListThread);
            readThread.Name = "recieveSByteListThread";
            readThread.Start();
        }
        private void recieveSByteListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.SByteList = dataTransferConnection.recieveListOfSBytes();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveCharListThread);
            readThread.Name = "recieveCharListThread";
            readThread.Start();
        }
        private void recieveCharListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.CharList = dataTransferConnection.recieveListOfChars();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveStringListThread);
            readThread.Name = "recieveStringListThread";
            readThread.Start();
        }
        private void recieveStringListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.StringList = dataTransferConnection.recieveListOfStrings();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveDecimalListThread);
            readThread.Name = "recieveDecimalListThread";
            readThread.Start();
        }
        private void recieveDecimalListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.DecimalList = dataTransferConnection.recieveListOfDecimals();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveFloatListThread);
            readThread.Name = "recieveFloatListThread";
            readThread.Start();
        }
        private void recieveFloatListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.FloatList = dataTransferConnection.recieveListOfFloats();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
                    readThread.Abort();
                }
            }
            readThread = new Thread(recieveDoubleListThread);
            readThread.Name = "recieveDoubleListThread";
            readThread.Start();
        }
        private void recieveDoubleListThread()
        {
            recievedData = new DTO();
            try
            {
                recievedData.DoubleList = dataTransferConnection.recieveListOfDoubles();
            }
            catch (Exception ex)
            {
                exceptionCaught = true;
                exception = ex;
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
            dataTransferConnection.send(data);
        }
        public void sendShort(short data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendInt(int data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendLong(long data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendUShort(ushort data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }

        public void sendUInt(uint data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendULong(ulong data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendByte(byte data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendSByte(sbyte data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendChar(char data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendString(string data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendDecimal(decimal data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendFloat(float data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendDouble(double data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        #endregion

        #region sendArray
        public void sendBoolArray(bool[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendShortArray(short[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendIntArray(int[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendLongArray(long[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendUShortArray(ushort[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendUIntArray(uint[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendULongArray(ulong[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendByteArray(byte[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendSByteArray(sbyte[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendCharArray(char[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendStringArray(string[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendDecimalArray(decimal[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendFloatArray(float[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendDoubleArray(double[] data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        #endregion

        #region sendList
        public void sendBoolList(List<bool> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendShortList(List<short> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendIntList(List<int> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendLongList(List<long> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendUShortList(List<ushort> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendUIntList(List<uint> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendULongList(List<ulong> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendByteList(List<byte> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendSByteList(List<sbyte> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendCharList(List<char> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendStringList(List<string> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendDecimalList(List<decimal> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendFloatList(List<float> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        public void sendDoubleList(List<double> data)
        {
            hasThreadData = true;
            sentData.Add(data);
            dataTransferConnection.send(data);
        }
        #endregion

    }
}
