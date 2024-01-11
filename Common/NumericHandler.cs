using System;

namespace InfrastructureManagement.Common
{
    public static class NumericHandler
    {
        public static decimal ConvertToDecimal(string value)
        {
            return !string.IsNullOrEmpty(value) ? Convert.ToDecimal(value) : 0;
        }

        public static int ConvertToInteger(string value)
        {
            return !string.IsNullOrEmpty(value) ? Convert.ToInt32(value) : 0;
        }
    }
}