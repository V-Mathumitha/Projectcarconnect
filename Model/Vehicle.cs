using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int VehicleYear { get; set; }
        public string Color { get; set; }
        public string RegistrationNumber { get; set; }
        public bool Availability { get; set; }
        public double DailyRate { get; set; }
        public Vehicle()
        {

        }
        public Vehicle(int VehicleID,string Model,string Make,int VehicleYear
            ,string Color,string RegistrationNumber,bool Availability,double DailyRate)
        {
            this.VehicleID = VehicleID;
            this.Model = Model;
            this.Make = Make;
            this.VehicleYear = VehicleYear;
            this.Color = Color;
            this.RegistrationNumber = RegistrationNumber;
            this.Availability = Availability;
            this.DailyRate = DailyRate;
        }
        public override string ToString()
        {
            return $"VehicleID: {VehicleID}, Model: {Model}, Make: {Make}, Year: {VehicleYear}, Color: {Color}, Registration No: {RegistrationNumber}, Available: {(Availability ? "Yes" : "No")}, Rate: Rs{DailyRate}/day";
        }



    }

}
