using System;
using ShipServiceApi.Helpers;

namespace ShipServiceApi.Models
{
    
    ///<sumary>
    /// Star Ship Model for the api
    ///</sumary>
    public class StarShipModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacter { get; set; }
        public decimal CreditCost { get; set; }
        public string Consumables { get; set; }
        public string MGLT { get; set; }
        public double ConsumablesDays => Consumables == null ? 0 :Consumables.DaysInDate();
        public int MGLTValue => int.TryParse(MGLT, out int result) ? result : 0;
        public double MGLTTimesConsumable => (MGLTValue * 24) * ConsumablesDays;
    }
}