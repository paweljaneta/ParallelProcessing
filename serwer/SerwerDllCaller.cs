using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using serwerDll;
using communicationLibrary;

namespace serwer
{
    class SerwerDllCaller
    {
        static serwerDllMain dll = new serwerDllMain();

        public static void run()
        {
            while(ClientConnections.startCalculations==false)
            {
                Thread.Sleep(1);
            }

            dll.Main();
            SerwerListener.stopListener();
        }
    }
}
