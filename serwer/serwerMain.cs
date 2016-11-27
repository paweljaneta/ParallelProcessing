using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using communicationLibrary;

namespace serwer
{
    class serwerMain
    {
        class RemoteEndPointNetworkSpeedPair
        {
            public EndPoint endPoint { get; set; }
            public Measurments.NetworkSpeeds netSpeeds { get; set; }
            public double flops { get; set; }

            public RemoteEndPointNetworkSpeedPair(EndPoint endPoint, Measurments.NetworkSpeeds networkSpeeds, double flops)
            {
                this.endPoint = endPoint;
                netSpeeds = networkSpeeds;
                this.flops = flops;
            }


        }

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



        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 1807);
           // TcpListener listener = new TcpListener(IPAddress.Parse("192.168.254.136"), 1807);
            listener.Start();
            TcpClient client;
            BinaryReader inputStream;
            BinaryWriter outputStream;

            Measurments mesurments = new Measurments();

            List<ClientConnectionThread> connectedClientsList = new List<ClientConnectionThread>();
            List<ClientIDNetSpeedFlops> clientIDNetSpeedFlopsList = new List<ClientIDNetSpeedFlops>();

            int clientID = 0;
            int threadID = 0;


            while (true)
            {
                client = listener.AcceptTcpClient();
                inputStream = new BinaryReader(client.GetStream());
                outputStream = new BinaryWriter(client.GetStream());
                string message;

                message = inputStream.ReadString();

                if (message.Equals(Messages.dllRequest))
                {
                    //send dll
                  //  sendDll(outputStream);
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

                    clientID++;

                    client.Close();
                }
                else if (message.Equals(Messages.dataRequest))
                {
                    //add threadID
                    int remoteClientID = inputStream.ReadInt32();

                    ClientConnections.Instance().Add(new ClientConnectionThread(client, remoteClientID, threadID));
               //     connectedClientsList.Add(new ClientConnectionThread(client));

                    threadID++;

                }
                else
                {
                    //error
                }
            }


        }

        public static void sendDll(BinaryWriter writer)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes("dllka.dll");

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
