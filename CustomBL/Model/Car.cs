using System;

namespace Custom.BL.Model
{
    public class Car
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Year { get; set; }
        public int EngineVolume { get; set; }
        public Enum FuelType { get; set; }
    }
}
