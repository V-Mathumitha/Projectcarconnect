using System;

namespace CarConnect.Exceptions
{
    public class AuthenticationException : System.Exception
    {
        public AuthenticationException() { }

        public AuthenticationException(string message) : base(message) { }

        public AuthenticationException(string message, System.Exception inner) : base(message, inner) { }
    }
}
