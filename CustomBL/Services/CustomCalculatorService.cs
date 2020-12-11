using System;
using Custom.BL.Enums;

namespace Custom.BL.Services
{
    public class CustomCalculatorService : ICustomService
    {
        public double GetCarCustomValue(int engineVolume, FuelType fuelType, int price = default, DateTime year = default)
        {
            if (fuelType == FuelType.Electric)
            {
                return engineVolume;
            }

            if (price == default || year == default)
            {
                throw new ArgumentException(
                    "Price and Year are mandatory parameters for not Electric cars Custom calculating");
            }

            var importDuty = GetImportDuty(price);
            var exciseValue = CarExciseValue(year, fuelType, engineVolume);
            var vat = GetVat(price, importDuty, exciseValue);
            var fullPayment = GetFullPayment(exciseValue, importDuty, vat);

            return fullPayment;
        }

        public double GetTruckCustomValue(int price, DateTime year, int engineVolume, int fullWeight)
        {
            throw new NotImplementedException();
        }

        public double GetBikeCustomValue(int price, DateTime year, int engineVolume)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Мито
        /// </summary>
        private static int GetImportDuty(int price) => price / 10;

        /// <summary>
        /// ПДВ
        /// </summary>
        private static int GetVat(int price, int importDuty, int exciseValue) =>
            Convert.ToInt32((price + importDuty + exciseValue) * 0.2);

        /// <summary>
        /// Кінцевий результат
        /// </summary>
        private static int GetFullPayment(int exciseTax, int importDuty, int vat) => Convert.ToInt32(exciseTax + importDuty + vat);

        private int GetCountOfFullYears(DateTime year)
        {
            var now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            var dob = int.Parse(year.ToString("yyyyMMdd"));
            return (now - dob) / 10000;
        }

        private int CarExciseValue(DateTime year, FuelType fuelType, int engineVolume)
        {
            var totalYearsCount = GetCountOfFullYears(year);

            var rate = fuelType switch
            {
                FuelType.Diesel => engineVolume < 3000 ? 50 : 100,
                FuelType.Gas => engineVolume < 3500 ? 75 : 150,
                _ => throw new ArgumentException("Invalid Fuel Type for Rate calculating")
            };

            rate = totalYearsCount > 15
                ? rate * 15
                : rate * totalYearsCount;

            var res = rate * engineVolume / 1000.0;

            return (int) Math.Round(res, 0);
        }

        //private double TruckExciseTax(DateTime year, int fullWeight, int engineVolume)
        //{
        //    GetCountOfFullYears(year);
        //
        //    if (fullWeight < 5000)
        //    {
        //        if (fullYears < 5)
        //            rate = 0.02;
        //        else if (fullYears > 5 && fullYears < 8)
        //            rate = 0.8;
        //        else if (fullYears > 8)
        //            rate = 1;
        //
        //        exciseTax = rate * (engineVolume / 1000) * fullYears;
        //    }
        //    else if (fullWeight > 5000)
        //    {
        //        if (fullYears < 5)
        //            rate = 0.026;
        //        else if (fullYears > 5 && fullYears < 8)
        //            rate = 1.04;
        //        else if (fullYears > 8)
        //            rate = 1.3;
        //
        //        exciseTax = rate * (engineVolume / 1000) * fullYears;
        //    }
        //    return Math.Round(exciseTax, 0);
        //}
        //
        //private double BikeExciseTax(DateTime year, int engineVolume)
        //{
        //    GetCountOfFullYears(year);
        //
        //    if (engineVolume < 500)
        //        rate = 0.062;
        //    else if (engineVolume > 500 && engineVolume < 800)
        //        rate = 0.443;
        //    else if (engineVolume > 800)
        //        rate = 0.447;
        //
        //    exciseTax = rate * (engineVolume / 1000) * fullYears;
        //
        //    return Math.Round(exciseTax, 0);
        //}
    }
}
