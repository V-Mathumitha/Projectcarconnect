using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }
        public string Status { get; set; }

        public Reservation()
        {

        }
        public Reservation(int ReservationID,int CustomerID,
            int VehicleID,DateTime StartDate,DateTime EndDate,double TotalCost,string Status)
        {
            this.ReservationID = ReservationID;
            this.CustomerID = CustomerID;
            this.VehicleID = VehicleID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.TotalCost = TotalCost;
            this.Status = Status;
        }
        public override string ToString()
        {
            return $"ReservationID: {ReservationID}, CustomerID: {CustomerID}, VehicleID: {VehicleID}, " +
                   $"StartDate: {StartDate:yyyy-MM-dd}, EndDate: {EndDate:yyyy-MM-dd}, " +
                   $"TotalCost: {TotalCost:C}, Status: {Status}";
        }






    }
}
