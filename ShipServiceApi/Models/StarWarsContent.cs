namespace ShipServiceApi.Models
{
    ///<sumary>
    /// Encapsulates the swapi list result
    ///</sumary>
    public class StarWarsContent<T>
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public T Results { get; set; }
    }
}