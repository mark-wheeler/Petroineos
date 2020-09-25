using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logging
{
    public class Logger
    {
        private System.Diagnostics.EventLog _log { get; set; }
        private static EventLogEntryType _entryType { get; }
        
        public Logger()
        {
            _log = new System.Diagnostics.EventLog();
            if (!EventLog.SourceExists("DayAheadEventLogSource"))
            {
                EventLog.CreateEventSource(
                    "DayAheadEventLogSource", "DayAheadEventLog");
            }
            _log.Source = "DayAheadEventLogSource";
            _log.Log = "DayAheadEventLog";
        }

        public System.Diagnostics.EventLog Log
        {
            get
            {
                return _log;
            }
        }
        public  EventLogEntryType Information
        {
            get
            {
                return EventLogEntryType.Information;
                //return _entryType.;
            }
        }

       
    }
}
