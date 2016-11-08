using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace serwer
{
    class ClientConnectionThread
    {
        Thread thread;
        TcpClient connection;
        BinaryReader inputStream;
        BinaryWriter outputStream;

       public ClientConnectionThread(TcpClient connection)
        {
            try
            {
                this.connection = connection;
                inputStream = new BinaryReader(this.connection.GetStream());
                outputStream = new BinaryWriter(this.connection.GetStream());

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
            outputStream.Write("Hello!");
        }


    }
}
