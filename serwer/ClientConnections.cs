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

            #region readFromFirstReady

                #region readSimple
        public bool readBool(out int threadID)
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

            threadID = connectedClientsList[indexThatRecieved].getThreadID();

            return connectedClientsList[indexThatRecieved].readBool();
        }


        public short readShort(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readShort();
        }


        public int readInt(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readInt();
        }


        public long readLong(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readLong();
        }


        public ushort readUShort(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUShort();
        }


        public uint readUInt(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUInt();
        }


        public ulong readULong(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readULong();
        }


        public byte readByte(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readByte();
        }


        public sbyte readSByte(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readSByte();
        }


        public char readChar(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readChar();
        }


        public string readString(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readString();
        }


        public decimal readDecimal(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDecimal();
        }


        public float readFloat(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readFloat();
        }


        public double readDouble(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDouble();
        }
        #endregion

                #region readArray
        public bool[] readBoolArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readBoolArray();
        }


        public short[] readShortArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readShortArray();
        }


        public int[] readIntArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readIntArray();
        }


        public long[] readLongArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readLongArray();
        }


        public ushort[] readUShortArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUShortArray();
        }


        public uint[] readUIntArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUIntArray();
        }


        public ulong[] readULongArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readULongArray();
        }


        public byte[] readByteArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readByteArray();
        }


        public sbyte[] readSByteArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readSByteArray();
        }


        public char[] readCharArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readCharArray();
        }


        public string[] readStringArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readStringArray();
        }


        public decimal[] readDecimalArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDecimalArray();
        }


        public float[] readFloatArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readFloatArray();
        }


        public double[] readDoubleArray(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDoubleArray();
        }

        #endregion


                #region listTypes

        public List<bool> readBoolList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readBoolList();
        }


        public List<short> readShortList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readShortList();
        }


        public List<int> readIntList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readIntList();
        }


        public List<long> readLongList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readLongList();
        }


        public List<ushort> readUShortList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUShortList();
        }


        public List<uint> readUIntList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUIntList();
        }


        public List<ulong> readULongList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readULongList();
        }


        public List<byte> readByteList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readByteList();
        }


        public List<sbyte> readSByteList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readSByteList();
        }


        public List<char> readCharList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readCharList();
        }


        public List<string> readStringList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readStringList();
        }


        public List<decimal> readDecimalList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDecimalList();
        }


        public List<float> readFloatList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readFloatList();
        }


        public List<double> readDoubleList(out int threadID)
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
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDoubleList();
        }

        #endregion

            #endregion

            #region readById

            #endregion

        #endregion

        #region sendMethods
            #region sendToFirstFree

            #endregion

            #region sendByThreadID

            #endregion

        #endregion

    }
}
