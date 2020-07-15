using System;

namespace EmuLoader.Core.Classes
{
    public class APIException : Exception
    {
        public APIException(string message) : base(message)
        {

        }
    }
}
