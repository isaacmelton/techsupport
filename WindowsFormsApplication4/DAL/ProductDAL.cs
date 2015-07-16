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
    public static class ProductDAL
    {
        /// <summary>
        /// GetProducts contains SELECT statement and returns appropriate 
        /// values based on the returned data from the connected Database, mainly the Products class
        /// </summary>
        /// <returns>List of products</returns>
        public static List<Product> GetProduct()
        {
            List<Product> prodList = new List<Product>();

            string selectStatement = "SELECT ProductCode, Name " +
                "FROM Products " +
                   "ORDER BY ProductCode";

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
                        int prodCodeOrd = reader.GetOrdinal("ProductCode");

                        while (reader.Read())
                        {
                            Product prod = new Product();

                            prod.ProductCode = reader.GetString(prodCodeOrd);

                            prodList.Add(prod);
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

            return prodList;

        }

    }
}
