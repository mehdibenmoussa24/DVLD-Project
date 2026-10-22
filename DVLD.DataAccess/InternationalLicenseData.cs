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
    public class InternationalLicenseData
    {
        public static bool GetInternationalLicenseInfoByID(int InternationalLicenseID,
            ref int ApplicationID,
            ref int DriverID, ref int IssuedUsingLocalLicenseID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = InternationalLicenseID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];


                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["DriverID"];

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
            return false ;
        }

        public static DataTable GetAllInternationalLicenses()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT    InternationalLicenseID, ApplicationID,DriverID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive
		    from InternationalLicenses 
                order by IsActive, ExpirationDate desc";

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

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT    InternationalLicenseID, ApplicationID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive
		    from InternationalLicenses where DriverID=@DriverID
                order by ExpirationDate desc";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

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


        public static int AddNewInternationalLicense(int ApplicationID,
             int DriverID, int IssuedUsingLocalLicenseID,
             DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"
                               Update InternationalLicenses 
                               set IsActive=0
                               where DriverID=@DriverID;

                             INSERT INTO InternationalLicenses
                               (
                                ApplicationID,
                                DriverID,
                                IssuedUsingLocalLicenseID,
                                IssueDate,
                                ExpirationDate,
                                IsActive,
                                CreatedByUserID)
                         VALUES
                               (@ApplicationID,
                                @DriverID,
                                @IssuedUsingLocalLicenseID,
                                @IssueDate,
                                @ExpirationDate,
                                @IsActive,
                                @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@ApplicationID",SqlDbType.Int).Value = ApplicationID;
                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                    command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = IssuedUsingLocalLicenseID;
                    command.Parameters.Add("@IssueDate", SqlDbType.SmallDateTime).Value = IssueDate;
                    command.Parameters.Add("@ExpirationDate", SqlDbType.SmallDateTime).Value = ExpirationDate;

                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                    command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;



                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            InternationalLicenseID = insertedID;
                        }
                    }

                    catch (Exception ex)
                    {
                        Logger.LogError("Error: " + ex.Message);
                    }
                }
            }
            return InternationalLicenseID;

        }

        public static bool UpdateInternationalLicense(
              int InternationalLicenseID, int ApplicationID,
             int DriverID, int IssuedUsingLocalLicenseID,
             DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {

                string query = @"UPDATE InternationalLicenses
                           SET 
                              ApplicationID=@ApplicationID,
                              DriverID = @DriverID,
                              IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              IsActive = @IsActive,
                              CreatedByUserID = @CreatedByUserID
                         WHERE InternationalLicenseID=@InternationalLicenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = InternationalLicenseID;
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;
                    command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = IssuedUsingLocalLicenseID;
                    command.Parameters.Add("@IssueDate", SqlDbType.SmallDateTime).Value = IssueDate;
                    command.Parameters.Add("@ExpirationDate", SqlDbType.SmallDateTime).Value = ExpirationDate;

                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                    command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;

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

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {

                string query = @"  
                            SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where DriverID=@DriverID and GetDate() between IssueDate and ExpirationDate 
                            order by ExpirationDate Desc;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            InternationalLicenseID = insertedID;
                        }
                    }

                    catch (Exception ex)
                    {
                        Logger.LogError("Error: " + ex.Message);
                    }
                }
            }

            return InternationalLicenseID;
        }
    }
}
