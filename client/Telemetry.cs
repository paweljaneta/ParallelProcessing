using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using communicationLibrary;
using System.Diagnostics;

namespace client
{
    class Telemetry
    {
        TcpClient connection;
        BinaryReader inStream;
        BinaryWriter outStream;

        Thread inputThread;
        Thread outputThread;

        int telemetryDelayMs = 1000;
        int readTimeout = 100;

        bool stopThreads = false;

        List<Exception> exceptions = new List<Exception>();
        object exceptionsLock = new object();

        PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes");

        public Telemetry(TcpClient connection)
        {
            this.connection = connection;
            inStream = new BinaryReader(connection.GetStream());
            inStream.BaseStream.ReadTimeout = readTimeout;
            outStream = new BinaryWriter(connection.GetStream());
        }

        public Telemetry(TcpClient connection, int TelemetryDelayMs)
        {
            this.connection = connection;
            inStream = new BinaryReader(connection.GetStream());
            inStream.BaseStream.ReadTimeout = readTimeout;
            outStream = new BinaryWriter(connection.GetStream());
            telemetryDelayMs = TelemetryDelayMs;
        }

        private void inThread()
        {
            string message;
            while (!stopThreads)
            {
                message = inStream.ReadString();

                if(message!=null)
                {
                    switch (message)
                    {
                        case Messages.stopCalculations:
                            stopCalculations();
                            break;
                    }
                }  
            }
        }

        private void stopCalculations()
        {

        }

        private void outThread()
        {
            while (!stopThreads)
            {
                //send exceptions
                if(exceptions.Count>0)
                {
                    outStream.Write(Messages.exception);
                    outStream.Write(exceptions.Count);
                    
                    while (exceptions.Count > 0)
                    {
                        lock (exceptionsLock)
                        {
                            outStream.Write(exceptions[0].ToString());
                            exceptions.RemoveAt(0);
                        }
                    }
                }

                float cpuUsage, ramAvaliable;

                //send CPU load
                outStream.Write(Messages.CPULoad);

                cpuUsage = cpu.NextValue();

                outStream.Write(cpuUsage);

                //send memory usage

                outStream.Write(Messages.memoryAvaliable);

                ramAvaliable = ram.NextValue();

                outStream.Write(ramAvaliable);


                Thread.Sleep(telemetryDelayMs);
            }
        }

        public void addExceptionToList(Exception e)
        {
            lock (exceptionsLock)
            {
                exceptions.Add(e);
            }
        }

        public void abortThreads()
        {
            stopThreads = true;
        }

    }
}
