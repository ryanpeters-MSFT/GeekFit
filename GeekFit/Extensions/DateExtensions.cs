using System;

namespace GeekFit
{
    public static class DateExtensions
    {
        public static string FriendlyDate(this DateTime date)
        {
            var format = date.Year < DateTime.Now.Year
                ? "dddd, M/d/yy"
                : "dddd, M/d";

            return date.Date == DateTime.Now.Date
                ? "today"
                : date.Date == DateTime.Now.AddDays(-1).Date
                    ? "yesterday"
                    : date.ToString(format);
        }

        public static string FriendlyAge(this DateTime date)
        {
            var age = DateTime.Now.Date - date.Date;

            return date.Date == DateTime.Now.Date
                ? "today"
                : date.Date == DateTime.Now.AddDays(-1).Date
                    ? "yesterday"
                    : $"{age.Days} days ago";
        }
    }
}
