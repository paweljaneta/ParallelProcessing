using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using communicationLibrary;

namespace serwer
{
    class TelemetryConnection
    {
        TcpClient connection;
        BinaryReader inputStream;
        BinaryWriter outputStream;

        int streamTimeout = 100000;

        int clientID;

        List<string> exceptions = new List<string>();
        float cpuUsage;
        float ramAvaliable;

        Thread readThread;
        bool stopThread = false;

        public TelemetryConnection(TcpClient connection,int clientID)
        {
            this.connection = connection;
            inputStream = new BinaryReader(connection.GetStream());

            inputStream.BaseStream.ReadTimeout = streamTimeout;

            outputStream = new BinaryWriter(connection.GetStream());
            this.clientID = clientID;
            readThread = new Thread(inThread);
         //   readThread.Start();
        }

        private void inThread()
        {
            while (!stopThread)
            {
                string message;
                try
                {
                    message = inputStream.ReadString();

                    if (message != null)
                    {
                        if (message.Equals(Messages.exception))
                        {
                            int count;
                            count = inputStream.ReadInt32();

                            for (int i = 0; i < count; i++)
                            {
                                exceptions.Add(inputStream.ReadString());
                            }

                        }
                        else if (message.Equals(Messages.CPULoad))
                        {
                            cpuUsage = inputStream.ReadSingle();

                        }
                        else if (message.Equals(Messages.memoryAvaliable))
                        {
                            ramAvaliable = inputStream.ReadSingle();
                        }
                    }

                }
                catch (EndOfStreamException e)
                {
                    ClientConnections.Instance().RemoveByClientID(clientID);
                    abortThread();
                    TelemetryConnections.RemoveByClientID(clientID);
                }
                catch (IOException e)
                {
                    if(e.InnerException is SocketException)
                    {
                       // ClientConnections.Instance().RemoveByClientID(clientID);
                       // abortThread();
                       // TelemetryConnections.RemoveByClientID(clientID);
                    }
                    //exception from timeout
                }
                catch(SocketException e)
                {
                    ClientConnections.Instance().RemoveByClientID(clientID);
                    abortThread();
                    TelemetryConnections.RemoveByClientID(clientID);
                }
            }
        }

        public void abortThread()
        {
            stopThread = true;
        }

        public int getClientID()
        {
            return clientID;
        }

        public float getCpuUsage()
        {
            return cpuUsage;
        }

        public float getRamAvaliable()
        {
            return ramAvaliable;
        }

        public List<string> getExceptions()
        {
            return exceptions;
        }

    }
}
