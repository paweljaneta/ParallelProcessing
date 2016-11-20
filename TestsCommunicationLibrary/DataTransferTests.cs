using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net.Sockets;
using System.Net;
using communicationLibrary;
using System.Collections.Generic;

namespace TestsCommunicationLibrary
{
    [TestClass]
    public class DataTransferTests
    {
        private TcpListener server;
        private TcpClient serverConnection, clientConnection;
        private BinaryReader serverInStream, clientInStream;
        private BinaryWriter serverOutStream, clientOutStream;

        private string serverIP = "127.0.0.1", clientIP = "127.0.0.1";
        private int port = 1807;

        private DataTransfer clientDataTransferConnection, serverDataTransferConnection;

        private int numberOfElements = 100;
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

            clientDataTransferConnection = new DataTransfer(clientInStream, clientOutStream);
            serverDataTransferConnection = new DataTransfer(serverInStream, serverOutStream);

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

        #region simpleTypeSendTests
        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendBool()
        {
            //given
            bool expected = true;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.boolTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadBoolean());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendShort()
        {
            //given
            short expected = short.Parse("-258");
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.shortTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadInt16());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendInt()
        {
            //given
            int expected = -40000;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.intTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadInt32());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendLong()
        {
            //given
            long expected = -3147483648L;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.longTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadInt64());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendUShort()
        {
            //given
            ushort expected = ushort.Parse("65535");
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.ushortTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadUInt16());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendUInt()
        {
            //given
            uint expected = 4294967295;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.uintTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadUInt32());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendULong()
        {
            //given
            ulong expected = 18446744073709551615L;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.ulongTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadUInt64());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendByte()
        {
            //given
            byte expected = byte.MaxValue;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.byteTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadByte());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendSByte()
        {
            //given
            sbyte expected = sbyte.MinValue;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.sbyteTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadSByte());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendChar()
        {
            //given
            char expected = 'x';
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.charTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadChar());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendString()
        {
            //given
            string expected = "napis testowy";
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.stringTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadString());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendDecimal()
        {
            //given
            decimal expected = decimal.MinValue;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.decimalTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadDecimal());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendFloat()
        {
            //given
            float expected = float.MinValue;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.floatTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadSingle());
        }

        [TestCategory("simpleTypeSend")]
        [TestMethod]
        public void clientShouldSendDouble()
        {
            //given
            double expected = double.MinValue;
            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.doubleTransfer, serverInStream.ReadString());
            Assert.AreEqual(expected, serverInStream.ReadDouble());
        }
        #endregion

        #region arrayTypeSendTests

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendBoolArray()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.boolArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new bool[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadBoolean();
                Assert.AreEqual(expected[i], result[i]);
            }

        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendShortArray()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.shortArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new short[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadInt16();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendIntArray()
        {
            //given
            int[] expected = new int[numberOfElements];
            int[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.Next();
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.intArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new int[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadInt32();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendLongArray()
        {
            //given
            long[] expected = new long[numberOfElements];
            long[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = int.MinValue - random.Next(1, int.MaxValue);
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.longArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new long[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadInt64();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendUShortArray()
        {
            //given
            ushort[] expected = new ushort[numberOfElements];
            ushort[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt16(random.Next(ushort.MaxValue));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.ushortArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new ushort[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadUInt16();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendUIntArray()
        {
            //given
            uint[] expected = new uint[numberOfElements];
            uint[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt32(random.Next(int.MaxValue));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.uintArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new uint[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadUInt32();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendULongArray()
        {
            //given
            ulong[] expected = new ulong[numberOfElements];
            ulong[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = uint.MaxValue + Convert.ToUInt64(random.Next());
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.ulongArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new ulong[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadUInt64();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendByteArray()
        {
            //given
            byte[] expected = new byte[numberOfElements];
            byte[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToByte(random.Next(byte.MaxValue));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.byteArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new byte[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadByte();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendSByteArray()
        {
            //given
            sbyte[] expected = new sbyte[numberOfElements];
            sbyte[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.sbyteArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new sbyte[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadSByte();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendCharArray()
        {
            //given
            char[] expected = new char[numberOfElements];
            char[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToChar(random.Next(9));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.charArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new char[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadChar();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendStringArray()
        {
            //given
            string[] expected = new string[numberOfElements];
            string[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = "napis testowy " + i.ToString();
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.stringArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new string[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadString();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendDecimalArray()
        {
            //given
            decimal[] expected = new decimal[numberOfElements];
            decimal[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next());
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.decimalArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new decimal[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadDecimal();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendFloatArray()
        {
            //given
            float[] expected = new float[numberOfElements];
            float[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSingle(random.NextDouble());
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.floatArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new float[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadSingle();
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeSend")]
        [TestMethod]
        public void clientShouldSendDoubleArray()
        {
            //given
            double[] expected = new double[numberOfElements];
            double[] result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.NextDouble();
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.doubleArrayTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new double[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = serverInStream.ReadDouble();
                Assert.AreEqual(expected[i], result[i]);
            }
        }
        #endregion

        #region listTypeSendTests

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendBoolList()
        {
            //given
            List<bool> expected = new List<bool>();
            List<bool> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToBoolean(i % 2));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.boolListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<bool>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadBoolean());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendShortList()
        {
            //given
            List<short> expected = new List<short>();
            List<short> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToInt16(random.Next(-32768, 32767)));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.shortListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<short>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadInt16());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendIntList()
        {
            //given
            List<int> expected = new List<int>();
            List<int> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.Next());
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.intListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<int>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadInt32());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendLongList()
        {
            //given
            List<long> expected = new List<long>();
            List<long> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToInt64(int.MinValue) - Convert.ToInt64(random.Next(1, int.MaxValue)));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.longListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<long>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadInt64());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendUShortList()
        {
            //given
            List<ushort> expected = new List<ushort>();
            List<ushort> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt16(random.Next(ushort.MaxValue)));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.ushortListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<ushort>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadUInt16());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendUIntList()
        {
            //given
            List<uint> expected = new List<uint>();
            List<uint> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt32(random.Next(int.MaxValue)));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.uintListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<uint>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadUInt32());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendULongList()
        {
            //given
            List<ulong> expected = new List<ulong>();
            List<ulong> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(uint.MaxValue + Convert.ToUInt64(random.Next()));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.ulongListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<ulong>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadUInt64());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendByteList()
        {
            //given
            List<byte> expected = new List<byte>();
            List<byte> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToByte(random.Next(byte.MaxValue)));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.byteListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<byte>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadByte());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendSByteList()
        {
            //given
            List<sbyte> expected = new List<sbyte>();
            List<sbyte> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue)));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.sbyteListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<sbyte>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadSByte());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendCharList()
        {
            //given
            List<char> expected = new List<char>();
            List<char> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToChar(random.Next(9)));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.charListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<char>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadChar());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendStringList()
        {
            //given
            List<string> expected = new List<string>();
            List<string> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add("napis testowy " + i.ToString());
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.stringListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<string>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadString());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendDecimalList()
        {
            //given
            List<decimal> expected = new List<decimal>();
            List<decimal> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next()));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.decimalListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<decimal>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadDecimal());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendFloatList()
        {
            //given
            List<float> expected = new List<float>();
            List<float> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSingle(random.NextDouble()));
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.floatListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<float>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadSingle());
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeSend")]
        [TestMethod]
        public void clientShouldSendDoubleList()
        {
            //given
            List<double> expected = new List<double>();
            List<double> result;
            int count;
            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.NextDouble());
            }

            //when
            clientDataTransferConnection.send(expected);
            //then
            Assert.AreEqual(Messages.doubleListTransfer, serverInStream.ReadString());

            count = serverInStream.ReadInt32();
            Assert.AreEqual(numberOfElements, count);

            result = new List<double>();

            for (int i = 0; i < count; i++)
            {
                result.Add(serverInStream.ReadDouble());
                Assert.AreEqual(expected[i], result[i]);
            }
        }
        #endregion

        #region simpleTypeRecieve

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveBool()
        {
            //given
            bool expected = true;
            bool result;

            //when
            serverOutStream.Write(Messages.boolTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveBool();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveBoolException()
        {
            //given
            bool expected = true;
            bool result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveBool();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveShort()
        {
            //given
            short expected = short.MinValue;
            short result;

            //when
            serverOutStream.Write(Messages.shortTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveShort();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveShortException()
        {
            //given
            short expected = short.MinValue;
            short result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveShort();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveInt()
        {
            //given
            int expected = int.MinValue;
            int result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveInt();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveIntException()
        {
            //given
            int expected = int.MinValue;
            int result;

            //when
            serverOutStream.Write(Messages.boolTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveInt();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveLong()
        {
            //given
            long expected = long.MinValue;
            long result;

            //when
            serverOutStream.Write(Messages.longTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveLong();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveLongException()
        {
            //given
            long expected = long.MinValue;
            long result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveLong();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUShort()
        {
            //given
            ushort expected = ushort.MaxValue;
            ushort result;

            //when
            serverOutStream.Write(Messages.ushortTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveUShort();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUShortException()
        {
            //given
           ushort expected = ushort.MaxValue;
            ushort result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveUShort();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUInt()
        {
            //given
            uint expected = uint.MaxValue;
            uint result;

            //when
            serverOutStream.Write(Messages.uintTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveUInt();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUIntException()
        {
            //given
            uint expected = uint.MaxValue;
            uint result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveUInt();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveULong()
        {
            //given
            ulong expected = ulong.MaxValue;
            ulong result;

            //when
            serverOutStream.Write(Messages.ulongTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveULong();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveULongException()
        {
            //given
            ulong expected = ulong.MaxValue;
            ulong result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveULong();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveByte()
        {
            //given
            byte expected = byte.MaxValue;
            byte result;

            //when
            serverOutStream.Write(Messages.byteTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveByte();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveByteException()
        {
            //given
            byte expected = byte.MaxValue;
            byte result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveByte();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveSByte()
        {
            //given
            sbyte expected = sbyte.MinValue;
            sbyte result;

            //when
            serverOutStream.Write(Messages.sbyteTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveSByte();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveSByteException()
        {
            //given
            sbyte expected = sbyte.MinValue;
            sbyte result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveSByte();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveChar()
        {
            //given
            char expected = 'x';
            char result;

            //when
            serverOutStream.Write(Messages.charTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveChar();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveCharException()
        {
            //given
            char expected = 'x' ;
            char result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveChar();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveString()
        {
            //given
            string expected = "napis testowy";
            string result;

            //when
            serverOutStream.Write(Messages.stringTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveString();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveStringException()
        {
            //given
            string expected = "napis testowy";
            string result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveString();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDecimal()
        {
            //given
            decimal expected = decimal.MinValue;
            decimal result;

            //when
            serverOutStream.Write(Messages.decimalTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveDecimal();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDecimalException()
        {
            //given
            decimal expected = decimal.MinValue;
            decimal result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveDecimal();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveFloat()
        {
            //given
            float expected = float.MinValue;
            float result;

            //when
            serverOutStream.Write(Messages.floatTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveFloat();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveFloatException()
        {
            //given
            float expected = float.MinValue;
            float result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveFloat();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDouble()
        {
            //given
            double expected = double.MinValue;
            double result;

            //when
            serverOutStream.Write(Messages.doubleTransfer);
            serverOutStream.Write(expected);

            result = clientDataTransferConnection.recieveDouble();
            //then
            Assert.AreEqual(expected, result);
        }

        [TestCategory("simpleTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveFloatDouble()
        {
            //given
            double expected = double.MinValue;
            double result;

            //when
            serverOutStream.Write(Messages.intTransfer);
            serverOutStream.Write(expected);
            try
            {
                result = clientDataTransferConnection.recieveDouble();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        #endregion

        #region arrayTypeRecieve

        #endregion

        #region listTypeRecieve

        #endregion
    }
}
