using System;

namespace CarConnect.Exceptions
{
    public class VehicleNotFoundException : System.Exception
    {
        public VehicleNotFoundException() { }

        public VehicleNotFoundException(string message) : base(message) { }

        public VehicleNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    }
}
