using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleCompanion.Helpers {
    public static class CSVHelper {
        public static string ToCsv<T> (this IEnumerable<T> objectlist, string separator = ";") {
            Type t = typeof (T);
            PropertyInfo[] fields = t.GetProperties ();

            string header = String.Join (separator, fields.Select (f => f.Name).ToArray ());

            StringBuilder csvdata = new StringBuilder ();
            csvdata.AppendLine (header);

            foreach (var o in objectlist)
                csvdata.AppendLine (ToCsvFields (separator, fields, o));

            return csvdata.ToString ();
        }

        public static string ToCsvFields (string separator, PropertyInfo[] fields, object o) {
            StringBuilder linie = new StringBuilder ();

            foreach (var f in fields) {
                if (linie.Length > 0)
                    linie.Append (separator);

                var x = f.GetValue (o);

                if (x != null)
                    linie.Append (x.ToString ());
            }

            return linie.ToString ();
        }
    }
}