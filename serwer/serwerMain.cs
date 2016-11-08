using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using communicationLibrary;

namespace serwer
{
    class serwerMain
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 1807);
            listener.Start();
            TcpClient client;
            BinaryReader inputStream;

            List<ClientConnectionThread> connectedClientsList = new List<ClientConnectionThread>();

            while (true)
            {
                client = listener.AcceptTcpClient();
                inputStream = new BinaryReader(client.GetStream());
                string message;

                message = inputStream.ReadString();

                if(message.Equals(Messages.dllRequest))
                {
                    //send dll
                }else if(message.Equals(Messages.dataRequest))
                {
                    connectedClientsList.Add(new ClientConnectionThread(client));
                }else
                {
                    //error
                }

                
            }

        }
    }
}
