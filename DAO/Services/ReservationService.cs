using CarConnect.Exception;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using Util;

namespace DAO.Services
{
    public class ReservationService : IReservationService
    {
        public Reservation GetReservationById(int reservationId)
        {
            Reservation reservation = null;

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Reservation WHERE ReservationID = @ReservationID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationID", reservationId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reservation = new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        TotalCost = Convert.ToDouble(reader["TotalCost"]),
                        Status = reader["Status"].ToString()
                    };
                }
            }

            return reservation;
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Reservation";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation reservation = new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        TotalCost = Convert.ToDouble(reader["TotalCost"]),
                        Status = reader["Status"].ToString()
                    };

                    reservations.Add(reservation);
                }
            }

            return reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                con.Open();

                
                string checkQuery = "SELECT Availability FROM Vehicle WHERE VehicleID = @VehicleID";
                SqlCommand cmd= new SqlCommand(checkQuery, con);
                cmd.Parameters.AddWithValue("@VehicleID", reservation.VehicleID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bool isAvailable = Convert.ToBoolean(reader["Availability"]);
                    if (!isAvailable)
                    {
                        reader.Close();
                        throw new ReservationException("Vehicle is not available for reservation.");
                    }
                }
                else
                {
                    reader.Close();
                    throw new ReservationException("Vehicle not found.");
                    
                }

                reader.Close(); 

                
                string insertQuery = @"INSERT INTO Reservation
                              ( ReservationID,CustomerID, VehicleID, StartDate, EndDate, TotalCost, Status) 
                              VALUES 
                              (@ReservationID,@CustomerID, @VehicleID, @StartDate, @EndDate, @TotalCost, @Status)";

                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@ReservationID", reservation.ReservationID);
                insertCmd.Parameters.AddWithValue("@CustomerID", reservation.CustomerID);
                insertCmd.Parameters.AddWithValue("@VehicleID", reservation.VehicleID);
                insertCmd.Parameters.AddWithValue("@StartDate", reservation.StartDate);
                insertCmd.Parameters.AddWithValue("@EndDate", reservation.EndDate);
                insertCmd.Parameters.AddWithValue("@TotalCost", reservation.TotalCost);
                insertCmd.Parameters.AddWithValue("@Status", reservation.Status);

                insertCmd.ExecuteNonQuery();
            }
        }


        public void UpdateReservation(Reservation reservation)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = @"UPDATE Reservation SET 
                                CustomerID = @CustomerID,
                                VehicleID = @VehicleID,
                                StartDate = @StartDate,
                                EndDate = @EndDate,
                                TotalCost = @TotalCost,
                                Status = @Status
                                WHERE ReservationID = @ReservationID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", reservation.CustomerID);
                cmd.Parameters.AddWithValue("@VehicleID", reservation.VehicleID);
                cmd.Parameters.AddWithValue("@StartDate", reservation.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", reservation.EndDate);
                cmd.Parameters.AddWithValue("@TotalCost", reservation.TotalCost);
                cmd.Parameters.AddWithValue("@Status", reservation.Status);
                cmd.Parameters.AddWithValue("@ReservationID", reservation.ReservationID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CancelReservation(int reservationId)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "DELETE FROM Reservation WHERE ReservationID = @ReservationID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservationID", reservationId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public double CalculateTotalCost(DateTime startDate, DateTime endDate, double dailyRate)
        {
            int numberOfDays = (endDate - startDate).Days;
            if (numberOfDays <= 0)
                numberOfDays = 1;
            return numberOfDays * dailyRate;
        }


    }
}
