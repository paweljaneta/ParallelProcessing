using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

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
            TcpClient result = null;
            try {
                if (isListening)
                    result = listener.AcceptTcpClient();
            }catch(Exception e)
            {
                result = null;
            }
            return result;
        }

        public bool isPendingConnection()
        {
            bool result=false;
            try
            {
                if (isListening)
                    result = listener.Pending();
            }catch(Exception e)
            {
                result = false;
            }
            
            return result;
        }
    }
}
