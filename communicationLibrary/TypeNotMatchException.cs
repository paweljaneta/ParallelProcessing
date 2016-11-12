using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace communicationLibrary
{
    class TypeNotMatchException: Exception
    {
        public TypeNotMatchException()
        {
        }

        public TypeNotMatchException(string message):base (message)
        {
        }

        public TypeNotMatchException(string message,Exception inner):base(message,inner)
        {
        }

    }
}
