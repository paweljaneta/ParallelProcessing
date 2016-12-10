using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace serwer
{
    class SerwerListener
    {
        static TcpListener listener;
        public static bool isListening = true;

        public SerwerListener(TcpListener tcpListener)
        {
            listener = tcpListener;
        }

        public static void stopListener()
        {
            listener.Stop();
            isListening = false;
        }

        public TcpClient acceptTcpClient()
        {
            return listener.AcceptTcpClient();
        }

        public bool isPendingConnection()
        {
            return listener.Pending();
        }
    }
}
