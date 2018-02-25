using System;

namespace ConsoleCompanion.Helpers
{
    public static class ObjectExtensions
    {
        ///<summary>
        /// Print all properties from the given object
        ///</summary>
        public static void PrintObject<T>(this T obj){
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            foreach(var prop in obj.GetType()
            .GetProperties()){
                var value = prop.GetValue(obj, null);
                Console.WriteLine($"{prop.Name}: {value}");
            }

        } 
    }
}