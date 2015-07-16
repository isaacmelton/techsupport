using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TechSupportData
{
    public static class TechSupportDBConnection
    {
        /// <summary>
        /// Establishes the SQL connection to the database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            string connectionString =
                "Data Source=localhost;Initial Catalog=TechSupport;" +
            "Integrated Security=True";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
         }
    }
}
