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
            }catch(ArgumentOutOfRangeException e)
            { }

        }

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
        public void ShouldReadBoolNoClientsException()
        {

        }

        [TestMethod]
        public void ShouldReadBoolTypeNotMatchException()
        {

        }

    }
}
