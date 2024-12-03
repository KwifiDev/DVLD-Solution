using System;
using System.Diagnostics;
using System.Text;

namespace DVLD_DA
{
    internal static class ClsDA_LogManager
    {
        static readonly string SourceName = "DVLDSoft";
        static readonly string LogName = "DVLDLogs";

        public enum EnLayer { DataAccessLayer, BusinessLogicLayer, PresentationLayer };

        static ClsDA_LogManager()
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, LogName);
            }
        }

        private static string GetMessageFormat(Exception ex, string layer)
        {
            var sb = new StringBuilder();
            sb.AppendLine(new string('=', 82));
            sb.AppendLine($"Layer:          \t{layer}\n");
            sb.AppendLine($"Time:           \t{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");
            sb.AppendLine($"Exception Type: \t{ex.GetType().Name}\n");
            sb.AppendLine($"Message:    \t{ex.Message}\n");
            sb.AppendLine($"Stack Trace:    \t{ex.StackTrace}\n");
            sb.AppendLine(new string('=', 82));
            return sb.ToString();
        }

        public static void AssignLog(Exception ex, EventLogEntryType entryType, EnLayer layer)
        {
            string message = GetMessageFormat(ex, layer.ToString());
            EventLog.WriteEntry(SourceName, message, entryType);
        }
    }
}
