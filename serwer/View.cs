using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using communicationLibrary;

namespace serwer
{
    class View
    {
        Thread displayThread;
        List<ClientIDNetSpeedFlops> clientIDNetSpeedFlopsList;
        object listLock = new object();

        bool finishThread = false;

        bool calculationsStarted = false;

        int refreshDelayMs = 1000;

        public View(List<ClientIDNetSpeedFlops> ClientIDNetSpeedFlopsList)
        {
            clientIDNetSpeedFlopsList = ClientIDNetSpeedFlopsList;
            displayThread = new Thread(printClients);
            displayThread.Start();
        }

        public View(List<ClientIDNetSpeedFlops> ClientIDNetSpeedFlopsList, int refreshDelayMS)
        {
            clientIDNetSpeedFlopsList = ClientIDNetSpeedFlopsList;
            refreshDelayMs = refreshDelayMS;
            displayThread = new Thread(printClients);
            displayThread.Start();
        }

        private void printClients()
        {
            while (!finishThread)
            {
                Console.Clear();
                int connectedThreads = ClientConnections.Instance().GetConnectedCliensCount();

                if(calculationsStarted)
                {
                    Console.WriteLine("To stop calculations press 's'");
                }
                else
                {
                    Console.WriteLine("To start calculations press 's'");
                }
                Console.WriteLine();
                Console.WriteLine("Connected threads: " + connectedThreads);

                //check for changes in connected clients
                lock (listLock)
                {
                    foreach (ClientIDNetSpeedFlops client in clientIDNetSpeedFlopsList)
                    {
                    //    checkIfInConnectedClientsElseDelete(client.clientID);
                    }
                }
                

                //print exceptions
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                List<TelemetryConnection> telemertyConnections = TelemetryConnections.getTelemetryConnections();
                foreach (TelemetryConnection telemetry in telemertyConnections)
                {
                    List<string> exceptions = telemetry.getExceptions();
                    if(exceptions.Count>0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("CLIENT ID:   " + telemetry.getClientID());
                        foreach(string exception in exceptions)
                        {
                            Console.WriteLine(exception);
                        }
                    }
                }
                Console.ResetColor();

                lock (listLock)
                {
                    foreach (ClientIDNetSpeedFlops client in clientIDNetSpeedFlopsList)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("ID:          " + client.clientID);
                        Console.WriteLine("MFLOPS:      " + (client.flops / 1000000).ToString("g4"));
                        Console.WriteLine("DOWNLOAD:    " + client.netSpeeds.download.ToString("g4") + " MB/s    " + (client.netSpeeds.download * 8).ToString("g4") + " Mb/s");
                        Console.WriteLine("UPLOAD:      " + client.netSpeeds.upload.ToString("g4") + " MB/s    " + (client.netSpeeds.upload * 8).ToString("g4") + " Mb/s");
                        Console.WriteLine("CPU LOAD:    " + TelemetryConnections.getCpuUsageByClientID(client.clientID).ToString("g4") + " %");
                        Console.WriteLine("MEMORY AVAL: " + TelemetryConnections.getRamAvaliableByClientID(client.clientID) + " MB");
                    }
                }

                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey().KeyChar == 's')
                    {
                        if (calculationsStarted)
                        {
                            stopCalculations();
                        }
                        else
                        {
                            startCalculations();
                        }
                    }
                }

                Thread.Sleep(refreshDelayMs);
            }
        }

        private void checkIfInConnectedClientsElseDelete(int clientID)
        {
            if(!ClientConnections.Instance().isClientIDInList(clientID))
            {
                for(int i=0;i<clientIDNetSpeedFlopsList.Count;i++)
                {
                    if (clientIDNetSpeedFlopsList[i].clientID == clientID)
                    {
                        lock(listLock)
                        {
                            clientIDNetSpeedFlopsList.RemoveAt(i);
                        }
                    }
                }
            }
        }

        public void closeViewThread()
        {
            finishThread = true;
        }

        public void updateList(List<ClientIDNetSpeedFlops> ClientIDNetSpeedFlopsList)
        {
            lock (listLock)
            {
                clientIDNetSpeedFlopsList = ClientIDNetSpeedFlopsList;
            }
        }

        public void startCalculations()
        {
            calculationsStarted = true;
            ClientConnections.startCalculations = true;

        }

        public void stopCalculations()
        {
            calculationsStarted = false;

        }

    }
}
