using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Conversions
    {
        public static int ToInt(string param, int defaultValue)
        {
            int retValue = defaultValue;
            try {
                int.TryParse(param, out retValue);
            }
            catch(Exception ex) {
            }
            return retValue;
        }

        public static decimal? ToDecimal(object param)
        {
            decimal retValue = decimal.MinValue;
            try
            {
                if (param == null) return null;
                if (decimal.TryParse(param.ToString(), out retValue)) return retValue;
                else return null;
            }
            catch (Exception ex)
            {
            }
            return retValue;
        }

        public static decimal ToDecimal(object param, decimal defaultValue)
        {
            decimal retValue = defaultValue;
            try
            {
                if (param == null) return defaultValue;
                decimal.TryParse(param.ToString(), out retValue);
            }
            catch (Exception ex)
            {
            }
            return retValue;
        }

    }
}
