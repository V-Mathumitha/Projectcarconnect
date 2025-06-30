using CarConnect.Exceptions;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Util;

using System.Runtime.Remoting.Messaging;

namespace DAO.Services
{
    public class VehicleService : IVehicleService
    {
        public Vehicle GetVehicleById(int vehicleId)
        {
            Vehicle vehicle = null;

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Vehicle WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    throw new VehicleNotFoundException("Vehicle not found with the given ID.");
                }
                    vehicle = new Vehicle
                    {
                        VehicleID = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString(),
                        Make = reader["Make"].ToString(),
                        VehicleYear = Convert.ToInt32(reader["VehicleYear"]),
                        Color = reader["Color"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        Availability = Convert.ToBoolean(reader["Availability"]),
                        DailyRate = Convert.ToDouble(reader["DailyRate"])
                    };
                
            }
            return vehicle;
        }
        public List<Vehicle> GetAvailableVehicles()
        {
            List<Vehicle> availableVehicles = new List<Vehicle>();

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Vehicle WHERE Availability = 1"; 
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle
                    {
                        VehicleID = (int)reader["VehicleID"],
                        Model = reader["Model"].ToString(),
                        Make = reader["Make"].ToString(),
                        VehicleYear = Convert.ToInt32(reader["VehicleYear"]),
                        Color = reader["Color"].ToString(),
                        RegistrationNumber = reader["RegistrationNumber"].ToString(),
                        Availability = Convert.ToBoolean(reader["Availability"]),
                        DailyRate = Convert.ToDouble(reader["DailyRate"])
                    };

                    availableVehicles.Add(vehicle);
                }
            }

            return availableVehicles;
        }







        public void AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = @"INSERT INTO Vehicle 
                                (VehicleID,Model, Make,VehicleYear, Color, RegistrationNumber, Availability, DailyRate)
                                VALUES 
                                (@VehicleId,@Model, @Make, @VehicleYear, @Color, @RegistrationNumber, @Availability, @DailyRate)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);

                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Availability", vehicle.Availability);
                cmd.Parameters.AddWithValue("@DailyRate", vehicle.DailyRate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = @"UPDATE Vehicle SET 
                                Model = @Model,
                                Make = @Make,
                                VehicleYear = @VehicleYear,
                                Color = @Color,
                                RegistrationNumber = @RegistrationNumber,
                                Availability = @Availability,
                                DailyRate = @DailyRate
                                WHERE VehicleID = @VehicleID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@Color", vehicle.Color);
                cmd.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                cmd.Parameters.AddWithValue("@Availability", vehicle.Availability);
                cmd.Parameters.AddWithValue("@DailyRate", vehicle.DailyRate);
                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "DELETE FROM Vehicle WHERE VehicleID = @VehicleID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
