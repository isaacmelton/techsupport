using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using WindowsFormsApplication4.Model;
using TechSupportData;


namespace WindowsFormsApplication4.DAL
{
    public static class IncidentDAL
    {
        /// <summary>
        /// GetIncidents contains SELECT statement and returns appropriate 
        /// values based on the returned data from the connected Database, mainly the Incidents class
        /// </summary>
        /// <returns>List of incidents</returns>
        public static List<Incident> GetIncidents()
        {
            List<Incident> incidentsList = new List<Incident>();

            string selectStatement = "SELECT IncidentID, ProductCode, DateOpened, Customers.CustomerID, " + 
            "Customers.Name AS Name, Incidents.TechID, " +
            " Technicians.Name AS TechName, Title, Description, DateClosed " +
                "FROM Incidents " + 
                    "LEFT OUTER JOIN Customers ON Incidents.CustomerID = Customers.CustomerID " +
                    "LEFT OUTER JOIN Technicians ON Incidents.TechID = Technicians.TechID "
                        + " WHERE Incidents.DateClosed IS NULL ORDER BY TechName DESC";

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
                        int prodDateOrd = reader.GetOrdinal("DateOpened");
                        int prodCustOrd = reader.GetOrdinal("Name");
                        int prodTitleOrd = reader.GetOrdinal("Title");
                        int prodTechNameOrd = reader.GetOrdinal("TechName");
                        int prodDescOrd = reader.GetOrdinal("Description");
                        int prodDateClosedOrd = reader.GetOrdinal("DateClosed");

                        while (reader.Read())
                        {
                            Incident incident = new Incident();
                            incident.IncidentID = (int)reader["IncidentID"];
                            incident.ProductCode = reader.GetString(prodCodeOrd);
                            incident.DateOpened = reader.GetDateTime(prodDateOrd);
                            incident.CustomerName = reader.GetString(prodCustOrd);
                            incident.CustomerID = (int)reader["CustomerID"];
                            incident.TechID = CheckValue(reader["TechID"]);

                            if (reader.IsDBNull(prodTechNameOrd)) {
                            incident.TechName = null;
                        }
                            else {
                                incident.TechName = reader.GetString(prodTechNameOrd);
                            }

                            if (reader.IsDBNull(prodDateClosedOrd))
                            {
                                incident.DateClosed = null;
                            }
                            else
                            {
                                incident.DateClosed = reader.GetDateTime(prodDateClosedOrd);

                            }
                            incident.Title = reader.GetString(prodTitleOrd);
                            incident.Description = reader.GetString(prodDescOrd);
                            incidentsList.Add(incident);
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

            return incidentsList;

        }



        /// <summary>
        /// Adds an incident to the Incidents database using a DB connection and Validating the information.
        /// </summary>
        /// <param name="incident"></param>
        /// <returns></returns>
        public static int AddIncident(Incident incident)
        {
            SqlConnection connection = TechSupportDBConnection.GetConnection();
            string insertStatement = "INSERT Incidents " +
                "(CustomerID, ProductCode, DateOpened, Title, Description) " +
                "VALUES (@CustomerID, @ProductCode, @DateOpened, @Title, @Description)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@CustomerID", incident.CustomerID);
            insertCommand.Parameters.AddWithValue("@ProductCode", incident.ProductCode);
            insertCommand.Parameters.AddWithValue("@DateOpened", DateTime.Now);
            insertCommand.Parameters.AddWithValue("@Title", incident.Title);
            insertCommand.Parameters.AddWithValue("@Description", incident.Description);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement = "SELECT IDENT_CURRENT('Incidents') FROM Incidents";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int incidentID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return incidentID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateIncident(Incident oldInc, Incident newInc)
        {
            SqlConnection connection = TechSupportDBConnection.GetConnection();
            string updateStatement = "UPDATE Incidents SET " +
                "TechID = @NewTechID, Description = @NewDescription " +
                "WHERE IncidentID = " + oldInc.IncidentID;
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@NewTechID", newInc.TechID);

            if (String.Equals(oldInc.Description, newInc.Description))
            {
             
               
                    updateCommand.Parameters.AddWithValue("@NewDescription", (oldInc.Description + Environment.NewLine
                        + DateTime.Now.ToShortDateString() + " updated/assigned the technician"));
              
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@NewDescription", (oldInc.Description + Environment.NewLine
                    + DateTime.Now.ToShortDateString() + " " + newInc.Description));
            }

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else return false;
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
            
            finally
            {
                connection.Close();
              
            }
        }

       

     
        /// <summary>
        /// Returns a list of Open IncidentIDs
        /// </summary>
        /// <returns>A list of Open Incident IDs</returns>
        public static List<int> GetIncidentIDs()
        {
            List<int> incIDList = new List<int>();

            string selectStatement = "SELECT IncidentID " +
                "FROM Incidents WHERE DateClosed IS NULL";

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
                        while (reader.Read())
                        {
                            int incidentID = (int)reader["IncidentID"];   
                            
                            
                            incIDList.Add(incidentID);
                        }
                        connection.Close();
                    }
                }
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

            return incIDList;

        }
        /// <summary>
        /// returns the Incident specified by the incident ID
        /// </summary>
        /// <param name="incID">The IncidentID of the incident to be returned</param>
        /// <returns>the Specified Incident</returns>
        public static Incident ReturnIncident(int @incID)
         {
            Incident returnInc = new Incident();
            string selectStatement = "SELECT IncidentID, Incidents.CustomerID, Customers.Name, ProductCode, DateOpened, Title, Description, TechID " +
                "FROM Incidents JOIN Customers on Incidents.CustomerID = Customers.CustomerID WHERE IncidentID = " + @incID;

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
                        int incCustName = reader.GetOrdinal("Name");
                        int incProdCode = reader.GetOrdinal("ProductCode");
                        int incDateOrd = reader.GetOrdinal("DateOpened");
                        int incTitleOrd = reader.GetOrdinal("Title");
                        int incDescOrd = reader.GetOrdinal("Description");
                        int incTechIDOrd = reader.GetOrdinal("TechID");
                        while (reader.Read())
                        {
                            returnInc.IncidentID = (int)reader["IncidentID"];
                            returnInc.CustomerID = (int)reader["CustomerID"];
                            
                            if (reader.IsDBNull(incTechIDOrd))
                            {
                               returnInc.TechID = null;
                            }
                            else
                            {
                               returnInc.TechID = (int)reader["TechID"];
                            }

                            returnInc.CustomerName = reader.GetString(incCustName);
                            returnInc.ProductCode = reader.GetString(incProdCode);
                            returnInc.DateOpened = reader.GetDateTime(incDateOrd);
                            returnInc.Title = reader.GetString(incTitleOrd);
                            returnInc.Description = reader.GetString(incDescOrd);


                        }
                        connection.Close();
                    }
                }
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

            return returnInc;

        }
        /// <summary>
        /// Closes the incident by setting the DateClosed DateTime to the current date
        /// </summary>
        /// <param name="theInc">The Incident to close</param>
        /// <returns></returns>
        public static bool CloseIncident(Incident theInc)
        {
            SqlConnection connection = TechSupportDBConnection.GetConnection();
            string updateStatement = "UPDATE Incidents SET " +
                "DateClosed = @NewDateClosed" + 
                " WHERE IncidentID = " + theInc.IncidentID;
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@NewDateClosed", DateTime.Now);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else return false;
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

            finally
            {
                connection.Close();
            }
        }

        private static string CheckString(string p)
        {
            if (!String.IsNullOrEmpty(p))
            {
                return p;
            }
            else return "";

            //throw new NotImplementedException();
        }

        private static int? CheckValue(object p)
        {
            if (!DBNull.Value.Equals(p))
                return (int?)p;
            else return null;

            //throw new NotImplementedException();
        }


        public static List<Incident> GetOpenIncidentsByTech(int IdToCheck)
        {
            List<Incident> incidentsList = new List<Incident>();

            string selectStatement = "SELECT Products.Name as ProductName, DateOpened, DateClosed, " +
            "Customers.Name AS Name, Incidents.TechID, " +
            " Technicians.Name AS TechName, Title " +
                "FROM Incidents " +
                    "LEFT OUTER JOIN Products ON Incidents.ProductCode = Products.ProductCode " +
                    "LEFT OUTER JOIN Customers ON Incidents.CustomerID = Customers.CustomerID " +
                    "LEFT OUTER JOIN Technicians ON Incidents.TechID = Technicians.TechID "
                        + " WHERE Incidents.DateClosed IS NULL AND Incidents.TechID = " + IdToCheck;

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
                        int prodNameOrd = reader.GetOrdinal("ProductName");
                        int prodDateOrd = reader.GetOrdinal("DateOpened");
                        int prodCustOrd = reader.GetOrdinal("Name");
                        int prodTitleOrd = reader.GetOrdinal("Title");


                        while (reader.Read())
                        {
                            Incident incident = new Incident();
                            incident.ProductName = reader.GetString(prodNameOrd);
                            incident.DateOpened = reader.GetDateTime(prodDateOrd);
                            incident.CustomerName = reader.GetString(prodCustOrd);
                            incident.TechID = CheckValue(reader["TechID"]);

                            incident.Title = reader.GetString(prodTitleOrd);
            
                            incidentsList.Add(incident);
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

            return incidentsList;

        }

    }
}
