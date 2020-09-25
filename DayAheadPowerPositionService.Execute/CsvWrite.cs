using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ExtensionMethods;

namespace DayAheadPowerPositionService.Execute
{
    //this class uses the CsvHelper Library
    //its open source and free for commercial use
    //https://joshclose.github.io/CsvHelper/
    //Install-Package CsvHelper -Version 15.0.5
    //---------------------------------------------------
    public class CsvWrite
    {
        private readonly Core.Logging.Logger _log = new Core.Logging.Logger();
        public bool Write(IEnumerable<Services.PowerTrade> trades)
        {
            _log.Log.WriteEntry("Entering Write method in CsvWrite class : " + DateTime.UtcNow.ToString(), _log.Information);
            var path = Core.Common.Configuration.OutputPath;
            Directory.CreateDirectory(path);
            DateTime dt = DateTime.Now;
            string fName = "PowerPosition_" + dt.ToString("yyyyMMdd") + "_" + dt.ToString("HHmm") + ".csv";

            var query2 = trades
                    .SelectMany(p => p.Periods)
                    .GroupBy(pair => pair.Period).Select(group => new { LocalTime = group.Key.PeriodFormat(), Volume = group.Sum(g => g.Volume) });

           
            try
            {
                using (var writer = new StreamWriter(path + @"\" + fName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    _log.Log.WriteEntry("Writing Position Data To Csv File : " + fName  + " - " + DateTime.UtcNow.ToString(), _log.Information);
                    csv.WriteRecords(query2);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                //could include an email message to support here
                _log.Log.WriteEntry("Error Creating csv file " + fName + " : " + ex.Message + " : " + DateTime.UtcNow.ToString(), _log.Information);
            }

            return true;
       
        }
    }
}
