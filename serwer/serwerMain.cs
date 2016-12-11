using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using communicationLibrary;
using System.Threading;
using serwerDll;

namespace serwer
{
    class ClientIDNetSpeedFlops
    {
        public int clientID { get; set; }
        public Measurments.NetworkSpeeds netSpeeds { get; set; }
        public double flops { get; set; }

        public ClientIDNetSpeedFlops(int clientID, Measurments.NetworkSpeeds networkSpeeds, double flops)
        {
            this.clientID = clientID;
            netSpeeds = networkSpeeds;
            this.flops = flops;
        }
    }

    class serwerMain
    {
        static void Main(string[] args)
        {
            //Parse("157.158.170.90")
            TcpListener listener = new TcpListener(IPAddress.Any, 1807);
            listener.Start();
            SerwerListener serwerListener = new SerwerListener(listener);
            TcpClient client;
            BinaryReader inputStream = null;
            BinaryWriter outputStream = null;

            Measurments mesurments = new Measurments();

            List<ClientConnectionThread> connectedClientsList = new List<ClientConnectionThread>();
            List<ClientIDNetSpeedFlops> clientIDNetSpeedFlopsList = new List<ClientIDNetSpeedFlops>();

            View view = new View(clientIDNetSpeedFlopsList);

            //serwerDllMain serverDllMain = new serwerDllMain();
            Thread serverDllThread = new Thread(SerwerDllCaller.run);
            serverDllThread.Name = "ServerDllThread";

            int clientID = 0;
            int threadID = 0;

            bool serverDllThreadStarted = false;


            while (SerwerListener.isListening)
            {
                //client = listener.AcceptTcpClient();
                if (serwerListener.isPendingConnection())
                {
                    client = serwerListener.acceptTcpClient();
                    if (client != null)
                    {
                        inputStream = new BinaryReader(client.GetStream());
                        outputStream = new BinaryWriter(client.GetStream());
                    }
                    string message;

                    if (SerwerListener.isListening)
                    {
                        message = inputStream.ReadString();

                        if (message.Equals(Messages.dllRequest))
                        {
                            //send dll
                            sendDll(outputStream);
                            double flops = 0.0;
                            Measurments.NetworkSpeeds netSpeed;

                            message = inputStream.ReadString();

                            if (message.Equals(Messages.flops))
                            {
                                flops = inputStream.ReadDouble();
                            }
                            netSpeed = mesurments.networkSpeed(inputStream, outputStream);

                            outputStream.Write(clientID);

                            clientIDNetSpeedFlopsList.Add(new ClientIDNetSpeedFlops(clientID, netSpeed, flops));

                            view.updateList(clientIDNetSpeedFlopsList);

                            TelemetryConnections.Add(new TelemetryConnection(client, clientID));
                            //client.Close();
                            if (!serverDllThreadStarted)
                            {
                                serverDllThread.Start();
                                serverDllThreadStarted = true;
                            }


                            clientID++;

                        }
                        else if (message.Equals(Messages.dataRequest))
                        {
                            //add threadID
                            int remoteClientID = inputStream.ReadInt32();

                            ClientConnections.Instance().Add(new ClientConnectionThread(client, remoteClientID, threadID));

                            threadID++;

                        }
                        else
                        {
                            //error
                        }
                        Thread.Sleep(1);
                    }
                    else
                    {
                        try
                        {
                            outputStream.Write(0); //send dllsize 0 bytes
                        }
                        catch (Exception e)
                        { }
                    }
                }
                Thread.Sleep(1);
            }
            view.closeViewThread();
            TelemetryConnections.stopTelemetryThreads();
            ClientConnections.Instance().terminateReadThreads();
        }

        public static void sendDll(BinaryWriter writer)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes("clientDll.dll");

                int size = fileBytes.Count();

                writer.Write(size);
                writer.Write(fileBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
