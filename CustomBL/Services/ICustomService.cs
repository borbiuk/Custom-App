using System;
using Custom.BL.Enums;

namespace Custom.BL.Services
{
    public interface ICustomService
    {
        double GetCarCustomValue(int engineVolume, FuelType fuelType, int price = default, DateTime year = default);
        double GetTruckCustomValue(int price, DateTime year, int engineVolume, int fullWeight);
        double GetBikeCustomValue(int price, DateTime year, int engineVolume);
    }
}
