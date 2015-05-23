using System;

namespace Ponygotchi.GameLogic
{
    internal class DeadPonyException : Exception
    {
        public DeadPonyException()
        {
        }

        public DeadPonyException(string message) : base(message)
        {
        }

        public DeadPonyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}