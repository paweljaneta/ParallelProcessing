using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using System.IO;
using communicationLibrary;

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


    }
}
