using System;
using CustomBL.Enums;

namespace CustomBL.Services
{
    public class CustomCalculatorService : ICustomService
    {
        public double GetCarCustomValue(double price, DateTime year, int engineVolume, FuelType fuelType)
        {
            //throw new NotImplementedException();
            return 1;
        }

        public double GetTruckCustomValue(double price, DateTime year, int engineVolume, int fullWeight, FuelType fuelType)
        {
            throw new NotImplementedException();
        }

        public double GetBikeCustomValue(double price, DateTime year, int engineVolume)
        {
            throw new NotImplementedException();
        }
    }
}
