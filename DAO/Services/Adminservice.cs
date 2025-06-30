using System;
using System.Data.SqlClient;
using Model;
using Util;

namespace DAO.Services
{
    public class AdminService : IAdminService
    {
        public Admin GetAdminById(int adminId)
        {
            Admin admin = null;

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM AdminTable WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AdminID", adminId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
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
                }
            }

            return admin;
        }

        public Admin GetAdminByUsername(string username)
        {
            Admin admin = null;

            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "SELECT * FROM AdminTable WHERE UserName = @UserName";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", username);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
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
                }
            }

            return admin;
        }

        public void RegisterAdmin(Admin admin)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = @"INSERT INTO AdminTable 
                                (AdminID,FirstName, LastName, Email, PhoneNumber, UserName, Password, Role, JoinDate)
                                VALUES 
                                (@AdminID,@FirstName, @LastName, @Email, @PhoneNumber, @UserName, @Password, @Role, @JoinDate)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AdminID", admin.AdminID);
                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@UserName", admin.UserName);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                cmd.Parameters.AddWithValue("@Role", admin.Role);
                cmd.Parameters.AddWithValue("@JoinDate", admin.JoinDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAdmin(Admin admin)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = @"UPDATE AdminTable SET 
                                FirstName = @FirstName,
                                LastName = @LastName,
                                Email = @Email,
                                PhoneNumber = @PhoneNumber,
                                UserName = @UserName,
                                Password = @Password,
                                Role = @Role,
                                JoinDate = @JoinDate
                                WHERE AdminID = @AdminID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@UserName", admin.UserName);
                cmd.Parameters.AddWithValue("@Password", admin.Password);
                cmd.Parameters.AddWithValue("@Role", admin.Role);
                cmd.Parameters.AddWithValue("@JoinDate", admin.JoinDate);
                cmd.Parameters.AddWithValue("@AdminID", admin.AdminID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAdmin(int adminId)
        {
            using (SqlConnection con = DBConnUtil.GetConnection())
            {
                string query = "DELETE FROM AdminTable WHERE AdminID = @AdminID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AdminID", adminId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
