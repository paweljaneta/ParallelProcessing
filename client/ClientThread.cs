using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using communicationLibrary;
using System.Reflection;

namespace client
{
    class ClientThread
    {
        int clientId;
        int threadId;

        BinaryReader inputStream;
        BinaryWriter outputStream;

        TcpClient connection;

        Telemetry telemetry;

        Thread thread;
        Thread calculationsStopObserverThread;

        public ClientThread(string adress, int port, int clientId,Telemetry telemetry)
        {
            this.clientId = clientId;
            this.telemetry = telemetry;

            try
            {
                connection = new TcpClient(adress, port);

                inputStream = new BinaryReader(connection.GetStream());
                outputStream = new BinaryWriter(connection.GetStream());

                outputStream.Write(Messages.dataRequest);

                outputStream.Write(clientId);
                threadId = inputStream.ReadInt32();

                thread = new Thread(run);
                thread.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public ClientThread(string adress, int port, int clientId)
        {
            this.clientId = clientId;
           // this.telemetry = telemetry;

            try
            {
                connection = new TcpClient(adress, port);

                inputStream = new BinaryReader(connection.GetStream());
                outputStream = new BinaryWriter(connection.GetStream());

                outputStream.Write(Messages.dataRequest);

                outputStream.Write(clientId);
                threadId = inputStream.ReadInt32();

                thread = new Thread(run);
                thread.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void run()
        {
           // Telemetry.addExceptionToList(new ArgumentException("test exceptiona"));
            //string message = inputStream.ReadString();

          //  if(message.Equals(Messages.startCalculations))
           // {
                try
                {
                    //load dll
                    string path = Directory.GetCurrentDirectory() + "\\clientDll.dll";

                    Assembly assembly = Assembly.LoadFile(path);
                    Type[] type = assembly.GetTypes();

                    //execute
                    foreach (Type t in type)
                    {
                        var obj = Activator.CreateInstance(t);
                        object[] arg = new object[] { new DataTransfer(connection) };
                        t.GetMethod("Main").Invoke(obj, arg);
                    }
                    
                }
                catch (Exception e)
                {
                    Telemetry.addExceptionToList(e);
                }
           // }
        }

        private void calculationsStopObserver()
        {
            while(true)
            {
                if(!telemetry.getStopCalculations())
                {
                    abortThread();
                }
                Thread.Sleep(1);
            }
        }

        public void abortThread()
        {
            thread.Abort();
            calculationsStopObserverThread.Abort();
        }

        public bool isThreadAlive()
        {
            return thread.IsAlive;
        }

    }
}
