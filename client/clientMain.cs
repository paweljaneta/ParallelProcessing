using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace client
{
    class clientMain
    {
        static void Main(string[] args)
        {
            List<Thread> workingThreads = new List<Thread>();
            Thread cpuLoadThread;
            int numberOfCPUcores = Environment.ProcessorCount;
            double flops;

            while(true) //infinite loop
            {
                //connect to server

                //do tests

                //get dll

                //start threads
                //wait until finished
                while(!threadsFinished(workingThreads))
                {
                    Thread.Sleep(1);
                }

            }

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
