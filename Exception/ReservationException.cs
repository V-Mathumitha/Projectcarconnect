using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Exception

{
    
        public class ReservationException : System.Exception
        {
            public ReservationException() { }

            public ReservationException(string message) : base(message) { }

            public ReservationException(string message, System.Exception inner) : base(message, inner) { }
        }
    }



