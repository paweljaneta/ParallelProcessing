using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace client
{
    class Measurments
    {
        //1M additions and multiplications
        public double CPUPerformanceFLOPS()
        {
            Stopwatch timer = new Stopwatch();
            double a, b;//, c, d, e, f, g, h;

            a = 2.7;
            b = 0.7;

            //c = 3.3;
            //d = 0.6;

            //e = 1.5;
            //f = 0.5;

            //g = 2.2;
            //h = 0.4;

            timer.Start();

            for (int i = 0; i < 1000000; i++)
            {
                a = a + b;
                b = b * a;

                //c = c + d;
                //d = d * c;

                //e = e + f;
                //f = f * e;

                //g = g + h;
                //h = h * g;
            }

            timer.Stop();

            return 1000000.0 / ((double)timer.ElapsedMilliseconds / 1000.0);

        }

        //iteration number additions and multiplications
        public double CPUPerformanceFLOPS(uint iterations)
        {
            Stopwatch timer = new Stopwatch();
            double a, b;

            a = 2.7;
            b = 0.7;

            timer.Start();

            for (int i = 0; i < iterations; i++)
            {
                a = a + b;
                b = b * a;
            }

            timer.Stop();

            return iterations / (timer.ElapsedMilliseconds / 1000);

        }

        public void networkSpeed(BinaryReader reader, BinaryWriter writer)
        {
            double uploadToSrv = 0, downloadFromSrv = 0;

            int bufferSize = 100 * 1024;
            byte[] buffer = new byte[bufferSize]; //100kB

            byte returnByte;

            Random randomizer = new Random();

            Stopwatch stopwatch = new Stopwatch();

            //download

            buffer = new byte[bufferSize];
            int bytesToSecondTransfer = Convert.ToInt32(uploadToSrv);

            buffer = reader.ReadBytes(bufferSize);
            byte response = Convert.ToByte(0xaa);
            writer.Write(response);

            bytesToSecondTransfer = reader.ReadInt32();

            buffer = new byte[bytesToSecondTransfer];

            buffer = reader.ReadBytes(bytesToSecondTransfer);
            writer.Write(response);

            //upload

            buffer = new byte[bufferSize];

            randomizer.NextBytes(buffer);

            stopwatch.Start();
            writer.Write(buffer);

            returnByte = reader.ReadByte();
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds != 0)
            {
                uploadToSrv = Convert.ToDouble(bufferSize) / (stopwatch.ElapsedMilliseconds * 1000); // bytes per second
            }
            else
            {
                uploadToSrv = 1024.0 * 1024.0 * 100; //100MB
            }

            bytesToSecondTransfer = Convert.ToInt32(uploadToSrv);

            buffer = new byte[bytesToSecondTransfer];

            randomizer.NextBytes(buffer);

            writer.Write(bytesToSecondTransfer);
            stopwatch.Reset();

            stopwatch.Start();
            writer.Write(buffer);
            returnByte = reader.ReadByte();
            stopwatch.Stop();

            uploadToSrv = Convert.ToDouble(bytesToSecondTransfer / (1024 * 1024)) / (stopwatch.ElapsedMilliseconds * 1000); // Mega bytes per second

            writer.Write(uploadToSrv);
        }
    }
}
