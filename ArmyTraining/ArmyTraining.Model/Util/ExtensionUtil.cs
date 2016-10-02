using System;

namespace ArmyTraining.Model.Util
{
    public static class ExtensionUtil
    {
        public static string ToDateString(this DateTime? nullableDate)
        {
            return nullableDate.HasValue ? nullableDate.Value.ToString("dd/MM/yyyy") : string.Empty;
        }

        public static DateTime? ToDateValue(this string dateString)
        {
            if (string.IsNullOrEmpty(dateString)) return null;
            DateTime? date = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);
            return date;
        }
    }
}
