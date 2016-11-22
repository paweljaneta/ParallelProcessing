using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using System.IO;
using communicationLibrary;
using System.Threading;

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

        //private DataTransfer clientDataTransferConnection, serverDataTransferConnection;

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
        #endregion

    }
}
