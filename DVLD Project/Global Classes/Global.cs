using Common;
using DVLD.Business;
using Microsoft.Win32;
using System;
using System.Diagnostics.Eventing.Reader;


namespace DVLD_Project
{
    internal static class Global
    {
        public static User CurrentUser;

        public enum enCredentialType {
            Username , Password 
        }
        public static bool SaveCredential(enCredentialType credentialType, string value)
        {
            // Specify the Registry key and path
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Driving-License-Application";


            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, credentialType.ToString(), value, RegistryValueKind.String);
                return true;
                
            }
            catch (Exception ex)
            {
                Logger.LogError($"An error occurred: {ex.Message}");
                return false;
            }
           
        }

        public static bool GetStoredCredential(enCredentialType credentialType, ref string value)
        {
            // Specify the Registry key and path
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Driving-License-Application";
            string storedValue = String.Empty;


            try
            {
                // Read the value from the Registry
                storedValue = Registry.GetValue(keyPath, credentialType.ToString(), null) as string;


                if (storedValue != null)
                {
                    value = storedValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"An error occurred: {ex.Message}");
            }
            return false;
        }

       
    }
}
