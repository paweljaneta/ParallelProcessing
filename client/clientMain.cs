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

            List<Thread> workingThreads = new List<Thread>();
            Thread cpuLoadThread;
            int numberOfCPUcores = Environment.ProcessorCount;
            double flops;

            ClientThread connectionThread = new ClientThread(ipAdress, port);
           // ClientThread connectionThread2 = new ClientThread("127.0.0.1", 1807);

            while (true) //infinite loop
            {
                //connect to server
                TcpClient connection = new TcpClient(ipAdress, port);

                BinaryWriter outStream = new BinaryWriter(connection.GetStream());
                BinaryReader inStream = new BinaryReader(connection.GetStream());

                //do tests

                //get dll
                outStream.Write(Messages.dllRequest);
                getDll(inStream);

                //start threads
                //wait until finished



                while(!threadsFinished(workingThreads))
                {
                    Thread.Sleep(1);
                }

            }

        }

        public static void getDll(BinaryReader reader)
        {
            int dllSize = reader.ReadInt32();

            byte[] file;

            file = reader.ReadBytes(dllSize);
            File.WriteAllBytes("dllka.dll", file);
        }



        public static bool threadsFinished(List<Thread> threads)
        {
            bool result = true;

            foreach(Thread thread in threads)
            {
                if (thread.IsAlive)
                    result = false;
            }

            return result;
        }

    }
}
