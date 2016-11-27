using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communicationLibrary
{
    public class Messages
    {
        public const string dllRequest = "dllReq";
        public const string dataRequest = "dataReq";
        public const string measurmentsRequest = "measReq";
        public const string deadlyPill = "deadlyPill";
        public const string startCalculations = "beginCalc";
        public const string stopCalculations = "stopCalc";
        public const string executionTime = "execTime";
        public const string connectionSpeedMeasurment = "conSpeedMeas";
        public const string flops = "FLOPS";
        public const string exception = "exception";
        public const string CPULoad = "CPULoad";
        public const string memoryAvaliable = "memoryAvaliable";

        #region basicTypes
        public const string byteTransfer = "byteTransfer";
        public const string sbyteTransfer = "sbyteTransfer";
        public const string shortTransfer = "shortTransfer";
        public const string ushortTransfer = "ushortTransfer";
        public const string intTransfer = "intTransfer";
        public const string uintTransfer = "uintTransfer";
        public const string longTransfer = "longTransfer";
        public const string ulongTransfer = "ulongTransfer";
        public const string floatTransfer = "floatTransfer";
        public const string doubleTransfer = "doubleTransfer";
        public const string decimalTransfer = "decimalTransfer";
        public const string charTransfer = "charTransfer";
        public const string stringTransfer = "stringTransfer";
        public const string boolTransfer = "boolTransfer";
        public const string objectTransfer = "objectTransfer";
        #endregion

        #region arrayTypes
        public const string byteArrayTransfer = "byteArrayTransfer";
        public const string sbyteArrayTransfer = "sbyteArrayTransfer";
        public const string shortArrayTransfer = "shortArrayTransfer";
        public const string ushortArrayTransfer = "ushortArrayTransfer";
        public const string intArrayTransfer = "intArrayTransfer";
        public const string uintArrayTransfer = "uintArrayTransfer";
        public const string longArrayTransfer = "longArrayTransfer";
        public const string ulongArrayTransfer = "ulongArrayTransfer";
        public const string floatArrayTransfer = "floatArrayTransfer";
        public const string doubleArrayTransfer = "doubleArrayTransfer";
        public const string decimalArrayTransfer = "decimalArrayTransfer";
        public const string charArrayTransfer = "charArrayTransfer";
        public const string stringArrayTransfer = "stringArrayTransfer";
        public const string boolArrayTransfer = "boolArrayTransfer";
        public const string objectArrayTransfer = "objectArrayTransfer";
        #endregion

        #region listTypes
        public const string byteListTransfer = "byteListTransfer";
        public const string sbyteListTransfer = "sbyteListTransfer";
        public const string shortListTransfer = "shortListTransfer";
        public const string ushortListTransfer = "ushortListTransfer";
        public const string intListTransfer = "intListTransfer";
        public const string uintListTransfer = "uintListTransfer";
        public const string longListTransfer = "longListTransfer";
        public const string ulongListTransfer = "ulongListTransfer";
        public const string floatListTransfer = "floatListTransfer";
        public const string doubleListTransfer = "doubleListTransfer";
        public const string decimalListTransfer = "decimalListTransfer";
        public const string charListTransfer = "charListTransfer";
        public const string stringListTransfer = "stringListTransfer";
        public const string boolListTransfer = "boolListTransfer";
        public const string objectListTransfer = "objectListTransfer";
        #endregion
    }
}
