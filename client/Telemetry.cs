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

        int telemetryDelayMs = 5000;
        int readTimeout = 3600*1000;

        bool stopThreads = false;
        bool stopCalc = false;

        static List<Exception> exceptions = new List<Exception>();
        static object exceptionsLock = new object();

        PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes");

        public Telemetry(TcpClient connection)
        {
            this.connection = connection;
            inStream = new BinaryReader(connection.GetStream());
            inStream.BaseStream.ReadTimeout = readTimeout;
            outStream = new BinaryWriter(connection.GetStream());
            inputThread = new Thread(inThread);
            outputThread = new Thread(outThread);
            inputThread.Start();
            outputThread.Start();
        }

        public Telemetry(TcpClient connection, int TelemetryDelayMs)
        {
            this.connection = connection;
            inStream = new BinaryReader(connection.GetStream());
            inStream.BaseStream.ReadTimeout = readTimeout;
            outStream = new BinaryWriter(connection.GetStream());
            telemetryDelayMs = TelemetryDelayMs;
            inputThread = new Thread(inThread);
            outputThread = new Thread(outThread);
            inputThread.Start();
            outputThread.Start();
        }

        private void inThread()
        {
            string message;
            while (!stopThreads)
            {
                try
                {
                    message = inStream.ReadString();

                    if (message != null)
                    {
                        switch (message)
                        {
                            case Messages.nop:
                                break;

                            case Messages.stopCalculations:
                                stopCalculations();
                                break;
                        }
                    }

                }
                catch (EndOfStreamException e)
                {
                    abortThreads();
                }
                catch (IOException e)
                {
                    //exception from timeout
                }
                catch (SocketException e)
                {
                    abortThreads();
                }
            }
        }

        private void stopCalculations()
        {
            stopCalc = true;
        }

        public bool getStopCalculations()
        {
            return stopCalc;
        }

        private void outThread()
        {
            while (!stopThreads)
            {
                //send exceptions
                if (exceptions.Count > 0)
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

        public static void addExceptionToList(Exception e)
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
