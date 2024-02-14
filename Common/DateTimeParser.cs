using System;

namespace HRMS.Common
{
    public static class DateTimeParser
    {
        public static DateTime ParseDateTime(string date)
        {
            DateTime dateTime;
            if (DateTime.TryParse(date, out dateTime))
            {
                return dateTime;
            }
            return dateTime;
        }

        public static string ConvertDateTimeToText(Microsoft.OData.Edm.Date? date)
        {
            if (date.HasValue)
            {
                if (date.Value.ToString().Contains("0001-01-01"))
                    return "";
                var convertedDateTime = Convert.ToDateTime(date.Value);
                return convertedDateTime.ToString("yyyy'-'MM'-'dd");
            }
            return string.Empty;
        }

        public static string ConvertDateTimeMMDDYYYY(Microsoft.OData.Edm.Date? date)
        {
            if (date.HasValue)
            {
                var convertedDateTime = Convert.ToDateTime(date.Value);

              //  DateTime date1 = DateTime.ParseExact(date.ToString(), "dd/MM/yyyy", null);

                return convertedDateTime.ToString("M'/'d'/'yyyy");
            }
            return string.Empty;
        }

        public static string GetCurrentAcademicYear()
        {
            DateTime yearFrom = DateTime.UtcNow;
            DateTime yearTo = yearFrom.AddYears(1).AddDays(-1);

           return yearFrom.Year.ToString() + yearTo.ToString("'-'yy");
        }
    }
}