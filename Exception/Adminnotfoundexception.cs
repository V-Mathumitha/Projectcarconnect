using System;

namespace CarConnect.Exceptions
{
    public class AdminNotFoundException : SystemException
    {
        public AdminNotFoundException() : base("Admin not found.") { }

        public AdminNotFoundException(string message) : base(message) { }

        public AdminNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    }
}
