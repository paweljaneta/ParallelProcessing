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
        Thread thread;
        Thread readThread;
        TcpClient connection;
        BinaryReader inputStream;
        BinaryWriter outputStream;

        DataTransfer dataTransferConnection;

        bool dataRead;
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
                recievedData = new DTO();

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

        #region readSimple
        public void recieveBool()
        {
            readThread = new Thread(recieveBoolThread);
            thread.Name = "recieveBoolThread";
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
            readThread = new Thread(recieveShortThread);
            thread.Name = "recieveShortThread";
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
            readThread = new Thread(recieveIntThread);
            thread.Name = "recieveIntThread";
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
            readThread = new Thread(recieveLongThread);
            thread.Name = "recieveLongThread";
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
            readThread = new Thread(recieveUShortThread);
            thread.Name = "recieveUShortThread";
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
            readThread = new Thread(recieveUIntThread);
            thread.Name = "recieveUIntThread";
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
            readThread = new Thread(recieveULongThread);
            thread.Name = "recieveULongThread";
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
            readThread = new Thread(recieveByteThread);
            thread.Name = "recieveByteThread";
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
            readThread = new Thread(recieveSByteThread);
            thread.Name = "recieveSByteThread";
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
            readThread = new Thread(recieveCharThread);
            thread.Name = "recieveCharThread";
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
            readThread = new Thread(recieveStringThread);
            thread.Name = "recieveStringThread";
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
            readThread = new Thread(recieveDecimalThread);
            thread.Name = "recieveDecimalThread";
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
            readThread = new Thread(recieveFloatThread);
            thread.Name = "recieveFloatThread";
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
            readThread = new Thread(recieveDoubleThread);
            thread.Name = "recieveDoubleThread";
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
            readThread = new Thread(recieveBoolArrayThread);
            thread.Name = "recieveBoolArrayThread";
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
            readThread = new Thread(recieveShortArrayThread);
            thread.Name = "recieveShortArrayThread";
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
            readThread = new Thread(recieveIntArrayThread);
            thread.Name = "recieveIntArrayThread";
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
            readThread = new Thread(recieveLongArrayThread);
            thread.Name = "recieveLongArrayThread";
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
            readThread = new Thread(recieveUShortArrayThread);
            thread.Name = "recieveUShortArrayThread";
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
            readThread = new Thread(recieveUIntArrayThread);
            thread.Name = "recieveUIntArrayThread";
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
            readThread = new Thread(recieveULongArrayThread);
            thread.Name = "recieveULongArrayThread";
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
            readThread = new Thread(recieveByteArrayThread);
            thread.Name = "recieveByteArrayThread";
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
            readThread = new Thread(recieveSByteArrayThread);
            thread.Name = "recieveSByteArrayThread";
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
            readThread = new Thread(recieveCharArrayThread);
            thread.Name = "recieveCharArrayThread";
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
            readThread = new Thread(recieveStringArrayThread);
            thread.Name = "recieveStringArrayThread";
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
            readThread = new Thread(recieveDecimalArrayThread);
            thread.Name = "recieveDecimalArrayThread";
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
            readThread = new Thread(recieveFloatArrayThread);
            thread.Name = "recieveFloatArrayThread";
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
            readThread = new Thread(recieveDoubleArrayThread);
            thread.Name = "recieveDoubleArrayThread";
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
            readThread = new Thread(recieveBoolListThread);
            thread.Name = "recieveBoolListThread";
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
            readThread = new Thread(recieveShortListThread);
            thread.Name = "recieveShortListThread";
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
            readThread = new Thread(recieveIntListThread);
            thread.Name = "recieveIntListThread";
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
            readThread = new Thread(recieveLongListThread);
            thread.Name = "recieveLongListThread";
            readThread.Start();
        }
        private void recieveLongListThread()
        {
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
            readThread = new Thread(recieveUShortListThread);
            thread.Name = "recieveUShortListThread";
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
            readThread = new Thread(recieveUIntListThread);
            thread.Name = "recieveUIntListThread";
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
            readThread = new Thread(recieveULongListThread);
            thread.Name = "recieveULongListThread";
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
            readThread = new Thread(recieveByteListThread);
            thread.Name = "recieveByteListThread";
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
            readThread = new Thread(recieveSByteListThread);
            thread.Name = "recieveSByteListThread";
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
            readThread = new Thread(recieveCharListThread);
            thread.Name = "recieveCharListThread";
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
            readThread = new Thread(recieveStringListThread);
            thread.Name = "recieveStringListThread";
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
            readThread = new Thread(recieveDecimalListThread);
            thread.Name = "recieveDecimalListThread";
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
            readThread = new Thread(recieveFloatListThread);
            thread.Name = "recieveFloatListThread";
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
            readThread = new Thread(recieveDoubleListThread);
            thread.Name = "recieveDoubleListThread";
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

    }
}
