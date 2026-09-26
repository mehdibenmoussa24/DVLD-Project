using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Logger
    {
        public static string sourceName = "DVLD";


        public static void InitializeEventLog()
        {
            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }
        }
        public static void LogError(string message)
        {
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);
        }

        public static void LogWarning(string message)
        {
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Warning);

        }

        public static void LogInformation(string message)
        {
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Information);

        }
    }
}
