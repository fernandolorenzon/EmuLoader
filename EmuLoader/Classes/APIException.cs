using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLoader.Classes
{
    public class APIException : Exception
    {
        public APIException(string message):base(message)
        {

        }
    }
}
