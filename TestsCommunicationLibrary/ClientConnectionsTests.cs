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
        private BinaryReader serverInStream, clientInStream;
        private BinaryWriter serverOutStream, clientOutStream;

        private string serverIP = "127.0.0.1", clientIP = "127.0.0.1";
        private int port = 1807;

        private DataTransfer clientDataTransferConnection, serverDataTransferConnection;

        private int numberOfArrayListElements = 5;

        private int numberOfClients = 1;


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

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
