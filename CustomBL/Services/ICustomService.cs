using System;
using Custom.BL.Enums;

namespace Custom.BL.Services
{
    public interface ICustomService
    {
        int GetCarCustomValue(FuelType fuelType, int engineVolume, int price = default, DateTime year = default);
        int GetTruckCustomValue(int price, DateTime year, int engineVolume, int fullWeight);
        int GetBikeCustomValue(int price, DateTime year, int engineVolume);
<<<<<<< HEAD
        int GetBusCustomValue(int price, DateTime year, int engineVolume, FuelType fuelType);
=======
>>>>>>> 2d1ed3daede7b247a50cd4fe9c4f6130307b9ec5
    }
}
