using System;

namespace Console.Web.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Year { get; set; }
        public int EngineVolume { get; set; }
        public Enum FuelType { get; set; }
    }
}
