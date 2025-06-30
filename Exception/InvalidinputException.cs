using System;

namespace CarConnect.Exceptions
{
    public class InvalidInputException : System.Exception
    {
        public InvalidInputException()
            : base("Invalid input provided.") { }

        public InvalidInputException(string message)
            : base(message) { }

        public InvalidInputException(string message, System.Exception inner)
            : base(message, inner) { }
    }
}
