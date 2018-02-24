namespace ConsoleCompanion.Models
{
    public class StarShipModel
    {
         public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacter { get; set; }
        public decimal CreditCost { get; set; }
        public string Consumables { get; set; }
        public double ConsumablesDays { get; set; }
        public string MGLT { get; set; }
        public int MGLTValue { get; set; }
        public double MGLTTimesConsumable {get;set;}
    }
}