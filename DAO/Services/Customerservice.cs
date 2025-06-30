using CarConnect.Exceptions;
using Model;
using System;
using System.Data.SqlClient;
using Util;

namespace DAO.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        UserName = reader["UserName"].ToString(), 
                        Password = reader["Password"].ToString(),
                        RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                    };
                }
            }

            return customer;
        }
        public Customer GetCustomerByUsername(string username)
        {
            Customer customer = null;
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                String query = "select * from Customer where username=@username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if ((reader.Read()))
                {
                    customer = new Customer
                    {
                        CustomerID = (int)reader["CustomerID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])





                    };

                }
            }
            return customer;


            
                
        }

        public void RegisterCustomer(Customer customer)
        {
            
            if (string.IsNullOrWhiteSpace(customer.FirstName) ||
                string.IsNullOrWhiteSpace(customer.Email) ||
                string.IsNullOrWhiteSpace(customer.UserName) ||
                string.IsNullOrWhiteSpace(customer.Password))
            {
                throw new InvalidInputException("FirstName, Email, Username, and Password are required.");
            }

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = @"INSERT INTO Customer
                                (CustomerID,FirstName, LastName, Email, PhoneNumber, Address, UserName, Password, RegistrationDate) 
                                VALUES 
                                (@CustomerID,@FirstName, @LastName, @Email, @PhoneNumber, @Address, @UserName, @Password, @RegistrationDate)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@UserName", customer.UserName);
                cmd.Parameters.AddWithValue("@Password", customer.Password);
                cmd.Parameters.AddWithValue("@RegistrationDate", customer.RegistrationDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    



public void UpdateCustomer(Customer customer)

        {
            using (SqlConnection con = DBConnUtil.GetConnection()) 
            {
                string query= @"UPDATE Customer SET 
                         FirstName = @FirstName,
                         LastName = @LastName,
                         Email = @Email,
                         PhoneNumber = @PhoneNumber,
                         Address = @Address,
                         UserName = @UserName,
                         Password = @Password
                         WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@UserName", customer.UserName);
                cmd.Parameters.AddWithValue("@Password", customer.Password);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                con.Open();
                cmd.ExecuteNonQuery();



            }

            
        }
        public void DeleteCustomer(int customerId)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "delete from Customer where CustomerID=@CustomerID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            
        }

    }
}
