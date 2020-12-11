using System;
using CustomBL.Enums;

namespace CustomBL.Services
{
    public interface ICustomService
    {
        double GetCarCustomValue(int price, DateTime year, int engineVolume, FuelType fuelType);
        double GetTruckCustomValue(int price, DateTime year, int engineVolume, int fullWeight);
        double GetBikeCustomValue(int price, DateTime year, int engineVolume);
    }
}
