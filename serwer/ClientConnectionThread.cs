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

namespace serwer
{
    class ClientConnectionThread
    {
        int clientID;
        int threadID;

        Thread thread;
        Thread readThread;
        TcpClient connection;
        BinaryReader inputStream;
        BinaryWriter outputStream;

        DataTransfer dataTransferConnection;

        bool dataRead;
        bool hasThreadData;
        DTO recievedData;

        public ClientConnectionThread(TcpClient connection)
        {
            try
            {
                this.connection = connection;
                inputStream = new BinaryReader(this.connection.GetStream());
                outputStream = new BinaryWriter(this.connection.GetStream());

                dataTransferConnection = new DataTransfer(inputStream, outputStream);

                thread = new Thread(run);
                thread.Start();

                dataRead = false;
                hasThreadData = false;
                recievedData = new DTO();
                readThread = null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void run()
        {
            outputStream.Write("Hello!");
        }

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
            recievedData.Bool = dataTransferConnection.recieveBool();
            dataRead = true;
        }
        public bool readBool()
        {
            dataRead = false;
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
            recievedData.Short = dataTransferConnection.recieveShort();
            dataRead = true;
        }
        public short readShort()
        {
            dataRead = false;
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
            recievedData.Int = dataTransferConnection.recieveInt();
            dataRead = true;
        }
        public int readInt()
        {
            dataRead = false;
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
            recievedData.Long = dataTransferConnection.recieveLong();
            dataRead = true;
        }
        public long readLong()
        {
            dataRead = false;
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
            recievedData.UShort = dataTransferConnection.recieveUShort();
            dataRead = true;
        }
        public ushort readUShort()
        {
            dataRead = false;
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
            recievedData.UInt = dataTransferConnection.recieveUInt();
            dataRead = true;
        }
        public uint readUInt()
        {
            dataRead = false;
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
            recievedData.ULong = dataTransferConnection.recieveULong();
            dataRead = true;
        }
        public ulong readULong()
        {
            dataRead = false;
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
            recievedData.Byte = dataTransferConnection.recieveByte();
            dataRead = true;
        }
        public byte readByte()
        {
            dataRead = false;
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
            recievedData.SByte = dataTransferConnection.recieveSByte();
            dataRead = true;
        }
        public sbyte readSByte()
        {
            dataRead = false;
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
            recievedData.Char = dataTransferConnection.recieveChar();
            dataRead = true;
        }
        public char readChar()
        {
            dataRead = false;
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
            recievedData.String = dataTransferConnection.recieveString();
            dataRead = true;
        }
        public string readString()
        {
            dataRead = false;
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
            recievedData.Decimal = dataTransferConnection.recieveDecimal();
            dataRead = true;
        }
        public decimal readDecimal()
        {
            dataRead = false;
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
            recievedData.Float = dataTransferConnection.recieveFloat();
            dataRead = true;
        }
        public float readFloat()
        {
            dataRead = false;
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
            recievedData.Double = dataTransferConnection.recieveDouble();
            dataRead = true;
        }
        public double readDouble()
        {
            dataRead = false;
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
            recievedData.BoolArray = dataTransferConnection.recieveArrayOfBools();
            dataRead = true;
        }
        public bool[] readBoolArray()
        {
            dataRead = false;
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
            recievedData.ShortArray = dataTransferConnection.recieveArrayOfShorts();
            dataRead = true;
        }
        public short[] readShortArray()
        {
            dataRead = false;
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
            recievedData.IntArray = dataTransferConnection.recieveArrayOfInts();
            dataRead = true;
        }
        public int[] readIntArray()
        {
            dataRead = false;
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
            recievedData.LongArray = dataTransferConnection.recieveArrayOfLongs();
            dataRead = true;
        }
        public long[] readLongArray()
        {
            dataRead = false;
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
            recievedData.UShortArray = dataTransferConnection.recieveArrayOfUShorts();
            dataRead = true;
        }
        public ushort[] readUShortArray()
        {
            dataRead = false;
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
            recievedData.UIntArray = dataTransferConnection.recieveArrayOfUInts();
            dataRead = true;
        }
        public uint[] readUIntArray()
        {
            dataRead = false;
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
            recievedData.ULongArray = dataTransferConnection.recieveArrayOfULongs();
            dataRead = true;
        }
        public ulong[] readULongArray()
        {
            dataRead = false;
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
            recievedData.ByteArray = dataTransferConnection.recieveArrayOfBytes();
            dataRead = true;
        }
        public byte[] readByteArray()
        {
            dataRead = false;
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
            recievedData.SByteArray = dataTransferConnection.recieveArrayOfSBytes();
            dataRead = true;
        }
        public sbyte[] readSByteArray()
        {
            dataRead = false;
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
            recievedData.CharArray = dataTransferConnection.recieveArrayOfChars();
            dataRead = true;
        }
        public char[] readCharArray()
        {
            dataRead = false;
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
            recievedData.StringArray = dataTransferConnection.recieveArrayOfStrings();
            dataRead = true;
        }
        public string[] readStringArray()
        {
            dataRead = false;
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
            recievedData.DecimalArray = dataTransferConnection.recieveArrayOfDecimals();
            dataRead = true;
        }
        public decimal[] readDecimalArray()
        {
            dataRead = false;
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
            recievedData.FloatArray = dataTransferConnection.recieveArrayOfFloats();
            dataRead = true;
        }
        public float[] readFloatArray()
        {
            dataRead = false;
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
            recievedData.DoubleArray = dataTransferConnection.recieveArrayOfDoubles();
            dataRead = true;
        }
        public double[] readDoubleArray()
        {
            dataRead = false;
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
            recievedData.BoolList = dataTransferConnection.recieveListOfBools();
            dataRead = true;
        }
        public List<bool> readBoolList()
        {
            dataRead = false;
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
            recievedData.ShortList = dataTransferConnection.recieveListOfShorts();
            dataRead = true;
        }
        public List<short> readShortList()
        {
            dataRead = false;
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
            recievedData.IntList = dataTransferConnection.recieveListOfInts();
            dataRead = true;
        }
        public List<int> readIntList()
        {
            dataRead = false;
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
            if (readThread != null)
            {
                if (readThread.IsAlive)
                {
                    readThread.Abort();
                }
            }
            recievedData = new DTO();
            recievedData.LongList = dataTransferConnection.recieveListOfLongs();
            dataRead = true;
        }
        public List<long> readLongList()
        {
            dataRead = false;
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
            recievedData.UShortList = dataTransferConnection.recieveListOfUShorts();
            dataRead = true;
        }
        public List<ushort> readUShortList()
        {
            dataRead = false;
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
            recievedData.UIntList = dataTransferConnection.recieveListOfUInts();
            dataRead = true;
        }
        public List<uint> readUIntList()
        {
            dataRead = false;
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
            recievedData.ULongList = dataTransferConnection.recieveListOfULongs();
            dataRead = true;
        }
        public List<ulong> readULongList()
        {
            dataRead = false;
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
            recievedData.ByteList = dataTransferConnection.recieveListOfBytes();
            dataRead = true;
        }
        public List<byte> readByteList()
        {
            dataRead = false;
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
            recievedData.SByteList = dataTransferConnection.recieveListOfSBytes();
            dataRead = true;
        }
        public List<sbyte> readSByteList()
        {
            dataRead = false;
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
            recievedData.CharList = dataTransferConnection.recieveListOfChars();
            dataRead = true;
        }
        public List<char> readCharList()
        {
            dataRead = false;
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
            recievedData.StringList = dataTransferConnection.recieveListOfStrings();
            dataRead = true;
        }
        public List<string> readStringList()
        {
            dataRead = false;
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
            recievedData.DecimalList = dataTransferConnection.recieveListOfDecimals();
            dataRead = true;
        }
        public List<decimal> readDecimalList()
        {
            dataRead = false;
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
            recievedData.FloatList = dataTransferConnection.recieveListOfFloats();
            dataRead = true;
        }
        public List<float> readFloatList()
        {
            dataRead = false;
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
            recievedData.DoubleList = dataTransferConnection.recieveListOfDoubles();
            dataRead = true;
        }
        public List<double> readDoubleList()
        {
            dataRead = false;
            return recievedData.DoubleList;
        }


        #endregion

        #region sendSimple
        public void sendBool(bool data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
public void sendShort(short data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendInt(int data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendLong(long data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendUShort(ushort data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }

        public void sendUInt(uint data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendULong(ulong data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendByte(byte data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendSByte(sbyte data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendChar(char data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendString(string data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendDecimal(decimal data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendFloat(float data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendDouble(double data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        #endregion

        #region sendArray
        public void sendBoolArray(bool[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendShortArray(short[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendIntArray(int[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendLongArray(long[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendUShortArray(ushort[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendUIntArray(uint[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendULongArray(ulong[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendByteArray(byte[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendSByteArray(sbyte[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendCharArray(char[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendStringArray(string[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendDecimalArray(decimal[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendFloatArray(float[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendDoubleArray(double[] data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        #endregion

        #region sendList
        public void sendBoolList(List<bool> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendShortList(List<short> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendIntList(List<int> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendLongList(List<long> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendUShortList(List<ushort> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendUIntList(List<uint> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendULongList(List<ulong> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendByteList(List<byte> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendSByteList(List<sbyte> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendCharList(List<char> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendStringList(List<string> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendDecimalList(List<decimal> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendFloatList(List<float> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        public void sendDoubleList(List<double> data)
        {
            hasThreadData = true;
            dataTransferConnection.send(data);
        }
        #endregion

    }
}
