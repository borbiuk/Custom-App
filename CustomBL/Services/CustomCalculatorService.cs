using System;
using CustomBL.Enums;
using CustomBL.Model;

namespace CustomBL.Services
{
    public class CustomCalculatorService : ICustomService
    {
        private int importDuty;     // Ввізне мито 
        private double exciseTax;   // Акцизний податок        
        private int _Vat;           // ПДВ
        private double rate;        // Ставка
        private int fullYears;      // Повні роки
        private int fullPayments;   // Кінцевий резульат 
        
        public double GetCarCustomValue(int price, DateTime year, int engineVolume, FuelType fuelType)
        {
            ImportDuty(price);
            CarExciseTax(year, fuelType, engineVolume);
            Vat(price);
            FullPayment();
            return fullPayments;
        }

        public double GetCarCustomValue(int engineVolume, FuelType fuelType)
        {
            if (fuelType == FuelType.Electric)
            {
                engineVolume = fullPayments;
            }
            return fullPayments;
        }

        public double GetTruckCustomValue(int price, DateTime year, int engineVolume, int fullWeight)
        {
            ImportDuty(price);
            TruckExciseTax(year, fullWeight, engineVolume) ;
            Vat(price);
            FullPayment();
            return fullPayments;
        }

        public double GetBikeCustomValue(int price, DateTime year, int engineVolume)
        {
            ImportDuty(price);
            BikeExciseTax(year, engineVolume);
            Vat(price);
            FullPayment();
            return fullPayments;
        }

        private int ImportDuty(int price)                                // Мито
        {
            return importDuty = (price * 10) / 100;
        }

        private int Vat(int price)                                       // ПДВ
        {
            return _Vat = Convert.ToInt32((price + importDuty + exciseTax) * 0.2);
        }

        private int FullPayment()                                        // Кінцевий результат
        {
            return fullPayments = Convert.ToInt32(exciseTax + importDuty + _Vat);
        }

        private int CountFullYears(DateTime year)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));     
            int dob = int.Parse(year.ToString("yyyyMMdd"));                     
            fullYears = (now - dob) / 10000;
            return fullYears;
        }

        private double CarExciseTax(DateTime year, FuelType fuelType, double engineVolume)       // Акциз для Car          
        {
            CountFullYears(year);

            if (fuelType == FuelType.Diesel )
            {
                rate = engineVolume < 3000 ? 50 : 100;
                if(fullYears > 15)
                    exciseTax = rate * (engineVolume / 1000) * 15;
                else
                    exciseTax = rate * (engineVolume / 1000) * fullYears;                           
            }
            else if (fuelType == FuelType.Gas)
            {
                rate = engineVolume < 3500 ? 75 : 150;
                if (fullYears > 15)
                    exciseTax = rate * (engineVolume / 1000) * 15;
                else
                    exciseTax = rate * (engineVolume / 1000) * fullYears;
            }
            return Math.Round(exciseTax, 0);
        }

        private double TruckExciseTax(DateTime year, int fullWeight, int engineVolume)
        {
            CountFullYears(year);

            if (fullWeight < 5000)
            {
                if(fullYears < 5)
                    rate = 0.02;
                else if (fullYears > 5 && fullYears < 8)
                    rate = 0.8;
                else if (fullYears > 8)
                    rate = 1;

                exciseTax = rate * (engineVolume / 1000) * fullYears;
            }
            else if (fullWeight > 5000)
            {
                if (fullYears < 5)
                    rate = 0.026;
                else if (fullYears > 5 && fullYears < 8)
                    rate = 1.04;
                else if (fullYears > 8)
                    rate = 1.3;

                exciseTax = rate * (engineVolume / 1000) * fullYears;
            }
            return Math.Round(exciseTax, 0);
        }

        private double BikeExciseTax(DateTime year, int engineVolume)
        {
            CountFullYears(year);

            if (engineVolume < 500)
                rate = 0.062;
            else if (engineVolume > 500 && engineVolume < 800)
                rate = 0.443;
            else if (engineVolume > 800)
                rate = 0.447;

            exciseTax = rate * (engineVolume / 1000) * fullYears;

            return Math.Round(exciseTax, 0);
        }
    }
}
