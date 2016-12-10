using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace communicationLibrary
{
    public class ClientConnections
    {
        private static ClientConnections instance = new ClientConnections();
        private volatile List<ClientConnectionThread> connectedClientsList = new List<ClientConnectionThread>();

        // public static Dictionary<int, List<int>> clientIDThreadsIDMap = new Dictionary<int, List<int>>();

        private object connectedClientsLock = new object();

        public static bool startCalculations = false;

        private float progress = 0;


        private ClientConnections()
        {
        }

        public static ClientConnections Instance()
        {
            return instance;
        }

        public void Add(ClientConnectionThread clientConnection)
        {
            lock (connectedClientsLock)
            {
                connectedClientsList.Add(clientConnection);
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= connectedClientsList.Count)
            {
                throw new ArgumentOutOfRangeException("Remove id out of range");
            }

            List<object> data = connectedClientsList[index].getSentData();

            lock (connectedClientsLock)
            {
                connectedClientsList.RemoveAt(index);
            }
            sendDataFromTerminatedThread(data);
        }

        public bool isClientIDInList(int clientID)
        {
            bool result = false;
            lock (connectedClientsLock)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].getClientID() == clientID)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        public void RemoveByThreadID(int threadID)
        {
            int index = -1;
            lock (connectedClientsLock)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].getThreadID() == threadID)
                    {
                        index = i;
                    }
                }
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Remove by threadID: no such threadID");
            }
            List<object> data = connectedClientsList[index].getSentData();

            lock (connectedClientsLock)
            {
                connectedClientsList.RemoveAt(index);
            }

            sendDataFromTerminatedThread(data);
        }

        public void RemoveByClientID(int clientID)
        {
            int index = -1;
            lock (connectedClientsLock)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (connectedClientsList[i].getClientID() == clientID)
                    {
                        List<object> data = connectedClientsList[i].getSentData();
                        lock (connectedClientsLock)
                        {
                            connectedClientsList.RemoveAt(i);
                        }
                        sendDataFromTerminatedThread(data);
                        index = i;
                    }
                }
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Remove by threadID: no such threadID");
            }
        }

        public void RemoveAll()
        {
            lock (connectedClientsLock)
            {
                connectedClientsList.Clear();
            }
        }

        public int GetConnectedCliensCount()
        {
            int result = -1;
            lock (connectedClientsLock)
            {
                result = connectedClientsList.Count;
            }

            return result;
        }

        public float getProgress()
        {
            return progress;
        }

        public void setProgress(float progress)
        {
            if (progress < 0)
                this.progress = 0;
            else if (progress > 100)
                this.progress = 100;
            else
                this.progress = progress;
        }

        private void terminateReadThreads()
        {
            lock (connectedClientsLock)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    connectedClientsList[i].terminateReadThread();
                }
            }
            //bool threadsStopped = false;

            //while (!threadsStopped)
            //{
            //    threadsStopped = true;
            //    for (int i = 0; i < connectedClientsList.Count; i++)
            //    {
            //        if (connectedClientsList[i].isThreadAlive() == true)
            //            threadsStopped = false;
            //    }
            //}

        }

        private void sendDataFromTerminatedThread(List<object> data)
        {
            #region variables
            bool b = true;
            short s = 0;
            int i = 0;
            long l = 0;
            ushort us = 0;
            uint ui = 0;
            ulong ul = 0;
            byte by = 0;
            sbyte sby = 0;
            char c = 'x';
            string st = "";
            decimal d = 0;
            float f = 0.0f;
            double dbl = 0.0;

            bool[] bA = new bool[1];
            short[] sA = new short[1];
            int[] iA = new int[1];
            long[] lA = new long[1];
            ushort[] usA = new ushort[1];
            uint[] uiA = new uint[1];
            ulong[] ulA = new ulong[1];
            byte[] byA = new byte[1];
            sbyte[] sbyA = new sbyte[1];
            char[] cA = new char[1];
            string[] stA = new string[1];
            decimal[] dA = new decimal[1];
            float[] fA = new float[1];
            double[] dblA = new double[1];

            List<bool> bL = new List<bool>();
            List<short> sL = new List<short>();
            List<int> iL = new List<int>();
            List<long> lL = new List<long>();
            List<ushort> usL = new List<ushort>();
            List<uint> uiL = new List<uint>();
            List<ulong> ulL = new List<ulong>();
            List<byte> byL = new List<byte>();
            List<sbyte> sbyL = new List<sbyte>();
            List<char> cL = new List<char>();
            List<string> stL = new List<string>();
            List<decimal> dL = new List<decimal>();
            List<float> fL = new List<float>();
            List<double> dblL = new List<double>();

            #endregion
            #region types
            Type boolType = b.GetType();
            Type shortType = s.GetType();
            Type intType = i.GetType();
            Type longType = l.GetType();
            Type ushortType = us.GetType();
            Type uintType = ui.GetType();
            Type ulongType = ul.GetType();
            Type byteType = by.GetType();
            Type sbyteType = sby.GetType();
            Type charType = c.GetType();
            Type stringType = st.GetType();
            Type decimalType = d.GetType();
            Type floatType = f.GetType();
            Type doubleType = dbl.GetType();

            Type boolArrayType = bA.GetType();
            Type shortArrayType = sA.GetType();
            Type intArrayType = iA.GetType();
            Type longArrayType = lA.GetType();
            Type ushortArrayType = usA.GetType();
            Type uintArrayType = uiA.GetType();
            Type ulongArrayType = ulA.GetType();
            Type byteArrayType = byA.GetType();
            Type sbyteArrayType = sbyA.GetType();
            Type charArrayType = cA.GetType();
            Type stringArrayType = stA.GetType();
            Type decimalArrayType = dA.GetType();
            Type floatArrayType = fA.GetType();
            Type doubleArrayType = dblA.GetType();

            Type boolListType = bL.GetType();
            Type shortListType = sL.GetType();
            Type intListType = iL.GetType();
            Type longListType = lL.GetType();
            Type ushortListType = usL.GetType();
            Type uintListType = uiL.GetType();
            Type ulongListType = ulL.GetType();
            Type byteListType = byL.GetType();
            Type sbyteListType = sbyL.GetType();
            Type charListType = cL.GetType();
            Type stringListType = stL.GetType();
            Type decimalListType = dL.GetType();
            Type floatListType = fL.GetType();
            Type doubleListType = dblL.GetType();
            #endregion

            bool sendToFirstFree = true;
            int threadID = -1;

            foreach (object o in data)
            {
                if (o.GetType().Equals(boolType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendBool((bool)o, out threadID);
                    }
                    else
                    {
                        sendBoolByID((bool)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(shortType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendShort((short)o, out threadID);
                    }
                    else
                    {
                        sendShortByID((short)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(intType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendInt((int)o, out threadID);
                    }
                    else
                    {
                        sendIntByID((int)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(longType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendLong((long)o, out threadID);
                    }
                    else
                    {
                        sendLongByID((long)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(ushortType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendUShort((ushort)o, out threadID);
                    }
                    else
                    {
                        sendUShortByID((ushort)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(uintType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendUInt((uint)o, out threadID);
                    }
                    else
                    {
                        sendUIntByID((uint)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(ulongType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendULong((ulong)o, out threadID);
                    }
                    else
                    {
                        sendULongByID((ulong)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(byteType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendByte((byte)o, out threadID);
                    }
                    else
                    {
                        sendByteByID((byte)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(sbyteType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendSByte((sbyte)o, out threadID);
                    }
                    else
                    {
                        sendSByteByID((sbyte)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(charType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendChar((char)o, out threadID);
                    }
                    else
                    {
                        sendCharByID((char)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(stringType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendString((string)o, out threadID);
                    }
                    else
                    {
                        sendStringByID((string)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(decimalType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendDecimal((decimal)o, out threadID);
                    }
                    else
                    {
                        sendDecimalByID((decimal)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(floatType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendFloat((float)o, out threadID);
                    }
                    else
                    {
                        sendFloatByID((float)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(doubleType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendDouble((double)o, out threadID);
                    }
                    else
                    {
                        sendDoubleByID((double)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(boolArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendBoolArray((bool[])o, out threadID);
                    }
                    else
                    {
                        sendBoolArrayByID((bool[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(shortArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendShortArray((short[])o, out threadID);
                    }
                    else
                    {
                        sendShortArrayByID((short[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(intArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendIntArray((int[])o, out threadID);
                    }
                    else
                    {
                        sendIntArrayByID((int[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(longArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendLongArray((long[])o, out threadID);
                    }
                    else
                    {
                        sendLongArrayByID((long[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(ushortArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendUShortArray((ushort[])o, out threadID);
                    }
                    else
                    {
                        sendUShortArrayByID((ushort[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(uintArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendUIntArray((uint[])o, out threadID);
                    }
                    else
                    {
                        sendUIntArrayByID((uint[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(ulongArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendULongArray((ulong[])o, out threadID);
                    }
                    else
                    {
                        sendULongArrayByID((ulong[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(byteArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendByteArray((byte[])o, out threadID);
                    }
                    else
                    {
                        sendByteArrayByID((byte[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(sbyteArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendSByteArray((sbyte[])o, out threadID);
                    }
                    else
                    {
                        sendSByteArrayByID((sbyte[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(charArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendCharArray((char[])o, out threadID);
                    }
                    else
                    {
                        sendCharArrayByID((char[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(stringArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendStringArray((string[])o, out threadID);
                    }
                    else
                    {
                        sendStringArrayByID((string[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(decimalArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendDecimalArray((decimal[])o, out threadID);
                    }
                    else
                    {
                        sendDecimalArrayByID((decimal[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(floatArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendFloatArray((float[])o, out threadID);
                    }
                    else
                    {
                        sendFloatArrayByID((float[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(doubleArrayType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendDoubleArray((double[])o, out threadID);
                    }
                    else
                    {
                        sendDoubleArrayByID((double[])o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(boolListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendBoolList((List<bool>)o, out threadID);
                    }
                    else
                    {
                        sendBoolListByID((List<bool>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(shortListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendShortList((List<short>)o, out threadID);
                    }
                    else
                    {
                        sendShortListByID((List<short>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(intListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendIntList((List<int>)o, out threadID);
                    }
                    else
                    {
                        sendIntListByID((List<int>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(longListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendLongList((List<long>)o, out threadID);
                    }
                    else
                    {
                        sendLongListByID((List<long>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(ushortListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendUShortList((List<ushort>)o, out threadID);
                    }
                    else
                    {
                        sendUShortListByID((List<ushort>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(uintListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendUIntList((List<uint>)o, out threadID);
                    }
                    else
                    {
                        sendUIntListByID((List<uint>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(ulongListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendULongList((List<ulong>)o, out threadID);
                    }
                    else
                    {
                        sendULongListByID((List<ulong>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(byteListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendByteList((List<byte>)o, out threadID);
                    }
                    else
                    {
                        sendByteListByID((List<byte>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(sbyteListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendSByteList((List<sbyte>)o, out threadID);
                    }
                    else
                    {
                        sendSByteListByID((List<sbyte>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(charListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendCharList((List<char>)o, out threadID);
                    }
                    else
                    {
                        sendCharListByID((List<char>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(stringListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendStringList((List<string>)o, out threadID);
                    }
                    else
                    {
                        sendStringListByID((List<string>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(decimalListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendDecimalList((List<decimal>)o, out threadID);
                    }
                    else
                    {
                        sendDecimalListByID((List<decimal>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(floatListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendFloatList((List<float>)o, out threadID);
                    }
                    else
                    {
                        sendFloatListByID((List<float>)o, threadID);
                    }
                }
                else
                    if (o.GetType().Equals(doubleListType))
                {
                    if (sendToFirstFree)
                    {
                        sendToFirstFree = false;
                        sendDoubleList((List<double>)o, out threadID);
                    }
                    else
                    {
                        sendDoubleListByID((List<double>)o, threadID);
                    }
                }
                else
                {
                    throw new ArgumentException("not supported type!");
                }
            }

        }

        #region readMethods

        #region readFromFirstReady

        #region readSimple
        public bool readBool(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveBool();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();

            return connectedClientsList[indexThatRecieved].readBool();
        }


        public short readShort(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveShort();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readShort();
        }


        public int readInt(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveInt();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readInt();
        }


        public long readLong(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveLong();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readLong();
        }


        public ushort readUShort(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveUShort();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUShort();
        }


        public uint readUInt(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveUInt();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUInt();
        }


        public ulong readULong(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveULong();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readULong();
        }


        public byte readByte(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveByte();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readByte();
        }


        public sbyte readSByte(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveSByte();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readSByte();
        }


        public char readChar(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveChar();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readChar();
        }


        public string readString(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveString();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readString();
        }


        public decimal readDecimal(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveDecimal();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDecimal();
        }


        public float readFloat(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveFloat();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readFloat();
        }


        public double readDouble(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveDouble();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDouble();
        }
        #endregion

        #region readArray
        public bool[] readBoolArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveBoolArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readBoolArray();
        }


        public short[] readShortArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveShortArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readShortArray();
        }


        public int[] readIntArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveIntArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readIntArray();
        }


        public long[] readLongArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveLongArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readLongArray();
        }


        public ushort[] readUShortArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveUShortArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUShortArray();
        }


        public uint[] readUIntArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveUIntArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUIntArray();
        }


        public ulong[] readULongArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveULongArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readULongArray();
        }


        public byte[] readByteArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveByteArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readByteArray();
        }


        public sbyte[] readSByteArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveSByteArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readSByteArray();
        }


        public char[] readCharArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveCharArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readCharArray();
        }


        public string[] readStringArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveStringArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readStringArray();
        }


        public decimal[] readDecimalArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveDecimalArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDecimalArray();
        }


        public float[] readFloatArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveFloatArray();
                }

                bool dataRead = false;

                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readFloatArray();
        }


        public double[] readDoubleArray(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveDoubleArray();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDoubleArray();
        }

        #endregion


        #region readList

        public List<bool> readBoolList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveBoolList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readBoolList();
        }


        public List<short> readShortList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveShortList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readShortList();
        }


        public List<int> readIntList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveIntList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readIntList();
        }


        public List<long> readLongList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveLongList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readLongList();
        }


        public List<ushort> readUShortList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveUShortList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUShortList();
        }


        public List<uint> readUIntList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveUIntList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readUIntList();
        }


        public List<ulong> readULongList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveULongList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readULongList();
        }


        public List<byte> readByteList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveByteList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readByteList();
        }


        public List<sbyte> readSByteList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveSByteList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readSByteList();
        }


        public List<char> readCharList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveCharList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readCharList();
        }


        public List<string> readStringList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveStringList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readStringList();
        }


        public List<decimal> readDecimalList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveDecimalList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDecimalList();
        }


        public List<float> readFloatList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveFloatList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readFloatList();
        }


        public List<double> readDoubleList(out int threadID)
        {
            int indexThatRecieved = -1;
            lock (connectedClientsLock)
            {
                foreach (ClientConnectionThread client in connectedClientsList)
                {
                    client.recieveDoubleList();
                }

                bool dataRead = false;



                while (!dataRead)
                {
                    if (connectedClientsList.Count == 0)
                    {
                        throw new ArgumentException("No clients to read data from");
                    }

                    for (int i = 0; i < connectedClientsList.Count; i++)
                    {
                        if (connectedClientsList[i].getIsExceptionCaught())
                        {
                            connectedClientsList[i].throwException();
                        }

                        if (connectedClientsList[i].isDataRead())
                        {
                            dataRead = true;
                            indexThatRecieved = i;
                            terminateReadThreads();
                        }
                    }

                    Thread.Sleep(1);
                }
            }
            threadID = connectedClientsList[indexThatRecieved].getThreadID();
            return connectedClientsList[indexThatRecieved].readDoubleList();
        }

        #endregion

        #endregion

        #region readById
        #region readSimpleByID
        public bool readBoolByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveBool();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readBool();
        }


        public short readShortByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveShort();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readShort();
        }


        public int readIntByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveInt();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readInt();
        }


        public long readLongByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveLong();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readLong();
        }


        public ushort readUShortByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveUShort();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readUShort();
        }


        public uint readUIntByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveUInt();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readUInt();
        }


        public ulong readULongByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveULong();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readULong();
        }


        public byte readByteByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveByte();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readByte();
        }


        public sbyte readSByteByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveSByte();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readSByte();
        }


        public char readCharByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveChar();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readChar();
        }


        public string readStringByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveString();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readString();
        }


        public decimal readDecimalByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveDecimal();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readDecimal();
        }


        public float readFloatByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveFloat();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readFloat();
        }


        public double readDoubleByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveDouble();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readDouble();
        }

        #endregion

        #region readArrayByID
        public bool[] readBoolArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveBoolArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readBoolArray();
        }


        public short[] readShortArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveShortArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readShortArray();
        }


        public int[] readIntArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveIntArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readIntArray();
        }


        public long[] readLongArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveLongArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readLongArray();
        }


        public ushort[] readUShortArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveUShortArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readUShortArray();
        }


        public uint[] readUIntArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveUIntArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readUIntArray();
        }


        public ulong[] readULongArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveULongArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readULongArray();
        }


        public byte[] readByteArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveByteArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readByteArray();
        }


        public sbyte[] readSByteArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveSByteArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readSByteArray();
        }


        public char[] readCharArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveCharArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readCharArray();
        }


        public string[] readStringArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveStringArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readStringArray();
        }


        public decimal[] readDecimalArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveDecimalArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readDecimalArray();
        }


        public float[] readFloatArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveFloatArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readFloatArray();
        }


        public double[] readDoubleArrayByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveDoubleArray();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readDoubleArray();
        }


        #endregion

        #region readListByID
        public List<bool> readBoolListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveBoolList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readBoolList();
        }

        public List<short> readShortListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveShortList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readShortList();
        }


        public List<int> readIntListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveIntList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readIntList();
        }


        public List<long> readLongListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveLongList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readLongList();
        }


        public List<ushort> readUShortListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveUShortList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readUShortList();
        }


        public List<uint> readUIntListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveUIntList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readUIntList();
        }


        public List<ulong> readULongListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveULongList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readULongList();
        }


        public List<byte> readByteListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveByteList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readByteList();
        }


        public List<sbyte> readSByteListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveSByteList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readSByteList();
        }


        public List<char> readCharListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveCharList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readCharList();
        }


        public List<string> readStringListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveStringList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readStringList();
        }


        public List<decimal> readDecimalListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveDecimalList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readDecimalList();
        }


        public List<float> readFloatListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveFloatList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readFloatList();
        }


        public List<double> readDoubleListByID(int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].recieveDoubleList();
            }

            while (!(connectedClientsList[foundIndex].isDataRead() || connectedClientsList[foundIndex].getIsExceptionCaught()))
            {
                Thread.Sleep(1);
            }

            return connectedClientsList[foundIndex].readDoubleList();
        }


        #endregion

        #endregion

        #endregion

        #region sendMethods
        #region sendToFirstFree
        #region sendSimple
        public void sendBool(bool data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendBool(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendShort(short data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendShort(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendInt(int data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendInt(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendLong(long data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendLong(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendUShort(ushort data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendUShort(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendUInt(uint data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendUInt(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendULong(ulong data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendULong(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendByte(byte data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendByte(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendSByte(sbyte data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendSByte(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendChar(char data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendChar(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendString(string data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendString(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendDecimal(decimal data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendDecimal(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendFloat(float data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendFloat(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendDouble(double data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendDouble(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        #endregion

        #region sendArray
        public void sendBoolArray(bool[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendBoolArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendShortArray(short[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendShortArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendIntArray(int[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendIntArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendLongArray(long[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendLongArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendUShortArray(ushort[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendUShortArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendUIntArray(uint[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendUIntArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendULongArray(ulong[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendULongArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendByteArray(byte[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendByteArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendSByteArray(sbyte[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendSByteArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendCharArray(char[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendCharArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendStringArray(string[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendStringArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendDecimalArray(decimal[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendDecimalArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendFloatArray(float[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendFloatArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendDoubleArray(double[] data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendDoubleArray(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        #endregion

        #region sendList
        public void sendBoolList(List<bool> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendBoolList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendShortList(List<short> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendShortList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendIntList(List<int> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendIntList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendLongList(List<long> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendLongList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendUShortList(List<ushort> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendUShortList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendUIntList(List<uint> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendUIntList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendULongList(List<ulong> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendULongList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendByteList(List<byte> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendByteList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendSByteList(List<sbyte> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendSByteList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendCharList(List<char> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendCharList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendStringList(List<string> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendStringList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendDecimalList(List<decimal> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendDecimalList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendFloatList(List<float> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendFloatList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        public void sendDoubleList(List<double> data, out int threadID)
        {
            int thrID = -1;
            bool dataSent = false;
            if (connectedClientsList.Count == 0)
            {
                throw new ArgumentException("No clients to send data to");
            }

            while (!dataSent)
            {
                for (int i = 0; i < connectedClientsList.Count; i++)
                {
                    if (!connectedClientsList[i].hasDataSend())
                    {
                        connectedClientsList[i].clearSentDataList();
                        connectedClientsList[i].sendDoubleList(data);
                        thrID = connectedClientsList[i].getThreadID();
                        dataSent = true;
                        break;
                    }
                }
            }

            threadID = thrID;
        }
        #endregion

        #endregion

        #region sendByThreadID
        #region sendSimple
        public void sendBoolByID(bool data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendBool(data);
            }

        }
        public void sendShortByID(short data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendShort(data);
            }
        }
        public void sendIntByID(int data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendInt(data);
            }
        }
        public void sendLongByID(long data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendLong(data);
            }
        }
        public void sendUShortByID(ushort data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendUShort(data);
            }
        }
        public void sendUIntByID(uint data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendUInt(data);
            }
        }
        public void sendULongByID(ulong data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendULong(data);
            }
        }
        public void sendByteByID(byte data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendByte(data);
            }
        }
        public void sendSByteByID(sbyte data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendSByte(data);
            }
        }
        public void sendCharByID(char data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendChar(data);
            }
        }
        public void sendStringByID(string data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendString(data);
            }
        }
        public void sendDecimalByID(decimal data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendDecimal(data);
            }
        }
        public void sendFloatByID(float data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendFloat(data);
            }
        }
        public void sendDoubleByID(double data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendDouble(data);
            }
        }
        #endregion

        #region sendArray
        public void sendBoolArrayByID(bool[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendBoolArray(data);
            }
        }
        public void sendShortArrayByID(short[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendShortArray(data);
            }
        }
        public void sendIntArrayByID(int[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendIntArray(data);
            }
        }
        public void sendLongArrayByID(long[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendLongArray(data);
            }
        }
        public void sendUShortArrayByID(ushort[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendUShortArray(data);
            }
        }
        public void sendUIntArrayByID(uint[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendUIntArray(data);
            }
        }
        public void sendULongArrayByID(ulong[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendULongArray(data);
            }
        }
        public void sendByteArrayByID(byte[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendByteArray(data);
            }
        }
        public void sendSByteArrayByID(sbyte[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendSByteArray(data);
            }
        }
        public void sendCharArrayByID(char[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendCharArray(data);
            }
        }
        public void sendStringArrayByID(string[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendStringArray(data);
            }
        }
        public void sendDecimalArrayByID(decimal[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendDecimalArray(data);
            }
        }
        public void sendFloatArrayByID(float[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendFloatArray(data);
            }
        }
        public void sendDoubleArrayByID(double[] data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendDoubleArray(data);
            }
        }
        #endregion

        #region sendList
        public void sendBoolListByID(List<bool> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendBoolList(data);
            }
        }
        public void sendShortListByID(List<short> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendShortList(data);
            }
        }
        public void sendIntListByID(List<int> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendIntList(data);
            }
        }
        public void sendLongListByID(List<long> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendLongList(data);
            }
        }
        public void sendUShortListByID(List<ushort> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendUShortList(data);
            }
        }
        public void sendUIntListByID(List<uint> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendUIntList(data);
            }
        }
        public void sendULongListByID(List<ulong> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendULongList(data);
            }
        }
        public void sendByteListByID(List<byte> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendByteList(data);
            }
        }
        public void sendSByteListByID(List<sbyte> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendSByteList(data);
            }
        }
        public void sendCharListByID(List<char> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendCharList(data);
            }
        }
        public void sendStringListByID(List<string> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendStringList(data);
            }
        }
        public void sendDecimalListByID(List<decimal> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendDecimalList(data);
            }
        }
        public void sendFloatListByID(List<float> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendFloatList(data);
            }
        }
        public void sendDoubleListByID(List<double> data, int threadID)
        {
            int foundIndex = -1;

            for (int i = 0; i < connectedClientsList.Count; i++)
            {
                if (connectedClientsList[i].getThreadID() == threadID)
                {
                    foundIndex = i;
                }
            }

            if (foundIndex < 0)
            {
                throw new ArgumentException("ReadByID There is no client with that id");
            }
            else
            {
                connectedClientsList[foundIndex].sendDoubleList(data);
            }
        }
        #endregion
        #endregion

        #endregion

    }
}
