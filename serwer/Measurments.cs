using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace serwer
{
    class Measurments
    {
        public class NetworkSpeeds
        {
            public double download { set; get; }
            public double upload { set; get; }

            public NetworkSpeeds(double download, double upload)
            {
                this.download = download;
                this.upload = upload;
            }
        }


        public NetworkSpeeds networkSpeed(BinaryReader reader, BinaryWriter writer)
        {
            double uploadFromSrv = 0, downloadToSrv = 0;

            int bufferSize = 100 * 1024;
            byte[] buffer = new byte[bufferSize]; //100kB

            byte returnByte;

            Random randomizer = new Random();

            Stopwatch stopwatch = new Stopwatch();

            randomizer.NextBytes(buffer);

            stopwatch.Start();
            writer.Write(buffer);

            returnByte = reader.ReadByte();
            stopwatch.Stop();

           // Console.WriteLine("StopW: " + stopwatch.ElapsedMilliseconds);

            if(stopwatch.ElapsedMilliseconds>0)
            {
                uploadFromSrv = (Convert.ToDouble(bufferSize) * 1000.0) / (stopwatch.ElapsedMilliseconds); // bytes per second
            }
            else
            {
                uploadFromSrv = 1024.0 * 1024.0 * 100; //100MB
            }
            

            int bytesToSecondTransfer = Convert.ToInt32(uploadFromSrv);

            buffer = new byte[bytesToSecondTransfer];

            randomizer.NextBytes(buffer);

            writer.Write(bytesToSecondTransfer);
            stopwatch.Reset();

            stopwatch.Start();
            writer.Write(buffer);
            returnByte = reader.ReadByte();
            stopwatch.Stop();

         //   Console.WriteLine("StopW: " + stopwatch.ElapsedMilliseconds);

            uploadFromSrv = ((Convert.ToDouble(bytesToSecondTransfer) * 1000.0 / (1024.0 * 1024.0))) / (stopwatch.ElapsedMilliseconds); // Mega bytes per second

            buffer = new byte[bufferSize];

            buffer = reader.ReadBytes(bufferSize);
            byte response = Convert.ToByte(0xaa);
            writer.Write(response);

            bytesToSecondTransfer = reader.ReadInt32();

            buffer = new byte[bytesToSecondTransfer];

            buffer = reader.ReadBytes(bytesToSecondTransfer);
            writer.Write(response);

            downloadToSrv = reader.ReadDouble();


            return new NetworkSpeeds(downloadToSrv, uploadFromSrv);
        }
    }
}
