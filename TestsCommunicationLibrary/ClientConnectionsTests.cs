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


        private int numberOfArrayListElements = 5;

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
        [TestMethod]
        public void ShouldReadBoolArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readBoolArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadShortArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readShortArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadIntArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readIntArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadLongArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readLongArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadUShortArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUShortArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadUIntArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readUIntArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadULongArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readULongArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadByteArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readByteArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadSByteArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readSByteArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadCharArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readCharArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadStringArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readStringArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadDecimalArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDecimalArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadFloatArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readFloatArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
            Assert.AreEqual(indexToSend, threadID);
        }

        [TestMethod]
        public void ShouldReadDoubleArray()
        {
            //given
            bool expected = true;
            bool result;
            int indexToSend = connectedClients.Count - 1;
            int threadID;

            //when
            connectedClients[indexToSend].send(expected);

            result = ClientConnections.Instance().readDoubleArray(out threadID);

            //then
            Assert.AreEqual(expected, result);
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
