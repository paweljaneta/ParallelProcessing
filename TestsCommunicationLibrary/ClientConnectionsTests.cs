using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net.Sockets;
using System.Net;
using communicationLibrary;
using System.Collections.Generic;

namespace TestsCommunicationLibrary
{
    [TestClass]
    public class ClientConnectionsTests
    {
        private TcpListener server;
        private TcpClient serverConnection, clientConnection;

        private List<DataTransfer> connectedClients = new List<DataTransfer>();
        private List<TcpClient> connections = new List<TcpClient>();

        private string serverIP = "127.0.0.1", clientIP = "127.0.0.1";
        private int port = 1807;


        private int numberOfElements = 5;

        //at least 2
        private int numberOfClients = 2;


        Random random;

        [TestInitialize]
        public void TestInitialize()
        {
            server = new TcpListener(IPAddress.Parse(serverIP), port);
            server.Start();

            for (int i = 0; i < numberOfClients; i++)
            {
                clientConnection = new TcpClient(clientIP, port);
                serverConnection = server.AcceptTcpClient();

                connections.Add(clientConnection);

                connectedClients.Add(new DataTransfer(clientConnection));
                ClientConnections.Instance().Add(new ClientConnectionThread(serverConnection, 0, i));

            }
            server.Stop();

            random = new Random();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            ClientConnections.Instance().RemoveAll();
            connectedClients.Clear();
            connections.Clear();
        }

        [TestMethod]
        public void ShouldRemoveFirst()
        {
            ClientConnections.Instance().Remove(0);
        }

        [TestMethod]
        public void ShouldRemoveException()
        {
            //given
            int index = ClientConnections.Instance().GetConnectedCliensCount();

            try
            {
                ClientConnections.Instance().Remove(index);
                Assert.Fail();

            }
            catch (ArgumentOutOfRangeException e)
            { }
        }

        [TestMethod]
        public void ShouldRemoveByThreadIDFirst()
        {
            ClientConnections.Instance().RemoveByThreadID(0);

            try
            {
                ClientConnections.Instance().RemoveByThreadID(0);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException e)
            { }

        }

        #region readSimple
        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadBool()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readBool(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadShort()
        {
            //given
            short expected = short.MinValue;
            short result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readShort(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadInt()
        {
            //given
            int expected = int.MinValue;
            int result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readInt(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadLong()
        {
            //given
            long expected = long.MinValue;
            long result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readLong(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadUShort()
        {
            //given
            ushort expected = ushort.MaxValue;
            ushort result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUShort(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadUInt()
        {
            //given
            uint expected = uint.MaxValue;
            uint result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUInt(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadULong()
        {
            //given
            ulong expected = ulong.MaxValue;
            ulong result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readULong(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadByte()
        {
            //given
            byte expected = byte.MaxValue;
            byte result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readByte(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadSByte()
        {
            //given
            sbyte expected = sbyte.MinValue;
            sbyte result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readSByte(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadChar()
        {
            //given
            char expected = 'x';
            char result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readChar(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadString()
        {
            //given
            string expected = "napis testowy";
            string result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readString(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadDecimal()
        {
            //given
            decimal expected = decimal.MinValue;
            decimal result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDecimal(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadFloat()
        {
            //given
            float expected = float.MinValue;
            float result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readFloat(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieve")]
        [TestMethod]
        public void ShouldReadDouble()
        {
            //given
            double expected = double.MinValue;
            double result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDouble(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }
        #endregion

        #region readArray
        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadBoolArray()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readBoolArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadShortArray()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readShortArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadIntArray()
        {
            //given
            int[] expected = new int[numberOfElements];
            int[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.Next();
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readIntArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadLongArray()
        {
            //given
            long[] expected = new long[numberOfElements];
            long[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = int.MinValue - random.Next(1, int.MaxValue);
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readLongArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadUShortArray()
        {
            //given
            ushort[] expected = new ushort[numberOfElements];
            ushort[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt16(random.Next(ushort.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUShortArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadUIntArray()
        {
            //given
            uint[] expected = new uint[numberOfElements];
            uint[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt32(random.Next(int.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUIntArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadULongArray()
        {
            //given
            ulong[] expected = new ulong[numberOfElements];
            ulong[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = uint.MaxValue + Convert.ToUInt64(random.Next());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readULongArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadByteArray()
        {
            //given
            byte[] expected = new byte[numberOfElements];
            byte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToByte(random.Next(byte.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readByteArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadSByteArray()
        {
            //given
            sbyte[] expected = new sbyte[numberOfElements];
            sbyte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readSByteArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadCharArray()
        {
            //given
            char[] expected = new char[numberOfElements];
            char[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToChar(random.Next(9));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readCharArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadStringArray()
        {
            //given
            string[] expected = new string[numberOfElements];
            string[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = "napis testowy " + i.ToString();
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readStringArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadDecimalArray()
        {
            //given
            decimal[] expected = new decimal[numberOfElements];
            decimal[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDecimalArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadFloatArray()
        {
            //given
            float[] expected = new float[numberOfElements];
            float[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSingle(random.NextDouble());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readFloatArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadDoubleArray()
        {
            //given
            double[] expected = new double[numberOfElements];
            double[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.NextDouble();
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDoubleArray(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        #endregion

        #region readList
        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadBoolList()
        {
            //given
            List<bool> expected = new List<bool>();
            List<bool> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToBoolean(i % 2));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readBoolList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadShortList()
        {
            //given
            List<short> expected = new List<short>();
            List<short> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToInt16(random.Next(-32768, 32767)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readShortList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadIntList()
        {
            //given
            List<int> expected = new List<int>();
            List<int> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.Next());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readIntList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadLongList()
        {
            //given
            List<long> expected = new List<long>();
            List<long> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(int.MinValue - random.Next(1, int.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readLongList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadUShortList()
        {
            //given
            List<ushort> expected = new List<ushort>();
            List<ushort> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt16(random.Next(ushort.MaxValue)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUShortList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadUIntList()
        {
            //given
            List<uint> expected = new List<uint>();
            List<uint> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt32(random.Next(int.MaxValue)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUIntList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadULongList()
        {
            //given
            List<ulong> expected = new List<ulong>();
            List<ulong> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(uint.MaxValue + Convert.ToUInt64(random.Next()));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readULongList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadByteList()
        {
            //given
            List<byte> expected = new List<byte>();
            List<byte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToByte(random.Next(byte.MaxValue)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readByteList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadSByteList()
        {
            //given
            List<sbyte> expected = new List<sbyte>();
            List<sbyte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readSByteList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadCharList()
        {
            //given
            List<char> expected = new List<char>();
            List<char> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToChar(random.Next(9)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readCharList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadStringList()
        {
            //given
            List<string> expected = new List<string>();
            List<string> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add("napis testowy " + i.ToString());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readStringList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadDecimalList()
        {
            //given
            List<decimal> expected = new List<decimal>();
            List<decimal> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next()));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDecimalList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadFloatList()
        {
            //given
            List<float> expected = new List<float>();
            List<float> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSingle(random.NextDouble()));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readFloatList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieve")]
        [TestMethod]
        public void ShouldReadDoubleList()
        {
            //given
            List<double> expected = new List<double>();
            List<double> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.NextDouble());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDoubleList(out threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }
        #endregion

        #region noClientException
        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadBoolNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readBool(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadShortNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readShort(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadIntNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readInt(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadLongNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readLong(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadUShortNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readUShort(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadUIntNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readUInt(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadULongNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readULong(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadByteNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readByte(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadSByteNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readSByte(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadCharNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readChar(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadStringNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readString(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadDecimalNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readDecimal(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadFloatNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readFloat(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadDoubleNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readDouble(out threadID);

            }
            catch (ArgumentException e)
            { }
        }


        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadBoolArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readBoolArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadShortArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readShortArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadIntArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readIntArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadLongArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readLongArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadUShortArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readUShortArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadUIntArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readUIntArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadULongArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readULongArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadByteArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readByteArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadSByteArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readSByteArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadCharArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readCharArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadStringArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readStringArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadDecimalArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readDecimalArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadFloatArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readFloatArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadDoubleArrayNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readDoubleArray(out threadID);

            }
            catch (ArgumentException e)
            { }
        }



        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadBoolListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readBoolList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadShortListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readShortList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadIntListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readIntList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadLongListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readLongList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadUShortListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readUShortList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadUIntListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readUIntList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadULongListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readULongList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadByteListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readByteList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadSByteListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readSByteList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadCharListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readCharList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadStringListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readStringList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadDecimalListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readDecimalList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadFloatListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readFloatList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        [TestCategory("clientConnectionNoClientsException")]
        [TestMethod]
        public void ShouldReadDoubleListNoClientsException()
        {
            int threadID;
            try
            {
                ClientConnections.Instance().RemoveAll();
                ClientConnections.Instance().readDoubleList(out threadID);

            }
            catch (ArgumentException e)
            { }
        }

        #endregion

        #region typeNotMatchException

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadBoolTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readBool(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadShortTypeNotMatchException()
        {
            int expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readShort(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadIntTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readInt(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadLongTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readLong(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUShortTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUShort(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUIntTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUInt(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadULongTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readULong(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadByteTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readByte(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadSByteTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readSByte(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadCharTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readChar(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadStringTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readString(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDecimalTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDecimal(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadFloatTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readFloat(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDoubleTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDouble(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }



        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadBoolArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readBoolArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadShortArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readShortArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadIntArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readIntArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadLongArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readLongArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUShortArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUShortArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUIntArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUIntArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadULongArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readULongArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadByteArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readByteArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadSByteArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readSByteArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadCharArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readCharArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadStringArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readStringArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDecimalArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDecimalArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadFloatArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readFloatArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDoubleArrayTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDoubleArray(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }


        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadBoolListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readBoolList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadShortListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readShortList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadIntListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readIntList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadLongListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readLongList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUShortListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUShortList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUIntListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUIntList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadULongListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readULongList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadByteListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readByteList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadSByteListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readSByteList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadCharListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readCharList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadStringListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readStringList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDecimalListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDecimalList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadFloatListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readFloatList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDoubleListTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDoubleList(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }
        #endregion

        #region readFromThreadID
        #region readSimple
        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadBoolByID()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readBoolByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadShortByID()
        {
            //given
            short expected = short.MinValue;
            short result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readShortByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadIntByID()
        {
            //given
            int expected = int.MinValue;
            int result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readIntByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadLongByID()
        {
            //given
            long expected = long.MinValue;
            long result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readLongByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadUShortByID()
        {
            //given
            ushort expected = ushort.MaxValue;
            ushort result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUShortByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadUIntByID()
        {
            //given
            uint expected = uint.MaxValue;
            uint result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUIntByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadULongByID()
        {
            //given
            ulong expected = ulong.MaxValue;
            ulong result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readULongByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadByteByID()
        {
            //given
            byte expected = byte.MaxValue;
            byte result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readByteByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadSByteByID()
        {
            //given
            sbyte expected = sbyte.MinValue;
            sbyte result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readSByteByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadCharByID()
        {
            //given
            char expected = 'x';
            char result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readCharByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadStringByID()
        {
            //given
            string expected = "napis testowy";
            string result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readStringByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadDecimalByID()
        {
            //given
            decimal expected = decimal.MinValue;
            decimal result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDecimalByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadFloatByID()
        {
            //given
            float expected = float.MinValue;
            float result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readFloatByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadDoubleByID()
        {
            //given
            double expected = double.MinValue;
            double result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDoubleByID(threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }
        #endregion

        #region readArray
        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadBoolByIDArray()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readBoolArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadShortByIDArray()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readShortArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadIntByIDArray()
        {
            //given
            int[] expected = new int[numberOfElements];
            int[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.Next();
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readIntArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadLongByIDArray()
        {
            //given
            long[] expected = new long[numberOfElements];
            long[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = int.MinValue - random.Next(1, int.MaxValue);
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readLongArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadUShortByIDArray()
        {
            //given
            ushort[] expected = new ushort[numberOfElements];
            ushort[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt16(random.Next(ushort.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUShortArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadUIntByIDArray()
        {
            //given
            uint[] expected = new uint[numberOfElements];
            uint[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt32(random.Next(int.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUIntArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadULongByIDArray()
        {
            //given
            ulong[] expected = new ulong[numberOfElements];
            ulong[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = uint.MaxValue + Convert.ToUInt64(random.Next());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readULongArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadByteByIDArray()
        {
            //given
            byte[] expected = new byte[numberOfElements];
            byte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToByte(random.Next(byte.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readByteArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadSByteByIDArray()
        {
            //given
            sbyte[] expected = new sbyte[numberOfElements];
            sbyte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readSByteArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadCharByIDArray()
        {
            //given
            char[] expected = new char[numberOfElements];
            char[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToChar(random.Next(9));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readCharArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadStringByIDArray()
        {
            //given
            string[] expected = new string[numberOfElements];
            string[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = "napis testowy " + i.ToString();
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readStringArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadDecimalByIDArray()
        {
            //given
            decimal[] expected = new decimal[numberOfElements];
            decimal[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDecimalArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadFloatByIDArray()
        {
            //given
            float[] expected = new float[numberOfElements];
            float[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSingle(random.NextDouble());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readFloatArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionArrayTypeRecieve")]
        [TestMethod]
        public void ShouldReadDoubleByIDArray()
        {
            //given
            double[] expected = new double[numberOfElements];
            double[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.NextDouble();
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDoubleArrayByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        #endregion

        #region readList
        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadBoolByIDList()
        {
            //given
            List<bool> expected = new List<bool>();
            List<bool> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToBoolean(i % 2));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readBoolListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadShortByIDList()
        {
            //given
            List<short> expected = new List<short>();
            List<short> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToInt16(random.Next(-32768, 32767)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readShortListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadIntByIDList()
        {
            //given
            List<int> expected = new List<int>();
            List<int> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.Next());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readIntListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadLongByIDList()
        {
            //given
            List<long> expected = new List<long>();
            List<long> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(int.MinValue - random.Next(1, int.MaxValue));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readLongListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadUShortByIDList()
        {
            //given
            List<ushort> expected = new List<ushort>();
            List<ushort> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt16(random.Next(ushort.MaxValue)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUShortListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadUIntByIDList()
        {
            //given
            List<uint> expected = new List<uint>();
            List<uint> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt32(random.Next(int.MaxValue)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUIntListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadULongByIDList()
        {
            //given
            List<ulong> expected = new List<ulong>();
            List<ulong> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(uint.MaxValue + Convert.ToUInt64(random.Next()));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readULongListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadByteByIDList()
        {
            //given
            List<byte> expected = new List<byte>();
            List<byte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToByte(random.Next(byte.MaxValue)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readByteListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadSByteByIDList()
        {
            //given
            List<sbyte> expected = new List<sbyte>();
            List<sbyte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readSByteListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadCharByIDList()
        {
            //given
            List<char> expected = new List<char>();
            List<char> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToChar(random.Next(9)));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readCharListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadStringByIDList()
        {
            //given
            List<string> expected = new List<string>();
            List<string> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add("napis testowy " + i.ToString());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readStringListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadDecimalByIDList()
        {
            //given
            List<decimal> expected = new List<decimal>();
            List<decimal> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next()));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDecimalListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadFloatByIDList()
        {
            //given
            List<float> expected = new List<float>();
            List<float> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSingle(random.NextDouble()));
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readFloatListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestCategory("clientConnectionListTypeRecieveFromID")]
        [TestMethod]
        public void ShouldReadDoubleByIDList()
        {
            //given
            List<double> expected = new List<double>();
            List<double> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.NextDouble());
            }
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDoubleListByID(threadID);

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToSend, threadID);
        }
        #endregion

        #region readByIDNoSuchIDException
        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadBoolByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readBoolByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadShortByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readShortByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadIntByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readIntByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadLongByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readLongByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadUShortByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readUShortByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadUIntByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readUIntByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadULongByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readULongByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadByteByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readByteByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadSByteByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readSByteByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadCharByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readCharByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadStringByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readStringByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadDecimalByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readDecimalByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadFloatByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readFloatByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadDoubleByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readDoubleByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }



        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadBoolArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readBoolArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadShortArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readShortArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadIntArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readIntArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadLongArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readLongArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadUShortArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readUShortArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadUIntArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readUIntArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadULongArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readULongArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadByteArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readByteArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadSByteArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readSByteArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadCharArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readCharArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadStringArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readStringArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadDecimalArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readDecimalArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadFloatArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readFloatArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadDoubleArrayByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readDoubleArrayByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }



        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadBoolListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readBoolListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadShortListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readShortListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadIntListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readIntListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadLongListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readLongListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadUShortListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readUShortListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadUIntListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readUIntListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadULongListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readULongListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadByteListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readByteListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadSByteListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readSByteListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadCharListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readCharListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadStringListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readStringListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadDecimalListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readDecimalListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadFloatListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readFloatListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeRecieveFromIDNoSuchIDException")]
        [TestMethod]
        public void ShouldReadDoubleListByIDNoSuchIDException()
        {
            //given

            int threadID = connectedClients.Count;

            try
            {
                ClientConnections.Instance().readDoubleListByID(threadID);
                Assert.Fail();
            }
            catch (ArgumentException)
            { }

        }
        #endregion

        #region readByIDTypeNotMatchException
        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadBoolByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readBoolByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadShortByIDTypeNotMatchException()
        {
            int expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readShortByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadIntByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readIntByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadLongByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readLongByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUShortByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUShortByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUIntByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUIntByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadULongByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readULongByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadByteByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readByteByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadSByteByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readSByteByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadCharByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readCharByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadStringByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readStringByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDecimalByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDecimalByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadFloatByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readFloatByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDoubleByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDoubleByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }



        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadBoolArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readBoolArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadShortArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readShortArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadIntArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readIntArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadLongArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readLongArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUShortArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUShortArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUIntArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUIntArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadULongArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readULongArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadByteArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readByteArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadSByteArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readSByteArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadCharArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readCharArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadStringArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readStringArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDecimalArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDecimalArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadFloatArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readFloatArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDoubleArrayByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDoubleArrayByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }


        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadBoolListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readBoolListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadShortListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readShortListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadIntListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readIntListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadLongListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readLongListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUShortListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUShortListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadUIntListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readUIntListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadULongListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readULongListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadByteListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readByteListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadSByteListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readSByteListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadCharListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readCharListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadStringListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readStringListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDecimalListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDecimalListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadFloatListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readFloatListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

        [TestCategory("clientConnectionTypeNotMatchException")]
        [TestMethod]
        public void ShouldReadDoubleListByIDTypeNotMatchException()
        {
            short expected = 2;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID = connectedClients.Count - 1;

            //when
            connectedClients[indexToSend].send(expected);
            try
            {
                ClientConnections.Instance().readDoubleListByID(threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }
        #endregion

        #endregion

        #region sendTests

        #region simpleSend
        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendBool()
        {
            //given
            bool expected = true;
            bool result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendBool(expected, out threadID);
            ClientConnections.Instance().sendBool(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveBool();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendShort()
        {
            //given
            short expected = short.MinValue;
            short result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendShort(expected, out threadID);
            ClientConnections.Instance().sendShort(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveShort();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendInt()
        {
            //given
            int expected = int.MinValue;
            int result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendInt(expected, out threadID);
            ClientConnections.Instance().sendInt(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveInt();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendLong()
        {
            //given
            long expected = long.MinValue;
            long result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendLong(expected, out threadID);
            ClientConnections.Instance().sendLong(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveLong();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendUShort()
        {
            //given
            ushort expected = ushort.MaxValue;
            ushort result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendUShort(expected, out threadID);
            ClientConnections.Instance().sendUShort(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveUShort();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendUInt()
        {
            //given
            uint expected = uint.MaxValue;
            uint result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendUInt(expected, out threadID);
            ClientConnections.Instance().sendUInt(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveUInt();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendULong()
        {
            //given
            ulong expected = ulong.MaxValue;
            ulong result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendULong(expected, out threadID);
            ClientConnections.Instance().sendULong(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveULong();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendByte()
        {
            //given
            byte expected = byte.MaxValue;
            byte result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendByte(expected, out threadID);
            ClientConnections.Instance().sendByte(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveByte();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendSByte()
        {
            //given
            sbyte expected = sbyte.MinValue;
            sbyte result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendSByte(expected, out threadID);
            ClientConnections.Instance().sendSByte(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveSByte();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendChar()
        {
            //given
            char expected = 'x';
            char result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendChar(expected, out threadID);
            ClientConnections.Instance().sendChar(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveChar();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendString()
        {
            //given
            string expected = "napis testowy";
            string result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendString(expected, out threadID);
            ClientConnections.Instance().sendString(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveString();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendDecimal()
        {
            //given
            decimal expected = decimal.MinValue;
            decimal result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendDecimal(expected, out threadID);
            ClientConnections.Instance().sendDecimal(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveDecimal();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendFloat()
        {
            //given
            float expected = float.MinValue;
            float result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendFloat(expected, out threadID);
            ClientConnections.Instance().sendFloat(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveFloat();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSend")]
        [TestMethod]
        public void ShouldSendDouble()
        {
            //given
            double expected = double.MinValue;
            double result;
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendDouble(expected, out threadID);
            ClientConnections.Instance().sendDouble(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveDouble();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        #endregion

        #region arraySend
        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendBoolArray()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendBoolArray(expected, out threadID);
            ClientConnections.Instance().sendBoolArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfBools();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendShortArray()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendShortArray(expected, out threadID);
            ClientConnections.Instance().sendShortArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfShorts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendIntArray()
        {
            //given
            int[] expected = new int[numberOfElements];
            int[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.Next();
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendIntArray(expected, out threadID);
            ClientConnections.Instance().sendIntArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfInts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendLongArray()
        {
            //given
            long[] expected = new long[numberOfElements];
            long[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = int.MinValue - random.Next(1, int.MaxValue);
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendLongArray(expected, out threadID);
            ClientConnections.Instance().sendLongArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfLongs();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendUShortArray()
        {
            //given
            ushort[] expected = new ushort[numberOfElements];
            ushort[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt16(random.Next(ushort.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendUShortArray(expected, out threadID);
            ClientConnections.Instance().sendUShortArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfUShorts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendUIntArray()
        {
            //given
            uint[] expected = new uint[numberOfElements];
            uint[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt32(random.Next(int.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendUIntArray(expected, out threadID);
            ClientConnections.Instance().sendUIntArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfUInts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendULongArray()
        {
            //given
            ulong[] expected = new ulong[numberOfElements];
            ulong[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = uint.MaxValue + Convert.ToUInt64(random.Next());
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendULongArray(expected, out threadID);
            ClientConnections.Instance().sendULongArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfULongs();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendByteArray()
        {
            //given
            byte[] expected = new byte[numberOfElements];
            byte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToByte(random.Next(byte.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendByteArray(expected, out threadID);
            ClientConnections.Instance().sendByteArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfBytes();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendSByteArray()
        {
            //given
            sbyte[] expected = new sbyte[numberOfElements];
            sbyte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendSByteArray(expected, out threadID);
            ClientConnections.Instance().sendSByteArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfSBytes();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendCharArray()
        {
            //given
            char[] expected = new char[numberOfElements];
            char[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToChar(random.Next(9));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendCharArray(expected, out threadID);
            ClientConnections.Instance().sendCharArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfChars();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendStringArray()
        {
            //given
            string[] expected = new string[numberOfElements];
            string[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = "napis testowy " + i.ToString();
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendStringArray(expected, out threadID);
            ClientConnections.Instance().sendStringArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfStrings();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendDecimalArray()
        {
            //given
            decimal[] expected = new decimal[numberOfElements];
            decimal[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next());
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendDecimalArray(expected, out threadID);
            ClientConnections.Instance().sendDecimalArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfDecimals();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendFloatArray()
        {
            //given
            float[] expected = new float[numberOfElements];
            float[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSingle(random.NextDouble());
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendFloatArray(expected, out threadID);
            ClientConnections.Instance().sendFloatArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfFloats();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSend")]
        [TestMethod]
        public void ShouldSendDoubleArray()
        {
            //given
            double[] expected = new double[numberOfElements];
            double[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.NextDouble();
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendDoubleArray(expected, out threadID);
            ClientConnections.Instance().sendDoubleArray(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfDoubles();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        #endregion

        #region listSend
        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendBoolList()
        {
            //given
            List<bool> expected = new List<bool>();
            List<bool> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToBoolean(i % 2));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendBoolList(expected, out threadID);
            ClientConnections.Instance().sendBoolList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfBools();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendShortList()
        {
            //given
            List<short> expected = new List<short>();
            List<short> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToInt16(random.Next(-32768, 32767)));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendShortList(expected, out threadID);
            ClientConnections.Instance().sendShortList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfShorts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendIntList()
        {
            //given
            List<int> expected = new List<int>();
            List<int> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.Next());
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendIntList(expected, out threadID);
            ClientConnections.Instance().sendIntList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfInts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendLongList()
        {
            //given
            List<long> expected = new List<long>();
            List<long> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(int.MinValue - random.Next(1, int.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendLongList(expected, out threadID);
            ClientConnections.Instance().sendLongList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfLongs();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendUShortList()
        {
            //given
            List<ushort> expected = new List<ushort>();
            List<ushort> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt16(random.Next(ushort.MaxValue)));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendUShortList(expected, out threadID);
            ClientConnections.Instance().sendUShortList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfUShorts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendUIntList()
        {
            //given
            List<uint> expected = new List<uint>();
            List<uint> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt32(random.Next(int.MaxValue)));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendUIntList(expected, out threadID);
            ClientConnections.Instance().sendUIntList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfUInts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendULongList()
        {
            //given
            List<ulong> expected = new List<ulong>();
            List<ulong> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(uint.MaxValue + Convert.ToUInt64(random.Next()));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendULongList(expected, out threadID);
            ClientConnections.Instance().sendULongList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfULongs();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendByteList()
        {
            //given
            List<byte> expected = new List<byte>();
            List<byte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToByte(random.Next(byte.MaxValue)));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendByteList(expected, out threadID);
            ClientConnections.Instance().sendByteList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfBytes();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendSByteList()
        {
            //given
            List<sbyte> expected = new List<sbyte>();
            List<sbyte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue)));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendSByteList(expected, out threadID);
            ClientConnections.Instance().sendSByteList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfSBytes();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendCharList()
        {
            //given
            List<char> expected = new List<char>();
            List<char> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToChar(random.Next(9)));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendCharList(expected, out threadID);
            ClientConnections.Instance().sendCharList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfChars();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendStringList()
        {
            //given
            List<string> expected = new List<string>();
            List<string> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add("napis testowy " + i.ToString());
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendStringList(expected, out threadID);
            ClientConnections.Instance().sendStringList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfStrings();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendDecimalList()
        {
            //given
            List<decimal> expected = new List<decimal>();
            List<decimal> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next()));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendDecimalList(expected, out threadID);
            ClientConnections.Instance().sendDecimalList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfDecimals();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendFloatList()
        {
            //given
            List<float> expected = new List<float>();
            List<float> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSingle(random.NextDouble()));
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendFloatList(expected, out threadID);
            ClientConnections.Instance().sendFloatList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfFloats();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSend")]
        [TestMethod]
        public void ShouldSendDoubleList()
        {
            //given
            List<double> expected = new List<double>();
            List<double> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.NextDouble());
            }
            int indexToRecieve = 1;
            int threadID;

            //when
            ClientConnections.Instance().sendDoubleList(expected, out threadID);
            ClientConnections.Instance().sendDoubleList(expected, out threadID);

            result = connectedClients[indexToRecieve].recieveListOfDoubles();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }
        #endregion

        #region noClientsException
        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendBoolNoClientsException()
        {
            //given
            bool expected = true;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendBool(expected, out threadID);
                Assert.Fail();
            } catch(ArgumentException e)
            { }
           
        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendShortNoClientsException()
        {
            //given
            short expected = short.MinValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendShort(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendIntNoClientsException()
        {
            //given
            int expected = int.MinValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendInt(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendLongNoClientsException()
        {
            //given
            long expected = long.MinValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendLong(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendUShortNoClientsException()
        {
            //given
            ushort expected = ushort.MaxValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendUShort(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendUIntNoClientsException()
        {
            //given
            uint expected = uint.MaxValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendUInt(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendULongNoClientsException()
        {
            //given
            ulong expected = ulong.MaxValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendULong(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendByteNoClientsException()
        {
            //given
            byte expected = byte.MaxValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendByte(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendSByteNoClientsException()
        {
            //given
            sbyte expected = sbyte.MinValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendSByte(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendCharNoClientsException()
        {
            //given
            char expected = 'x';

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendChar(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendStringNoClientsException()
        {
            //given
            string expected = "napis testowy";

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendString(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendDecimalNoClientsException()
        {
            //given
            decimal expected = decimal.MinValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendDecimal(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendFloatNoClientsException()
        {
            //given
            float expected = float.MinValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendFloat(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendDoubleNoClientsException()
        {
            //given
            double expected = double.MinValue;

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendDouble(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }


        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendBoolArrayNoClientsException()
        {
            //given
            bool[] expected = new bool[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendBoolArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendShortArrayNoClientsException()
        {
            //given
            short[] expected = new short[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendShortArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendIntArrayNoClientsException()
        {
            //given
            int[] expected = new int[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendIntArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendLongArrayNoClientsException()
        {
            //given
            long[] expected = new long[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendLongArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendUShortArrayNoClientsException()
        {
            //given
            ushort[] expected = new ushort[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendUShortArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendUIntArrayNoClientsException()
        {
            //given
            uint[] expected = new uint[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendUIntArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendULongArrayNoClientsException()
        {
            //given
            ulong[] expected = new ulong[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendULongArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendByteArrayNoClientsException()
        {
            //given
            byte[] expected = new byte[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendByteArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendSByteArrayNoClientsException()
        {
            //given
            sbyte[] expected = new sbyte[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendSByteArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendCharArrayNoClientsException()
        {
            //given
            char[] expected = new char[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendCharArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendStringArrayNoClientsException()
        {
            //given
            string[] expected = new string[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendStringArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendDecimalArrayNoClientsException()
        {
            //given
            decimal[] expected = new decimal[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendDecimalArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendFloatArrayNoClientsException()
        {
            //given
            float[] expected = new float[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendFloatArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendDoubleArrayNoClientsException()
        {
            //given
            double[] expected = new double[numberOfElements];

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendDoubleArray(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }



        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendBoolListNoClientsException()
        {
            //given
            List<bool> expected = new List<bool>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendBoolList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendShortListNoClientsException()
        {
            //given
            List<short> expected = new List<short>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendShortList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendIntListNoClientsException()
        {
            //given
            List<int> expected = new List<int>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendIntList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendLongListNoClientsException()
        {
            //given
            List<long> expected = new List<long>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendLongList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendUShortListNoClientsException()
        {
            //given
            List<ushort> expected = new List<ushort>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendUShortList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendUIntListNoClientsException()
        {
            //given
            List<uint> expected = new List<uint>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendUIntList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendULongListNoClientsException()
        {
            //given
            List<ulong> expected = new List<ulong>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendULongList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendByteListNoClientsException()
        {
            //given
            List<byte> expected = new List<byte>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendByteList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendSByteListNoClientsException()
        {
            //given
            List<sbyte> expected = new List<sbyte>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendSByteList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendCharListNoClientsException()
        {
            //given
            List<char> expected = new List<char>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendCharList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendStringListNoClientsException()
        {
            //given
            List<string> expected = new List<string>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendStringList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendDecimalListNoClientsException()
        {
            //given
            List<decimal> expected = new List<decimal>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendDecimalList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendFloatListNoClientsException()
        {
            //given
            List<float> expected = new List<float>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendFloatList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoClientsException")]
        [TestMethod]
        public void ShouldSendDoubleListNoClientsException()
        {
            //given
            List<double> expected = new List<double>();

            int threadID;

            ClientConnections.Instance().RemoveAll();

            //when
            try
            {
                ClientConnections.Instance().sendDoubleList(expected, out threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }
        #endregion

        #region sendByID
        #region simpleSendByID
        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendBoolByID()
        {
            //given
            bool expected = true;
            bool result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendBoolByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveBool();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendShortByID()
        {
            //given
            short expected = short.MinValue;
            short result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when

            ClientConnections.Instance().sendShortByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveShort();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendIntByID()
        {
            //given
            int expected = int.MinValue;
            int result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendIntByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveInt();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendLongByID()
        {
            //given
            long expected = long.MinValue;
            long result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendLongByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveLong();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendUShortByID()
        {
            //given
            ushort expected = ushort.MaxValue;
            ushort result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendUShortByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveUShort();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendUIntByID()
        {
            //given
            uint expected = uint.MaxValue;
            uint result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when

            ClientConnections.Instance().sendUIntByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveUInt();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendULongByID()
        {
            //given
            ulong expected = ulong.MaxValue;
            ulong result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendULongByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveULong();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendByteByID()
        {
            //given
            byte expected = byte.MaxValue;
            byte result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendByteByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveByte();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendSByteByID()
        {
            //given
            sbyte expected = sbyte.MinValue;
            sbyte result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendSByteByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveSByte();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendCharByID()
        {
            //given
            char expected = 'x';
            char result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendCharByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveChar();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendStringByID()
        {
            //given
            string expected = "napis testowy";
            string result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendStringByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveString();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendDecimalByID()
        {
            //given
            decimal expected = decimal.MinValue;
            decimal result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendDecimalByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveDecimal();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendFloatByID()
        {
            //given
            float expected = float.MinValue;
            float result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendFloatByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveFloat();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionSimpleTypeSendByID")]
        [TestMethod]
        public void ShouldSendDoubleByID()
        {
            //given
            double expected = double.MinValue;
            double result;
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendDoubleByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveDouble();

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToRecieve, threadID);
        }
        #endregion

        #region arraySendByID
        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendBoolArrayByID()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendBoolArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfBools();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendShortArrayByID()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendShortArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfShorts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendIntArrayByID()
        {
            //given
            int[] expected = new int[numberOfElements];
            int[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.Next();
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendIntArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfInts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendLongArrayByID()
        {
            //given
            long[] expected = new long[numberOfElements];
            long[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = int.MinValue - random.Next(1, int.MaxValue);
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendLongArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfLongs();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendUShortArrayByID()
        {
            //given
            ushort[] expected = new ushort[numberOfElements];
            ushort[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt16(random.Next(ushort.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendUShortArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfUShorts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendUIntArrayByID()
        {
            //given
            uint[] expected = new uint[numberOfElements];
            uint[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt32(random.Next(int.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendUIntArrayByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfUInts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendULongArrayByID()
        {
            //given
            ulong[] expected = new ulong[numberOfElements];
            ulong[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = uint.MaxValue + Convert.ToUInt64(random.Next());
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendULongArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfULongs();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendByteArrayByID()
        {
            //given
            byte[] expected = new byte[numberOfElements];
            byte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToByte(random.Next(byte.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendByteArrayByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfBytes();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendSByteArrayByID()
        {
            //given
            sbyte[] expected = new sbyte[numberOfElements];
            sbyte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendSByteArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfSBytes();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendCharArrayByID()
        {
            //given
            char[] expected = new char[numberOfElements];
            char[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToChar(random.Next(9));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendCharArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfChars();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendStringArrayByID()
        {
            //given
            string[] expected = new string[numberOfElements];
            string[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = "napis testowy " + i.ToString();
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendStringArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfStrings();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendDecimalArrayByID()
        {
            //given
            decimal[] expected = new decimal[numberOfElements];
            decimal[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next());
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendDecimalArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfDecimals();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendFloatArrayByID()
        {
            //given
            float[] expected = new float[numberOfElements];
            float[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSingle(random.NextDouble());
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendFloatArrayByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveArrayOfFloats();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionArrayTypeSendByID")]
        [TestMethod]
        public void ShouldSendDoubleArrayByID()
        {
            //given
            double[] expected = new double[numberOfElements];
            double[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.NextDouble();
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendDoubleArrayByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveArrayOfDoubles();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }
        #endregion

        #region listSendByID
        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendBoolListByID()
        {
            //given
            List<bool> expected = new List<bool>();
            List<bool> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToBoolean(i % 2));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendBoolListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfBools();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendShortListByID()
        {
            //given
            List<short> expected = new List<short>();
            List<short> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToInt16(random.Next(-32768, 32767)));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendShortListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfShorts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendIntListByID()
        {
            //given
            List<int> expected = new List<int>();
            List<int> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.Next());
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendIntListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfInts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendLongListByID()
        {
            //given
            List<long> expected = new List<long>();
            List<long> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(int.MinValue - random.Next(1, int.MaxValue));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendLongListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfLongs();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendUShortListByID()
        {
            //given
            List<ushort> expected = new List<ushort>();
            List<ushort> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt16(random.Next(ushort.MaxValue)));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendUShortListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfUShorts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendUIntListByID()
        {
            //given
            List<uint> expected = new List<uint>();
            List<uint> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt32(random.Next(int.MaxValue)));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendUIntListByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveListOfUInts();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendULongListByID()
        {
            //given
            List<ulong> expected = new List<ulong>();
            List<ulong> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(uint.MaxValue + Convert.ToUInt64(random.Next()));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendULongListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfULongs();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendByteListByID()
        {
            //given
            List<byte> expected = new List<byte>();
            List<byte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToByte(random.Next(byte.MaxValue)));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendByteListByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveListOfBytes();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendSByteListByID()
        {
            //given
            List<sbyte> expected = new List<sbyte>();
            List<sbyte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue)));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendSByteListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfSBytes();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendCharListByID()
        {
            //given
            List<char> expected = new List<char>();
            List<char> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToChar(random.Next(9)));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendCharListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfChars();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendStringListByID()
        {
            //given
            List<string> expected = new List<string>();
            List<string> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add("napis testowy " + i.ToString());
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendStringListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfStrings();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendDecimalListByID()
        {
            //given
            List<decimal> expected = new List<decimal>();
            List<decimal> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next()));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendDecimalListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfDecimals();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendFloatListByID()
        {
            //given
            List<float> expected = new List<float>();
            List<float> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSingle(random.NextDouble()));
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendFloatListByID(expected, threadID);


            result = connectedClients[indexToRecieve].recieveListOfFloats();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }

        [TestCategory("clientConnectionListTypeSendByID")]
        [TestMethod]
        public void ShouldSendDoubleListByID()
        {
            //given
            List<double> expected = new List<double>();
            List<double> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.NextDouble());
            }
            int indexToRecieve = 1;
            int threadID = indexToRecieve;

            //when
            ClientConnections.Instance().sendDoubleListByID(expected, threadID);

            result = connectedClients[indexToRecieve].recieveListOfDoubles();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
            Assert.AreEqual(indexToRecieve, threadID);
        }
        #endregion

        #region noSuchIDException
        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendBoolNoSuchIDException()
        {
            //given
            bool expected = true;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendBoolByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendShortNoSuchIDException()
        {
            //given
            short expected = short.MinValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendShortByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendIntNoSuchIDException()
        {
            //given
            int expected = int.MinValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendIntByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendLongNoSuchIDException()
        {
            //given
            long expected = long.MinValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendLongByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendUShortNoSuchIDException()
        {
            //given
            ushort expected = ushort.MaxValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendUShortByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendUIntNoSuchIDException()
        {
            //given
            uint expected = uint.MaxValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendUIntByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendULongNoSuchIDException()
        {
            //given
            ulong expected = ulong.MaxValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendULongByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendByteNoSuchIDException()
        {
            //given
            byte expected = byte.MaxValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendByteByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendSByteNoSuchIDException()
        {
            //given
            sbyte expected = sbyte.MinValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendSByteByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendCharNoSuchIDException()
        {
            //given
            char expected = 'x';

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendCharByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendStringNoSuchIDException()
        {
            //given
            string expected = "napis testowy";

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendStringByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendDecimalNoSuchIDException()
        {
            //given
            decimal expected = decimal.MinValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendDecimalByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendFloatNoSuchIDException()
        {
            //given
            float expected = float.MinValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendFloatByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionSimpleTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendDoubleNoSuchIDException()
        {
            //given
            double expected = double.MinValue;

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendDoubleByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }


        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendBoolArrayByIDNoSuchIDException()
        {
            //given
            bool[] expected = new bool[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendBoolArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendShortArrayByIDNoSuchIDException()
        {
            //given
            short[] expected = new short[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendShortArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendIntArrayByIDNoSuchIDException()
        {
            //given
            int[] expected = new int[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendIntArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendLongArrayByIDNoSuchIDException()
        {
            //given
            long[] expected = new long[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendLongArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendUShortArrayByIDNoSuchIDException()
        {
            //given
            ushort[] expected = new ushort[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendUShortArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendUIntArrayByIDNoSuchIDException()
        {
            //given
            uint[] expected = new uint[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendUIntArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendULongArrayByIDNoSuchIDException()
        {
            //given
            ulong[] expected = new ulong[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendULongArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendByteArrayByIDNoSuchIDException()
        {
            //given
            byte[] expected = new byte[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendByteArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendSByteArrayByIDNoSuchIDException()
        {
            //given
            sbyte[] expected = new sbyte[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendSByteArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendCharArrayByIDNoSuchIDException()
        {
            //given
            char[] expected = new char[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendCharArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendStringArrayByIDNoSuchIDException()
        {
            //given
            string[] expected = new string[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendStringArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendDecimalArrayByIDNoSuchIDException()
        {
            //given
            decimal[] expected = new decimal[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendDecimalArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendFloatArrayByIDNoSuchIDException()
        {
            //given
            float[] expected = new float[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendFloatArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionArrayByIDTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendDoubleArrayByIDNoSuchIDException()
        {
            //given
            double[] expected = new double[numberOfElements];

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendDoubleArrayByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }



        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendBoolListNoSuchIDException()
        {
            //given
            List<bool> expected = new List<bool>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendBoolListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendShortListNoSuchIDException()
        {
            //given
            List<short> expected = new List<short>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendShortListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendIntListNoSuchIDException()
        {
            //given
            List<int> expected = new List<int>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendIntListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendLongListNoSuchIDException()
        {
            //given
            List<long> expected = new List<long>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendLongListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendUShortListNoSuchIDException()
        {
            //given
            List<ushort> expected = new List<ushort>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendUShortListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendUIntListNoSuchIDException()
        {
            //given
            List<uint> expected = new List<uint>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendUIntListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendULongListNoSuchIDException()
        {
            //given
            List<ulong> expected = new List<ulong>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendULongListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendByteListNoSuchIDException()
        {
            //given
            List<byte> expected = new List<byte>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendByteListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendSByteListNoSuchIDException()
        {
            //given
            List<sbyte> expected = new List<sbyte>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendSByteListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendCharListNoSuchIDException()
        {
            //given
            List<char> expected = new List<char>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendCharListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendStringListNoSuchIDException()
        {
            //given
            List<string> expected = new List<string>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendStringListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendDecimalListNoSuchIDException()
        {
            //given
            List<decimal> expected = new List<decimal>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendDecimalListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendFloatListNoSuchIDException()
        {
            //given
            List<float> expected = new List<float>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendFloatListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }

        [TestCategory("clientConnectionListTypeSendNoSuchIDException")]
        [TestMethod]
        public void ShouldSendDoubleListNoSuchIDException()
        {
            //given
            List<double> expected = new List<double>();

            int threadID = connectedClients.Count;

            

            //when
            try
            {
                ClientConnections.Instance().sendDoubleListByID(expected, threadID);
                Assert.Fail();
            }
            catch (ArgumentException e)
            { }

        }
        #endregion

        #endregion

        #endregion
    }
}
