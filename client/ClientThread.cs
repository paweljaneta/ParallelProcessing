using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace client
{
    class ClientThread
    {
        int id;
        BinaryReader inputStream;
        BinaryWriter outputStream;

        TcpClient connection;

        Thread thread;

        ClientThread(string adress, int port)
        {
            try
            {
                connection = new TcpClient(adress, port);

                inputStream = new BinaryReader(connection.GetStream());
                outputStream = new BinaryWriter(connection.GetStream());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void run()
        {
            //load dll
            //execute
        }

        public bool isThreadAlive()
        {
            return thread.IsAlive;
        }

    }
}
