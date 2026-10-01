using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class ApplicationTypeData
    {
        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID,
          ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                                ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);

                                // The record was found
                                return true;
                            }
                            else
                            {
                                // The record was not found
                                return false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("Error: " + ex.Message);
                    }
                }
            }

            return false;
        }

        public static DataTable GetAllApplicationTypes()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypes order by ApplicationTypeTitle";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
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
                        Logger.LogError("Error: " + ex.Message);
                    }
                }
            }
            return dt;

        }

        public static int AddNewApplicationType(string Title, float Fees)
        {
            int ApplicationTypeID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationTypeTitle", SqlDbType.NVarChar, 150).Value = Title;
                    command.Parameters.Add("@ApplicationFees", SqlDbType.SmallMoney).Value = Fees;
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ApplicationTypeID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("Error: " + ex.Message);

                    }
                }
            }

            return ApplicationTypeID;

        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string Title, float Fees)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"Update  ApplicationTypes  
                            set ApplicationTypeTitle = @Title,
                                ApplicationFees = @Fees
                                where ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = ApplicationTypeID;
                    command.Parameters.Add("@ApplicationTypeTitle", SqlDbType.NVarChar, 150).Value = Title;
                    command.Parameters.Add("@ApplicationFees", SqlDbType.SmallMoney).Value = Fees;

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("Error: " + ex.Message);
                        return false;
                    }
                }
            }
            return (rowsAffected > 0);
        }
    }
}
