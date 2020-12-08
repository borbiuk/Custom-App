using System;
using CustomBL.Enums;

namespace CustomBL.Services
{
    public interface ICustomService
    {
        double GetCarCustomValue(double price, DateTime year, int engineVolume, FuelType fuelType);
        double GetTruckCustomValue(double price, DateTime year, int engineVolume, int fullWeight, FuelType fuelType);
        double GetBikeCustomValue(double price, DateTime year, int engineVolume);
    }
}
