using System;
using System.Collections.Generic;
using System.Text;
using CustomBL.Model;

namespace CustomBL.Model
{
    [Serializable]
    public class Truck
    {
        public int Id { get; set; }      
        public int Price { get; set; }
        public DateTime Year { get; set; }
        public int EngineVolume { get; set; }
        public Enum FuelType { get; set; }
        public int FullMass { get; set; }
        public int Result { get; set; }
      
        public override string ToString()
        {
            return $"{Price}";
        }
    }
}
