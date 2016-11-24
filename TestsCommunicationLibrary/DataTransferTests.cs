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

        private int numberOfElements = 5;
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

            clientDataTransferConnection = new DataTransfer(clientConnection);
            serverDataTransferConnection = new DataTransfer(serverConnection);

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
            char expected = 'x';
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
        public void clientShouldRecieveDoubleException()
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
        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveBoolArray()
        {
            //given
            bool[] expected = new bool[numberOfElements];
            bool[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToBoolean(i % 2);
            }

            //when
            serverOutStream.Write(Messages.boolArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfBools();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveBoolArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfBools();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveShortArray()
        {
            //given
            short[] expected = new short[numberOfElements];
            short[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToInt16(random.Next(-32768, 32767));
            }

            //when
            serverOutStream.Write(Messages.shortArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfShorts();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveShortArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfShorts();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveIntArray()
        {
            //given
            int[] expected = new int[numberOfElements];
            int[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.Next();
            }

            //when
            serverOutStream.Write(Messages.intArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfInts();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveIntArrayException()
        {
            //when
            serverOutStream.Write(Messages.boolArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfInts();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveLongArray()
        {
            //given
            long[] expected = new long[numberOfElements];
            long[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = int.MinValue - random.Next(1, int.MaxValue);
            }

            //when
            serverOutStream.Write(Messages.longArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfLongs();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveLongArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfLongs();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUShortArray()
        {
            ///given
            ushort[] expected = new ushort[numberOfElements];
            ushort[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt16(random.Next(ushort.MaxValue));
            }

            //when
            serverOutStream.Write(Messages.ushortArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfUShorts();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUShortArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfUShorts();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUIntArray()
        {
            ///given
            uint[] expected = new uint[numberOfElements];
            uint[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToUInt32(random.Next(int.MaxValue));
            }

            //when
            serverOutStream.Write(Messages.uintArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfUInts();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUIntArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfUInts();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveULongArray()
        {
            ///given
            ulong[] expected = new ulong[numberOfElements];
            ulong[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = uint.MaxValue + Convert.ToUInt64(random.Next());
            }

            //when
            serverOutStream.Write(Messages.ulongArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfULongs();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveULongArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfULongs();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveByteArray()
        {
            ///given
            byte[] expected = new byte[numberOfElements];
            byte[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToByte(random.Next(byte.MaxValue));
            }

            //when
            serverOutStream.Write(Messages.byteArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfBytes();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveByteArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfBytes();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveSByteArray()
        {
            ///given
            sbyte[] expected = new sbyte[numberOfElements];
            sbyte[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue));
            }

            //when
            serverOutStream.Write(Messages.sbyteArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfSBytes();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveSByteArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfSBytes();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveCharArray()
        {
            ///given
            char[] expected = new char[numberOfElements];
            char[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToChar(random.Next(9));
            }

            //when
            serverOutStream.Write(Messages.charArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfChars();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveCharArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfChars();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveStringArray()
        {
            ///given
            string[] expected = new string[numberOfElements];
            string[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = "napis testowy " + i.ToString();
            }

            //when
            serverOutStream.Write(Messages.stringArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfStrings();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveStringArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfStrings();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDecimalArray()
        {
            ///given
            decimal[] expected = new decimal[numberOfElements];
            decimal[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next());
            }

            //when
            serverOutStream.Write(Messages.decimalArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfDecimals();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDecimalArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfDecimals();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveFloatArray()
        {
            ///given
            float[] expected = new float[numberOfElements];
            float[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = Convert.ToSingle(random.NextDouble());
            }

            //when
            serverOutStream.Write(Messages.floatArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfFloats();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveFloatArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfFloats();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDoubleArray()
        {
            ///given
            double[] expected = new double[numberOfElements];
            double[] result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected[i] = random.NextDouble();
            }

            //when
            serverOutStream.Write(Messages.doubleArrayTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveArrayOfDoubles();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("arrayTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDoubleArrayException()
        {
            //when
            serverOutStream.Write(Messages.intArrayTransfer);

            try
            {
                clientDataTransferConnection.recieveArrayOfDoubles();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }
        #endregion

        #region listTypeRecieve
        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveBoolList()
        {
            //given
            List<bool> expected = new List<bool>();
            List<bool> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToBoolean(i % 2));
            }

            //when
            serverOutStream.Write(Messages.boolListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfBools();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveBoolListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfBools();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveShortList()
        {
            //given
            List<short> expected = new List<short>();
            List<short> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToInt16(random.Next(-32768, 32767)));
            }

            //when
            serverOutStream.Write(Messages.shortListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfShorts();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveShortListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfShorts();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveIntList()
        {
            //given
            List<int> expected = new List<int>();
            List<int> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.Next());
            }

            //when
            serverOutStream.Write(Messages.intListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfInts();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveIntListException()
        {
            //when
            serverOutStream.Write(Messages.boolListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfInts();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveLongList()
        {
            //given
            List<long> expected = new List<long>();
            List<long> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(int.MinValue - random.Next(1, int.MaxValue));
            }

            //when
            serverOutStream.Write(Messages.longListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfLongs();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveLongListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfLongs();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUShortList()
        {
            ///given
            List<ushort> expected = new List<ushort>();
            List<ushort> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt16(random.Next(ushort.MaxValue)));
            }

            //when
            serverOutStream.Write(Messages.ushortListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfUShorts();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUShortListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfUShorts();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUIntList()
        {
            ///given
            List<uint> expected = new List<uint>();
            List<uint> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToUInt32(random.Next(int.MaxValue)));
            }

            //when
            serverOutStream.Write(Messages.uintListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfUInts();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveUIntListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfUInts();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveULongList()
        {
            ///given
            List<ulong> expected = new List<ulong>();
            List<ulong> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(uint.MaxValue + Convert.ToUInt64(random.Next()));
            }

            //when
            serverOutStream.Write(Messages.ulongListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfULongs();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveULongListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfULongs();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveByteList()
        {
            ///given
            List<byte> expected = new List<byte>();
            List<byte> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToByte(random.Next(byte.MaxValue)));
            }

            //when
            serverOutStream.Write(Messages.byteListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfBytes();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveByteListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfBytes();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveSByteList()
        {
            ///given
            List<sbyte> expected = new List<sbyte>();
            List<sbyte> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSByte(random.Next(sbyte.MinValue, sbyte.MaxValue)));
            }

            //when
            serverOutStream.Write(Messages.sbyteListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfSBytes();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveSByteListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfSBytes();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveCharList()
        {
            ///given
            List<char> expected = new List<char>();
            List<char> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToChar(random.Next(9)));
            }

            //when
            serverOutStream.Write(Messages.charListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfChars();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveCharListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfChars();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveStringList()
        {
            ///given
            List<string> expected = new List<string>();
            List<string> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add("napis testowy " + i.ToString());
            }

            //when
            serverOutStream.Write(Messages.stringListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfStrings();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveStringListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfStrings();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDecimalList()
        {
            ///given
            List<decimal> expected = new List<decimal>();
            List<decimal> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToDecimal(long.MaxValue) + Convert.ToDecimal(random.Next()));
            }

            //when
            serverOutStream.Write(Messages.decimalListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfDecimals();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDecimalListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfDecimals();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveFloatList()
        {
            ///given
            List<float> expected = new List<float>();
            List<float> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(Convert.ToSingle(random.NextDouble()));
            }

            //when
            serverOutStream.Write(Messages.floatListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfFloats();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveFloatListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfFloats();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDoubleList()
        {
            ///given
            List<double> expected = new List<double>();
            List<double> result;

            for (int i = 0; i < numberOfElements; i++)
            {
                expected.Add(random.NextDouble());
            }

            //when
            serverOutStream.Write(Messages.doubleListTransfer);
            serverOutStream.Write(numberOfElements);



            for (int i = 0; i < numberOfElements; i++)
            {
                serverOutStream.Write(expected[i]);
            }

            result = clientDataTransferConnection.recieveListOfDoubles();
            //then
            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestCategory("listTypeRecieve")]
        [TestMethod]
        public void clientShouldRecieveDoubleListException()
        {
            //when
            serverOutStream.Write(Messages.intListTransfer);

            try
            {
                clientDataTransferConnection.recieveListOfDoubles();
                //then
                Assert.Fail();
            }
            catch (TypeNotMatchException ex)
            {
            }

        }
        #endregion
    }
}
