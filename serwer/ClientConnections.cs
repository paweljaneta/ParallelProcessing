using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace serwer
{
    class ClientConnections
    {
        private List<ClientConnectionThread> connectedClientsList = new List<ClientConnectionThread>();

        public void Add(ClientConnectionThread clientConnection)
        {
            connectedClientsList.Add(clientConnection);
        }

        #region readMethods

        #region readSimple
        public bool readBool()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveBool();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readBool();
        }


        public short readShort()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveShort();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readShort();
        }


        public int readInt()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveInt();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readInt();
        }


        public long readLong()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveLong();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readLong();
        }


        public ushort readUShort()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveUShort();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readUShort();
        }


        public uint readUInt()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveUInt();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readUInt();
        }


        public ulong readULong()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveULong();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readULong();
        }


        public byte readByte()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveByte();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readByte();
        }


        public sbyte readSByte()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveSByte();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readSByte();
        }


        public char readChar()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveChar();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readChar();
        }


        public string readString()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveString();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readString();
        }


        public decimal readDecimal()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveDecimal();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readDecimal();
        }


        public float readFloat()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveFloat();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readFloat();
        }


        public double readDouble()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveDouble();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readDouble();
        }
        #endregion

        #region readArray
        public bool[] readBoolArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveBoolArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readBoolArray();
        }


        public short[] readShortArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveShortArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readShortArray();
        }


        public int[] readIntArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveIntArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readIntArray();
        }


        public long[] readLongArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveLongArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readLongArray();
        }


        public ushort[] readUShortArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveUShortArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readUShortArray();
        }


        public uint[] readUIntArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveUIntArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readUIntArray();
        }


        public ulong[] readULongArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveULongArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readULongArray();
        }


        public byte[] readByteArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveByteArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readByteArray();
        }


        public sbyte[] readSByteArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveSByteArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readSByteArray();
        }


        public char[] readCharArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveCharArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readCharArray();
        }


        public string[] readStringArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveStringArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readStringArray();
        }


        public decimal[] readDecimalArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveDecimalArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readDecimalArray();
        }


        public float[] readFloatArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveFloatArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1; while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readFloatArray();
        }


        public double[] readDoubleArray()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveDoubleArray();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readDoubleArray();
        }

        #endregion


        #region listTypes

        public List<bool> readBoolList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveBoolList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readBoolList();
        }


        public List<short> readShortList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveShortList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readShortList();
        }


        public List<int> readIntList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveIntList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readIntList();
        }


        public List<long> readLongList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveLongList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readLongList();
        }


        public List<ushort> readUShortList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveUShortList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readUShortList();
        }


        public List<uint> readUIntList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveUIntList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readUIntList();
        }


        public List<ulong> readULongList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveULongList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readULongList();
        }


        public List<byte> readByteList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveByteList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readByteList();
        }


        public List<sbyte> readSByteList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveSByteList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readSByteList();
        }


        public List<char> readCharList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveCharList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readCharList();
        }


        public List<string> readStringList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveStringList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readStringList();
        }


        public List<decimal> readDecimalList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveDecimalList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readDecimalList();
        }


        public List<float> readFloatList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveFloatList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readFloatList();
        }


        public List<double> readDoubleList()
        {
            foreach (ClientConnectionThread client in connectedClientsList)
            {
                client.recieveDoubleList();
            }

            bool dataRead = false;

            int indexThatRecieved = -1;

            while (!dataRead)
            {
                if (connectedClientsList.Count == 0)
                {
                    throw new ArgumentException("No clients to read data from");
                }

                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].isDataRead())
                    {
                        dataRead = true;
                        indexThatRecieved = i;
                    }
                }

                Thread.Sleep(1);
            }

            return connectedClientsList[indexThatRecieved].readDoubleList();
        }

        #endregion

        #endregion

        #region sendMethods

        #endregion

    }
}
