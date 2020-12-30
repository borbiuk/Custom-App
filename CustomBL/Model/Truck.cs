using System;

namespace Custom.BL.Model
{
    public class Truck
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Year { get; set; }
        public int EngineVolume { get; set; }
        public Enum FuelType { get; set; }
        public int FullMass { get; set; }
    }
}
