using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Util;
using CarConnect.Exceptions;

namespace DAO.Services
{
    public class AuthenticationService
    {
        public Customer AuthenticateCustomer(string username, string password)
        {
            try
            {
                Customer customer = null;

                using (SqlConnection con = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Customer WHERE UserName = @username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", username);

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
                    else
                    {
                       
                        throw new CarConnect.Exceptions.AuthenticationException("Customer not found.");
                    }
                }

                
                if (customer.Password.Trim() != password.Trim())
                {
                    Console.WriteLine("Password mismatch for username: " + username);
                    throw new CarConnect.Exceptions.AuthenticationException("Invalid password.");
                }

                Console.WriteLine("Authentication successful.");
                return customer;
            }
            catch (CarConnect.Exceptions.AuthenticationException ex)
            {
               
                Console.WriteLine("Authentication failed: " + ex.Message);
                throw; 
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                throw;
            }
        }



        public Admin AuthenticateAdmin(string username, string password)
        {
            Admin admin = null;

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM AdminTable WHERE UserName = @UserName";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", username);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    
                    throw new AdminNotFoundException("Admin not found for given username.");
                }

                admin = new Admin
                {
                    AdminID = (int)reader["AdminID"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    Role = reader["Role"].ToString(),
                    JoinDate = Convert.ToDateTime(reader["JoinDate"])
                };

                if (admin.Password.Trim() != password.Trim())
                {
                    throw new CarConnect.Exceptions.AuthenticationException("Invalid password.");
                }

            }

            return admin;
        }

    }
}


