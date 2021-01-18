using System;
using Custom.BL.Enums;

namespace Custom.BL.Services
{
    public class CustomCalculatorService : ICustomService
    {
        public int GetCarCustomValue(FuelType fuelType, int engineVolume, int price = default, DateTime year = default)
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
            var exciseValue = GetCarExciseValue(year, fuelType, engineVolume);
            var vat = GetVat(price, importDuty, exciseValue);
            var fullPayment = GetFullPayment(exciseValue, importDuty, vat);

            return fullPayment;
        }

        public int GetTruckCustomValue(int price, DateTime year, int engineVolume, int fullWeight)
        {
            var importDuty = GetImportDuty(price);
            var exciseValue = GetTruckExciseValue(year, fullWeight, engineVolume);
            var vat = GetVat(price, importDuty, exciseValue);
            var fullPayment = GetFullPayment(exciseValue, importDuty, vat);

            return fullPayment;
        }

        public int GetBikeCustomValue(int price, DateTime year, int engineVolume)
        {
            var importDuty = GetImportDuty(price);
            var exciseValue = GetBikeExciseValue(year, engineVolume);
            var vat = GetVat(price, importDuty, exciseValue);
            var fullPayment = GetFullPayment(exciseValue, importDuty, vat);

            return fullPayment;
        }

        public int GetBusCustomValue(int price, DateTime year, int engineVolume, FuelType fuelType)
        {
            var importDuty = GetImportDuty(price);
            var exciseValue = GetBusExciseValue(year, engineVolume, fuelType);
            var vat = GetVat(price, importDuty, exciseValue);
            var fullPayment = GetFullPayment(exciseValue, importDuty, vat);

            return fullPayment;
        }

        private static int GetImportDuty(int price) => price / 10;

        private static int GetVat(int price, int importDuty, int exciseValue) =>
            Convert.ToInt32((price + importDuty + exciseValue) * 0.2);

        private static int GetFullPayment(int exciseTax, int importDuty, int vat) =>
            Convert.ToInt32(exciseTax + importDuty + vat);

        /// <summary>
        /// Рахує кількість повних років
        /// </summary>
        /// <param name="year"> Рік транспортного засобу. </param>
        /// <returns></returns>
        private int GetCountOfFullYears(DateTime year)
        {
            var now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            var dob = int.Parse(year.ToString("yyyyMMdd"));
            return (now - dob) / 10000;
        }

        /// <summary>
        /// Рахує акциз для легкових автомобілів
        /// </summary>
        /// <param name="year"> Рік легкового автомобіля </param>
        /// <param name="fuelType"> Тип пального легкового автомобіля </param>
        /// <param name="engineVolume"> Потужність легкового автомобіля </param>
        /// <returns></returns>
        private int GetCarExciseValue(DateTime year, FuelType fuelType, int engineVolume)
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

        /// <summary>
        /// Рахує акциз для вантажних автомобілів
        /// </summary>
        /// <param name="year"> Рік вантажного автомобіля </param>
        /// <param name="fullWeight"> Повна масса вантажного автомобіля </param>
        /// <param name="engineVolume"> Потужність вантажного автомобіля </param>
        /// <returns></returns>
        private int GetTruckExciseValue(DateTime year, int fullWeight, int engineVolume)
        {
            var totalYearsCount = GetCountOfFullYears(year);

            double rate = default;

            if (fullWeight < 5000)
            {
                if (totalYearsCount < 5) rate = 0.02;
                else if (totalYearsCount > 5 && totalYearsCount < 8) rate = 0.8;
                else if (totalYearsCount > 8) rate = 1;
            }
            else if (fullWeight > 5000)
            {
                if (totalYearsCount < 5) rate = 0.026;
                else if (totalYearsCount > 5 && totalYearsCount < 8) rate = 1.04;
                else if (totalYearsCount > 8) rate = 1.3;
            }

            var res = rate * (engineVolume / 1000) * totalYearsCount;

            return (int) Math.Round(res, 0);
        }

        /// <summary>
        /// Рахує акциз для мото транспорту
        /// </summary>
        /// <param name="year"> Рік мото транспорту </param>
        /// <param name="engineVolume"> Потужність мото транспорту </param>
        /// <returns></returns>
        private int GetBikeExciseValue(DateTime year, int engineVolume)
        {
            var totalYearsCount = GetCountOfFullYears(year);

            double rate = default;

            if (engineVolume < 500) rate = 0.062;
            else if (engineVolume > 500 && engineVolume < 800) rate = 0.443;
            else if (engineVolume > 800) rate = 0.447;

            var res = rate * (engineVolume / 1000) * totalYearsCount;

            return (int) Math.Round(res, 0);
<<<<<<< HEAD
        }

        /// <summary>
        /// Рахує акциз для автобусів
        /// </summary>
        /// <param name="year"> Рік автобуса </param>
        /// <param name="engineVolume"> Потужність автобуса </param>
        /// <param name="fuelType"> Тип пального автобуса </param>
        /// <returns></returns>
        private int GetBusExciseValue(DateTime year, int engineVolume, FuelType fuelType)
        {
            var totalYearsCount = GetCountOfFullYears(year);

            double rate = default;

            if (fuelType == FuelType.Gas)
            {
                if (totalYearsCount < 8) rate = 0.007;          
                else if (totalYearsCount > 8) rate = 0.35;
            }
            else if (fuelType == FuelType.Diesel)
            {
                if (totalYearsCount < 8)
                {
                    if (engineVolume < 2500 && engineVolume > 5000) rate = 0.007;
                    else if (engineVolume > 2500 && engineVolume < 5000) rate = 0.003;
                }
                else if (totalYearsCount > 8)
                {
                    if (engineVolume < 2500 && engineVolume > 5000) rate = 0.35;
                    else if (engineVolume > 2500 && engineVolume < 5000) rate = 0.15;
                }                              
            }

            var res = rate * (engineVolume / 1000) * totalYearsCount;

            return (int)Math.Round(res, 0);
=======
>>>>>>> 2d1ed3daede7b247a50cd4fe9c4f6130307b9ec5
        }
    }
}
