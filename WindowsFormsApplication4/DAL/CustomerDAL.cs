using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using WindowsFormsApplication4.Model;
using TechSupportData;
using WindowsFormsApplication4.Model;


namespace WindowsFormsApplication4.DAL
{
    public static class CustomerDAL
    {
        /// <summary>
        /// GetCustomers contains SELECT statement and returns appropriate 
        /// values based on the returned data from the connected Database, mainly the Customers class
        /// </summary>
        /// <returns>List of customers</returns>
        public static List<Customer> GetCustomers()
        {
            List<Customer> customerList = new List<Customer>();

            string selectStatement = "SELECT Name, CustomerID " +
                "FROM Customers " +
                   "ORDER BY CustomerID";

            try
            {
                    
                    using (SqlConnection connection = TechSupportDBConnection.GetConnection())
                    {
                        try
                        {
                            connection.Open();
                        }
                        catch (SqlException ex)
                        {
                            throw ex;
                        }
                    

                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
 
                    {
                        int custNameOrd = reader.GetOrdinal("Name");
                        
                        while (reader.Read())
                        {
                            Customer cust = new Customer();

                            cust.Name = reader.GetString(custNameOrd);
                            cust.CustomerID = (int)reader["CustomerID"];

                          
                            customerList.Add(cust);
                            
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return customerList;
    
        }

    }
}
