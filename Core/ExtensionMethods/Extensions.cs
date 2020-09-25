using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ExtensionMethods
{
    public static class Extensions
    {
        public static string PeriodFormat(this int period)
        {
            string res;
            switch (period)
            {
                case 1:
                    res = "23:00";
                    break;
                case 2:
                    res = "00:00";
                    break;
                case 3:
                    res = "01:00";
                    break;
                case 4:
                    res = "02:00";
                    break;
                case 5:
                    res = "03:00";
                    break;
                case 6:
                    res = "04:00";
                    break;
                case 7:
                    res = "05:00";
                    break;
                case 8:
                    res = "06:00";
                    break;
                case 9:
                    res = "07:00";
                    break;
                case 10:
                    res = "08:00";
                    break;
                case 11:
                    res = "09:00";
                    break;
                case 12:
                    res = "10:00";
                    break;
                case 13:
                    res = "11:00";
                    break;
                case 14:
                    res = "12:00";
                    break;
                case 15:
                    res = "13:00";
                    break;
                case 16:
                    res = "14:00";
                    break;
                case 17:
                    res = "15:00";
                    break;
                case 18:
                    res = "16:00";
                    break;
                case 19:
                    res = "17:00";
                    break;
                case 20:
                    res = "18:00";
                    break;
                case 21:
                    res = "19:00";
                    break;
                case 22:
                    res = "20:00";
                    break;
                case 23:
                    res = "21:00";
                    break;
                case 24:
                    res = "22:00";
                    break;
                default:
                    res = "unknown";
                    break;
            }
            return res;
        }
    }
}
