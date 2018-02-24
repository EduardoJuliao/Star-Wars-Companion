using System;

namespace ShipServiceApi.Helpers
{
    public static class MathHelper
    {
        public static double DaysInDate(this string value)
        {
            var splited = value.ToLower().Split(" ");
            int number;
            if (splited.Length == 0 || !int.TryParse(splited[0], out number))
                return 0;

            DateTime date = new DateTime();
            switch (splited[1][0])
            {
                case 'd':
                    date = date.AddDays(number);
                    break;
                case 'w':
                    date = date.AddDays(number * 7);
                    break;
                case 'm':
                    date = date.AddMonths(number);
                    break;
                case 'y':
                    date = date.AddYears(number);
                    break;
            }

            return date.Subtract(new DateTime()).TotalDays;
        }
    }
}