using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net.Sockets;
using System.Net;
using communicationLibrary;

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

        [TestInitialize]
        private void TestInitialize()
        {
            server = new TcpListener(IPAddress.Parse(serverIP), 1807);
            server.Start();
            clientConnection = new TcpClient(clientIP, 1807);
            serverConnection = server.AcceptTcpClient();
            server.Stop(); //?
            serverInStream = new BinaryReader(serverConnection.GetStream());
            serverOutStream = new BinaryWriter(serverConnection.GetStream());
            clientInStream = new BinaryReader(clientConnection.GetStream());
            clientOutStream = new BinaryWriter(clientConnection.GetStream());

            clientDataTransferConnection = new DataTransfer(clientInStream, clientOutStream);
            serverDataTransferConnection = new DataTransfer(serverInStream, serverOutStream);
        }

        [TestCleanup]
        private void TestCleanup()
        {
            serverInStream.Close();
            serverOutStream.Close();
            clientInStream.Close();
            clientOutStream.Close();

            clientConnection.Close();
            serverConnection.Close();

        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
