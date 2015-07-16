using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSupportData;
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4.DAL
{
    public static class TechnicianDAL
    {
        public static List<Technician> GetTechnician()
        {
            List<Technician> techList = new List<Technician>();

            string selectStatement = "SELECT TechID, Name, Email, Phone " +
                "FROM Technicians " +
                   "ORDER BY Name";

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
                        int techNameOrd = reader.GetOrdinal("Name");

                        while (reader.Read())
                        {
                            Technician tech = new Technician();

                            tech.TechID = (int)reader["TechID"];
                            tech.Name = reader.GetString(techNameOrd);

                            techList.Add(tech);
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

            return techList;

        }

        public static List<Technician> GetTechsWithOpenIncidents()
        {
            List<Technician> techList = new List<Technician>();

            //string selectStatement = "SELECT Technicians.TechID, Technicians.Name, Technicians.Email, " +
            //"Technicians.Phone, Incidents.ProductCode, Incidents.DateOpened, Incidents.CustomerID, Incidents.Title " 
           //+ "FROM Technicians join Incidents on Technicians.TechID = Incidents.TechID " +
             //   "Where Incidents.DateClosed IS NULL ORDER BY Technicians.TechID";

            string selectStatement = "SELECT Technicians.TechID, Technicians.Name, Technicians.Email, " +
            "Technicians.Phone " 
            + "FROM Technicians join Incidents on Technicians.TechID = Incidents.TechID " +
               "Where Incidents.DateClosed IS NULL GROUP BY Technicians.TechID, Technicians.Name, Technicians.Email, Technicians.Phone ORDER BY Technicians.TechID";

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
                        int techNameOrd = reader.GetOrdinal("Name");
                        int techEmailOrd = reader.GetOrdinal("Email");
                        int techPhoneOrd = reader.GetOrdinal("Phone");
                        while (reader.Read())
                        {
                            Technician tech = new Technician();

                            tech.TechID = (int)reader["TechID"];
                            tech.Name = reader.GetString(techNameOrd);
                            tech.Email = reader.GetString(techEmailOrd);
                            tech.Phone = reader.GetString(techPhoneOrd);

                            techList.Add(tech);
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

            return techList;

        }

    public static Technician GetSpecificTech(int techID) {
        Technician returnTech = new Technician();

        SqlConnection connection =  TechSupportDBConnection.GetConnection();

        string selectStatement = "SELECT TechID, Name, Email, Phone "
           + "FROM Technicians WHERE TechID = @TechID";

        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.Parameters.AddWithValue("@TechID", techID);

        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                returnTech.TechID = (int)reader["TechID"];
                returnTech.Name = reader["Name"].ToString();
                returnTech.Email = reader["Email"].ToString();
                returnTech.Phone = reader["Phone"].ToString();
            }
            else
            {
                returnTech = null;
            }
            reader.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return returnTech;
               }
       
        }
}
