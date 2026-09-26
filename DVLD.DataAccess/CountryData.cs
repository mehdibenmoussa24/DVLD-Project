using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;

namespace DVLD.DataAccess
{
    public class CountryData
    {
        public static bool GetCountryInfoByID(int CountryID, ref string CountryName)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // The record was found

                            CountryName = (string)reader["CountryName"];
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error: {ex}");
                }
            }
            return false;
        }

        public static bool GetCountryInfoByName(string CountryName, ref int CountryID)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@CountryName", SqlDbType.NVarChar, 50).Value = CountryName;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // The record was found

                            CountryID = (int)reader["CountryID"];
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error: {ex}");
                }
            }
            return false;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Countries order by CountryName";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)

                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error: {ex}");
                }
            }
            return dt;
        }
    }
}
