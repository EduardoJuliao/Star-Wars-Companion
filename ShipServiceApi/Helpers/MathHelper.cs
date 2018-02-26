using System;

namespace ShipServiceApi.Helpers {
    public static class MathHelper {

        ///<sumary>
        /// Transform the api date into a set of how much days has in the given date
        ///</sumary>
        public static double DaysInDate (this string value) {
            var splited = value.ToLower ().Split (" ");
            int number;
            if (splited.Length == 0 || !int.TryParse (splited[0], out number))
                return 0;

            var date = new DateTime();
            switch (splited[1][0]) {
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