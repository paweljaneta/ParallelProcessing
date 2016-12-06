using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using communicationLibrary;
using System.Net.Sockets;
using System.IO;
using communicationLibrary;

namespace client
{
    class clientMain
    {
        static void Main(string[] args)
        {
            string ipAdress = "127.0.0.1";
            int port = 1807;
            int clientID;


            List<ClientThread> workingThreads = new List<ClientThread>();
            Telemetry telemetry;
            int numberOfCPUcores = Environment.ProcessorCount;
            double flops;

            Measurments mesurments = new Measurments();


            // ClientThread connectionThread = new ClientThread(ipAdress, port);
            // ClientThread connectionThread2 = new ClientThread("127.0.0.1", 1807);

            while (true) //infinite loop
            {
                try
                {
                    //connect to server
                    TcpClient connection = new TcpClient(ipAdress, port);

                    BinaryWriter outStream = new BinaryWriter(connection.GetStream());
                    BinaryReader inStream = new BinaryReader(connection.GetStream());

                    //get dll
                    outStream.Write(Messages.dllRequest);
                    getDll(inStream);

                    //do tests
                    flops = mesurments.CPUPerformanceFLOPS();
                    outStream.Write(Messages.flops);
                    outStream.Write(flops);
                    mesurments.networkSpeed(inStream, outStream);


                    clientID = inStream.ReadInt32();

                    //telemetry = new Telemetry(connection);
                    connection.Close();

                    //start threads

                    // for (int i = 0; i < numberOfCPUcores; i++)
                    for (int i = 0; i < 4; i++)
                    {
                        workingThreads.Add(new ClientThread(ipAdress, port, clientID));
                    }

                    //wait until finished



                    while (true)
                    {
                        Thread.Sleep(1);
                    }

                }
                catch (SocketException SockEx)
                {

                }
            }
        }

        public static void getDll(BinaryReader reader)
        {
            int dllSize = reader.ReadInt32();

            byte[] file;

            file = reader.ReadBytes(dllSize);
            File.WriteAllBytes("clientDll.dll", file);
        }



        public static bool threadsFinished(List<ClientThread> threads)
        {
            bool result = true;

            foreach (ClientThread thread in threads)
            {
                if (thread.isThreadAlive())
                    result = false;
            }

            return result;
        }

    }
}
