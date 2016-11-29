using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using communicationLibrary;

namespace serwer
{
    class TelemetryConnections
    {
        private static List<TelemetryConnection> telemetryConnections = new List<TelemetryConnection>();
        private static object telemetryConnectionsLock = new object();

        public static void Add(TelemetryConnection telemetryConnection)
        {
            lock (telemetryConnectionsLock)
            {
                telemetryConnections.Add(telemetryConnection);
            }
        }

        public static List<TelemetryConnection> getTelemetryConnections()
        {
            return telemetryConnections;
        }

        public static void RemoveByClientID(int clientID)
        {
            for (int i = 0; i < telemetryConnections.Count; i++)
            {
                if (telemetryConnections[i].getClientID() == clientID)
                {
                    telemetryConnections[i].abortThread();

                    lock (telemetryConnectionsLock)
                    {
                        telemetryConnections.RemoveAt(i);
                    }
                }
            }
        }

        public static float getCpuUsageByClientID(int clientID)
        {
            float result = -1;
            for (int i = 0; i < telemetryConnections.Count; i++)
            {
                if (telemetryConnections[i].getClientID() == clientID)
                {
                    result = telemetryConnections[i].getCpuUsage();
                }
            }
            return result;
        }

        public static float getRamAvaliableByClientID(int clientID)
        {
            float result = -1;
            for (int i = 0; i < telemetryConnections.Count; i++)
            {
                if (telemetryConnections[i].getClientID() == clientID)
                {
                    result = telemetryConnections[i].getRamAvaliable();
                }
            }
            return result;
        }

        public static List<string> getExceptionsByClientID(int clientID)
        {
            List<string> result = null;
            for (int i = 0; i < telemetryConnections.Count; i++)
            {
                if (telemetryConnections[i].getClientID() == clientID)
                {
                    result = telemetryConnections[i].getExceptions();
                }
            }
            return result;
        }

    }
}
