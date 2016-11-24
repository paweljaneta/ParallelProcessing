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
                result = ClientConnections.Instance().readBool(out threadID);
                Assert.Fail();
            }
            catch (TypeNotMatchException e)
            { }

        }

    }
}
