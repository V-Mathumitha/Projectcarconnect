using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DAO.Services
{
    public class ReportGenerator
    {
        public List<Reservation>GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "select * from Reservation";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    Reservation r = new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        TotalCost = Convert.ToDouble(reader["TotalCost"]),
                        Status = reader["Status"].ToString()


                    };
                    reservations.Add(r);

                    
                }
            }
            return reservations;
        }
        public List<Vehicle>GetAllVehicles()
        {
            List<Vehicle> vehicle = new List<Vehicle>();
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "select * from Vehicle";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Vehicle v = new Vehicle
                    {
                        VehicleID = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString(),
                        Make = reader["Make"].ToString(),
                        VehicleYear = (int)reader["VehicleYear"],
                        Color = reader["Color"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        Availability = Convert.ToBoolean(reader["Availability"]),
                        DailyRate = Convert.ToDouble(reader["DailyRate"])


                    };
                    vehicle.Add(v);
                }

            }return vehicle;
        }
        
         

    }

}
