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



        public bool readBool()
        {
            foreach(ClientConnectionThread client in connectedClientsList)
            {
                client.recieveBool();
            }

            bool dataRead = false;

            int indexThatRecieved=-1;

            while(!dataRead)
            {
                for(int i=0;i<connectedClientsList.Count;i++)
                {
                    if(connectedClientsList[i].isDataRead())
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





    }
}
