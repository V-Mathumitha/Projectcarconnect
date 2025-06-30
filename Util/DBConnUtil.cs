using System;
using System.Data.SqlClient;
using CarConnect.Exceptions;
using System.Configuration;

namespace Util
{
    public class DBConnUtil
    {
        public static SqlConnection GetConnection()
        {
            try
            {
               
                string connectionString = DBPropertyUtil.GetConnectionString("MyConnection");

                
                return new SqlConnection(connectionString);
            }
            catch (SystemException ex)
            {
               
                throw new DatabaseConnectionException("Failed to establish database connection.", ex);
            }
        }
    }
}
