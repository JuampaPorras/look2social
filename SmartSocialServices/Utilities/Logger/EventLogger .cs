using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSocialServices.Utilities.Logger
{
    public class EventLogger : ILogger
    {
        public void Debug(string text)
        {
            EventLog.WriteEntry("SmartSocialWeb", text, EventLogEntryType.Information);
        }

        public void Warn(string text)
        {
            EventLog.WriteEntry("SmartSocialWeb", text, EventLogEntryType.Warning);
        }

        public void Error(string text)
        {
            EventLog.WriteEntry("SmartSocialWeb", text, EventLogEntryType.Error);
        }

        public void Error(string text, Exception ex)
        {
            Error(text);
            Error(ex.StackTrace);
        }
    }
}
