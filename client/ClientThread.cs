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

namespace client
{
    class ClientThread
    {
        int clientId;
        int threadId;

        BinaryReader inputStream;
        BinaryWriter outputStream;

        TcpClient connection;

        Thread thread;

        public ClientThread(string adress, int port, int clientId)
        {
            this.clientId = clientId;

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
            //load dll
            //execute

            Console.WriteLine(inputStream.ReadString());
        }

        public bool isThreadAlive()
        {
            return thread.IsAlive;
        }

    }
}
