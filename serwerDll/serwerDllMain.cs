using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using communicationLibrary;
using System.Threading;
using System.IO;

namespace serwerDll
{
    public class serwerDllMain
    {
        public void Main()
        {
            FileStream log = new FileStream("log.txt", FileMode.Create);
            StreamWriter logStream = new StreamWriter(log);
            logStream.AutoFlush = true;
            while (!ClientConnections.startCalculations)
                Thread.Sleep(1);

            int dimension = 10;
            int[,] matrixA = new int[dimension, dimension];
            int[,] matrixB = new int[dimension, dimension];
            int[,] matrixC = new int[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    matrixA[i, j] = i * dimension + j;
                    matrixB[i, j] = i * dimension + j;
                }
            }

            int threadID;
            int[] lineA = new int[dimension];
            int[] lineB = new int[dimension];

            int sentLine = 0;
            int numberOfThreads = ClientConnections.Instance().GetConnectedCliensCount();

            int[] sentToThreads = new int[numberOfThreads];

            for (int i = 0; i < numberOfThreads; i++)
            {
                ClientConnections.Instance().sendInt(dimension, out threadID);
               // logStream.WriteLine("s dimension " + dimension + " thr " + threadID);
               // logStream.Flush();
                ClientConnections.Instance().sendIntByID(i, threadID); //line number
              //  logStream.WriteLine("s lineNumber " + i + " thr " + threadID);
              //  logStream.Flush();

                for (int j = 0; j < dimension; j++)
                {
                    lineA[j] = matrixA[i, j];
                    lineB[j] = matrixB[i, j];
                }

                ClientConnections.Instance().sendIntArrayByID(lineA, threadID);       
              //  logStream.WriteLine("s arrayA " + lineA + " thr " + threadID);
              //  logStream.Flush();
                ClientConnections.Instance().sendIntArrayByID(lineB, threadID);
              //  logStream.WriteLine("s arrayB " + lineA + " thr " + threadID);
              //  logStream.Flush();
                sentToThreads[threadID]++;
                sentLine = i;
            }

            sentLine++;

            int lineNumber;
            int[] line;

            while (sentLine < dimension)
            {
                
                lineNumber = ClientConnections.Instance().readInt(out threadID);
              //  logStream.WriteLine("r lineNumber " + lineNumber + " thr " + threadID);
              //  logStream.Flush();
                line = ClientConnections.Instance().readIntArrayByID(threadID);
              //  logStream.WriteLine("r line " + line + " thr " + threadID);
              //  logStream.Flush();

                for (int i = 0; i < dimension; i++)
                {
                    matrixC[lineNumber, i] = line[i];
                }

                ClientConnections.Instance().sendInt(dimension, out threadID);
               // logStream.WriteLine("s dimension " + dimension + " thr " + threadID);
             //   logStream.Flush();
                ClientConnections.Instance().sendIntByID(sentLine, threadID); //line number
               // logStream.WriteLine("s lineNumber " + sentLine + " thr " + threadID);
               // logStream.Flush();

                for (int j = 0; j < dimension; j++)
                {
                    lineA[j] = matrixA[sentLine, j];
                    lineB[j] = matrixB[sentLine, j];
                }

                ClientConnections.Instance().sendIntArrayByID(lineA, threadID);
               // logStream.WriteLine("s arrayA " + lineA + " thr " + threadID);
               // logStream.Flush();
                ClientConnections.Instance().sendIntArrayByID(lineB, threadID);
               // logStream.WriteLine("s arrayB " + lineA + " thr " + threadID);
                //logStream.Flush();
                sentToThreads[threadID]++;

                sentLine++;
            }

           

            for (int i = 0; i < numberOfThreads; i++)
            {
                lineNumber = ClientConnections.Instance().readInt(out threadID);
               // logStream.WriteLine("r lineNumber " + lineNumber + " thr " + threadID);
                //logStream.Flush();
                line = ClientConnections.Instance().readIntArrayByID(threadID);
                //logStream.WriteLine("r line " + line + " thr " + threadID);
                //logStream.Flush();
                ClientConnections.Instance().sendIntByID(-1, threadID); //deadly pill
               // logStream.WriteLine("s pill " + -1 + " thr " + threadID);
               // logStream.Flush();

                for (int j = 0; j < dimension; j++)
                {
                    matrixC[lineNumber, j] = line[j];
                }
            }

        }
    }
}
