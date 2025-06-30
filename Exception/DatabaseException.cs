using System;

namespace CarConnect.Exceptions
{
    public class DatabaseConnectionException : System.Exception
    {
        public DatabaseConnectionException()
            : base("Database connection failed.") { }

        public DatabaseConnectionException(string message)
            : base(message) { }

        public DatabaseConnectionException(string message, System.Exception inner)
            : base(message, inner) { }
    }
}
