using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using communicationLibrary;

namespace clientDll
{
    public class clientDllMain
    {
        public void Main(DataTransfer communication)
        {
            while (true)
            {


                //get data
                int dimension = communication.recieveInt();

                if (dimension < 0)
                    break;


                int lineNumber = communication.recieveInt();
                int[] lineA = communication.recieveArrayOfInts();
                int[] lineB = communication.recieveArrayOfInts();

                int[] lineC = new int[dimension];

                //process

                for (int i = 0; i < dimension; i++)
                {
                    lineC[i] = lineA[i] + lineB[i];
                }

                //send results
                communication.send(lineNumber);
                communication.send(lineC);
            }
        }

    }


}
