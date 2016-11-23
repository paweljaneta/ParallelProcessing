using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using System.IO;
using communicationLibrary;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace TestsCommunicationLibrary
{
    [TestClass]
    public class ClientConnectionThreadTests
    {
        private TcpListener server;
        private TcpClient serverConnection, clientConnection;
        private BinaryReader serverInStream, clientInStream;
        private BinaryWriter serverOutStream, clientOutStream;

        private string serverIP = "127.0.0.1", clientIP = "127.0.0.1";
        private int port = 1807;

        private ClientConnectionThread clientConnectedToServer;
        private DataTransfer clientToServerTransfers;

        private int numberOfElements = 5;
        private int timeout = 20;
        Random random;

        [TestInitialize]
        public void TestInitialize()
        {
            server = new TcpListener(IPAddress.Parse(serverIP), port);
            server.Start();
            clientConnection = new TcpClient(clientIP, port);
            serverConnection = server.AcceptTcpClient();
            server.Stop(); //?
            serverInStream = new BinaryReader(serverConnection.GetStream());
            serverOutStream = new BinaryWriter(serverConnection.GetStream());
            clientInStream = new BinaryReader(clientConnection.GetStream());
            clientOutStream = new BinaryWriter(clientConnection.GetStream());

            clientConnectedToServer = new ClientConnectionThread(serverConnection, 0, 0);

            clientToServerTransfers = new DataTransfer(clientInStream, clientOutStream);

            random = new Random();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            serverInStream.Close();
            serverOutStream.Close();
            clientInStream.Close();
            clientOutStream.Close();

            clientConnection.Close();
            serverConnection.Close();

        }

        #region simpleRecieve
        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveBool()
        {
            //given
            bool expected = true;
            bool result;
            //when
            clientConnectedToServer.recieveBool();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readBool();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveShort()
        {
            //given
            short expected = short.MinValue;
            short result;
            //when
            clientConnectedToServer.recieveShort();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readShort();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveInt()
        {
            //given
            int expected = int.MinValue;
            int result;
            //when
            clientConnectedToServer.recieveInt();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readInt();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveLong()
        {
            //given
            long expected = long.MinValue;
            long result;
            //when
            clientConnectedToServer.recieveLong();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readLong();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveUShort()
        {
            //given
            ushort expected = ushort.MaxValue;
            ushort result;
            //when
            clientConnectedToServer.recieveUShort();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readUShort();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveUInt()
        {
            //given
            uint expected = uint.MaxValue;
            uint result;
            //when
            clientConnectedToServer.recieveUInt();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readUInt();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveULong()
        {
            //given
            ulong expected = ulong.MaxValue;
            ulong result;
            //when
            clientConnectedToServer.recieveULong();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readULong();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveByte()
        {
            //given
            byte expected = byte.MaxValue;
            byte result;
            //when
            clientConnectedToServer.recieveByte();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readByte();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveSByte()
        {
            //given
            sbyte expected = sbyte.MinValue;
            sbyte result;
            //when
            clientConnectedToServer.recieveSByte();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readSByte();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveChar()
        {
            //given
            char expected = 'x';
            char result;
            //when
            clientConnectedToServer.recieveChar();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readChar();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveString()
        {
            //given
            string expected = "napis testowy";
            string result;
            //when
            clientConnectedToServer.recieveString();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readString();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveDecimal()
        {
            //given
            decimal expected = decimal.MinValue;
            decimal result;
            //when
            clientConnectedToServer.recieveDecimal();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readDecimal();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveFloat()
        {
            //given
            float expected = float.MinValue;
            float result;
            //when
            clientConnectedToServer.recieveFloat();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readFloat();

            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveDouble()
        {
            //given
            double expected = double.MinValue;
            double result;
            //when
            clientConnectedToServer.recieveDouble();

            clientToServerTransfers.send(expected);

            while (!clientConnectedToServer.isDataRead())
            { }

            result = clientConnectedToServer.readDouble();

            //then
            Assert.AreEqual(expected, result);
        }



        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveBoolException()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }
            //when
            clientConnectedToServer.recieveBool();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readBool();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveShortException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveShort();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readShort();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveIntException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveInt();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readInt();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveLongException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveLong();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readLong();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveUShortException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveUShort();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readUShort();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveUIntException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveUInt();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readUInt();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveULongException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveULong();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readULong();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveByteException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveByte();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readByte();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveSByteException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveSByte();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readSByte();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveCharException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveChar();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readChar();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveStringException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveString();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readString();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveDecimalException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveDecimal();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readDecimal();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveFloatException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveFloat();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readFloat();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("simpleTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveDoubleException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveDouble();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readDouble();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        #endregion

        #region arrayRecieve
        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveBoolArray()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveBoolArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

           

            result = clientConnectedToServer.readBoolArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveShortArray()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }
            //when
            clientConnectedToServer.recieveShortArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readShortArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveIntArray()
        {
            //given
            int[] expected = new int[numberOfElements];
            int[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.Next();
            }
            //when
            clientConnectedToServer.recieveIntArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readIntArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveLongArray()
        {
            //given
            long[] expected = new long[numberOfElements];
            long[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = int.MinValue - random.Next(1, int.MaxValue);
            }
            //when
            clientConnectedToServer.recieveLongArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readLongArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveUShortArray()
        {
            //given
            ushort[] expected = new ushort[numberOfElements];
            ushort[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt16(random.Next(ushort.MaxValue));
            }
            //when
            clientConnectedToServer.recieveUShortArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readUShortArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveUIntArray()
        {
            //given
            uint[] expected = new uint[numberOfElements];
            uint[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt32(random.Next(int.MaxValue));
            }
            //when
            clientConnectedToServer.recieveUIntArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readUIntArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveULongArray()
        {
            //given
            ulong[] expected = new ulong[numberOfElements];
            ulong[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = uint.MaxValue + Convert.ToUInt64(random.Next());
            }
            //when
            clientConnectedToServer.recieveULongArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readULongArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveByteArray()
        {
            //given
            byte[] expected = new byte[numberOfElements];
            byte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToByte(random.Next(byte.MaxValue));
            }
            //when
            clientConnectedToServer.recieveByteArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readByteArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveSByteArray()
        {
            //given
            sbyte[] expected = new sbyte[numberOfElements];
            sbyte[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue));
            }
            //when
            clientConnectedToServer.recieveSByteArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readSByteArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveCharArray()
        {
            //given
            char[] expected = new char[numberOfElements];
            char[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToChar(random.Next(9));
            }
            //when
            clientConnectedToServer.recieveCharArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readCharArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveStringArray()
        {
            //given
            string[] expected = new string[numberOfElements];
            string[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = "napis testowy " + i.ToString();
            }
            //when
            clientConnectedToServer.recieveStringArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readStringArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveDecimalArray()
        {
            //given
            decimal[] expected = new decimal[numberOfElements];
            decimal[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next());
            }
            //when
            clientConnectedToServer.recieveDecimalArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readDecimalArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveFloatArray()
        {
            //given
            float[] expected = new float[numberOfElements];
            float[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSingle(random.NextDouble());
            }
            //when
            clientConnectedToServer.recieveFloatArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readFloatArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveDoubleArray()
        {
            //given
            double[] expected = new double[numberOfElements];
            double[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.NextDouble();
            }

            //when
            clientConnectedToServer.recieveDoubleArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readDoubleArray();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }



        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveBoolArrayException()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }
            //when
            clientConnectedToServer.recieveBoolArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readBoolArray();
                Assert.Fail();
            }
            catch(TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveShortArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveShortArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readShortArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveIntArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveIntArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
               clientConnectedToServer.readIntArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveLongArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveLongArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readLongArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveUShortArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveUShortArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readUShortArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveUIntArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveUIntArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readUIntArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveULongArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveULongArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
               clientConnectedToServer.readULongArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveByteArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveByteArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readByteArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveSByteArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveSByteArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readSByteArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveCharArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveCharArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readCharArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveStringArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveStringArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
               clientConnectedToServer.readStringArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveDecimalArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveDecimalArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readDecimalArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveFloatArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveFloatArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
               clientConnectedToServer.readFloatArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("arrayTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveDoubleArrayException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveDoubleArray();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readDoubleArray();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        #endregion

        #region listRecieve
        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveBoolList()
        {
            //given
            List<bool> expected = new List<bool>();
            List<bool> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToBoolean(i % 2));
            }
            //when
            clientConnectedToServer.recieveBoolList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }



            result = clientConnectedToServer.readBoolList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveShortList()
        {
            //given
            List<short> expected = new List<short>();
            List<short> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToInt16(random.Next(-32768, 32767)));
            }
            //when
            clientConnectedToServer.recieveShortList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readShortList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveIntList()
        {
            //given
            List<int> expected = new List<int>();
            List<int> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.Next());
            }
            //when
            clientConnectedToServer.recieveIntList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readIntList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveLongList()
        {
            //given
            List<long> expected = new List<long>();
            List<long> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(int.MinValue - random.Next(1, int.MaxValue));
            }
            //when
            clientConnectedToServer.recieveLongList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readLongList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveUShortList()
        {
            //given
            List<ushort> expected = new List<ushort>();
            List<ushort> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt16(random.Next(ushort.MaxValue)));
            }
            //when
            clientConnectedToServer.recieveUShortList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readUShortList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveUIntList()
        {
            //given
            List<uint> expected = new List<uint>();
            List<uint> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt32(random.Next(int.MaxValue)));
            }
            //when
            clientConnectedToServer.recieveUIntList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readUIntList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveULongList()
        {
            //given
            List<ulong> expected = new List<ulong>();
            List<ulong> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(uint.MaxValue + Convert.ToUInt64(random.Next()));
            }
            //when
            clientConnectedToServer.recieveULongList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readULongList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveByteList()
        {
            //given
            List<byte> expected = new List<byte>();
            List<byte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToByte(random.Next(byte.MaxValue)));
            }
            //when
            clientConnectedToServer.recieveByteList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readByteList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveSByteList()
        {
            //given
            List<sbyte> expected = new List<sbyte>();
            List<sbyte> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue)));
            }
            //when
            clientConnectedToServer.recieveSByteList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readSByteList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveCharList()
        {
            //given
            List<char> expected = new List<char>();
            List<char> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToChar(random.Next(9)));
            }
            //when
            clientConnectedToServer.recieveCharList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readCharList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveStringList()
        {
            //given
            List<string> expected = new List<string>();
            List<string> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add("napis testowy " + i.ToString());
            }
            //when
            clientConnectedToServer.recieveStringList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readStringList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveDecimalList()
        {
            //given
            List<decimal> expected = new List<decimal>();
            List<decimal> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next()));
            }
            //when
            clientConnectedToServer.recieveDecimalList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readDecimalList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveFloatList()
        {
            //given
            List<float> expected = new List<float>();
            List<float> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSingle(random.NextDouble()));
            }
            //when
            clientConnectedToServer.recieveFloatList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readFloatList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void ShouldRecieveDoubleList()
        {
            //given
            List<double> expected = new List<double>();
            List<double> result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.NextDouble());
            }

            //when
            clientConnectedToServer.recieveDoubleList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            result = clientConnectedToServer.readDoubleList();

            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }



        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveBoolListException()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }
            //when
            clientConnectedToServer.recieveBoolList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readBoolList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveShortListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveShortList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readShortList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveIntListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveIntList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readIntList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveLongListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveLongList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readLongList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveUShortListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveUShortList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readUShortList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveUIntListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveUIntList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readUIntList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveULongListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveULongList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readULongList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveByteListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveByteList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readByteList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveSByteListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveSByteList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readSByteList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveCharListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveCharList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readCharList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveStringListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveStringList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readStringList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveDecimalListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveDecimalList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readDecimalList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveFloatListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveFloatList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readFloatList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestCategory("listTypeRecieveException")]
        [TestMethod]
        public void ShouldRecieveDoubleListException()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }
            //when
            clientConnectedToServer.recieveDoubleList();

            clientToServerTransfers.send(expected);

            int counter = 0;
            while (!clientConnectedToServer.isDataRead())
            {
                counter++;
                Thread.Sleep(1);
                if (counter >= timeout)
                {
                    Assert.Fail();
                }
            }

            try
            {
                clientConnectedToServer.readDoubleList();
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
                Assert.AreEqual(1, 1);
            }
        }

        #endregion

    }
}
