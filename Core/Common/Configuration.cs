using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public static class Configuration
    {
        private static string _outputPath;
        private static int _interval = 0;
        private static bool res;
        private static int milliSecs;

        public static string OutputPath
        {
            get
            {
                if (string.IsNullOrEmpty(_outputPath))
                    _outputPath = String.Format("{0}", ConfigurationManager.AppSettings["OutputPath"]);
                
                return _outputPath;
            }
        }

        public static int Interval
        {
           get
            {
                if ((_interval.Equals(0)))
                    res = int.TryParse(ConfigurationManager.AppSettings["TimeIntervalInMilliSeconds"], result: out milliSecs);
                if(res)
                {
                    _interval = milliSecs;
                }
                return _interval;
            }
        }
    }
}
