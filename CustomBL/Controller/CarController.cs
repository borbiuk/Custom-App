using CustomBL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomBL.Controller
{
    public class CarController : DatabaseDataSaver
    {
        public Car Car { get; set; }
        public CarController(string mark, string model, int price, DateTime year, int volume, int typeEngine)
        {
            if (string.IsNullOrWhiteSpace(mark))
            {
                throw new ArgumentNullException("Mark engine cannot be this gormat, choose: disel or gas", nameof(mark));
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("Model engine cannot be this gormat, choose: disel or gas", nameof(model));
            }
            if (price <= 0)
            {
                throw new ArgumentNullException("Price cannot be empty or null.", nameof(price));
            }
            if (year < DateTime.Parse("01.01.1900") || year > DateTime.Now)
            {
                throw new ArgumentNullException("Year cannot be empty or null.", nameof(year));
            }
            if (volume <= 0)
            {
                throw new ArgumentNullException("Volume cannot be empty or null.", nameof(volume));
            }
            if (typeEngine<=0)
            {                
                throw new ArgumentNullException("Type engine cannot be empty or null.", nameof(typeEngine));
            }            
            Car = new Car(mark, model, price, year, volume, typeEngine);

            ImportDuty(price);
            ExciseTax(volume,typeEngine);
            MethodVAT(price);
            EndResult();
            
            Car.Result = endResult;
           
            Save();             
        }
        private void Save()
        {
            Save(Car);
        }

        private int importDuty;     // Ввізне мито 
        private double exciseTax;   // Акцизний податок        
        private int variableVAT;    // ПДВ
        private int rate;           // Ставка
        private int endResult;      // Кінцевий резульат        
        public int ImportDuty(int price)                             // Мито
        {
            return importDuty = (price * 10) / 100;
        }
        public double ExciseTax(double volume, int typeEngine)       // Акциз          
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));  // формула із stackoverflow
            int dob = int.Parse(Car.Year.ToString("yyyyMMdd"));      // яка розраховує к-сть повних років
            int fullYears = (now - dob) / 10000;

            int d = 1;
            int g = 2;
            if (typeEngine == d)                        
            {              
                rate = volume < 3000 ? 50 : 100;
                exciseTax = rate * (volume / 1000) * fullYears;
                if (fullYears > 15)
                {
                    exciseTax = rate * (volume / 1000) * 15;
                }
            }
            else if (typeEngine == g)
            {               
                rate = volume < 3500 ? 75 : 150;
                exciseTax = rate * (volume / 1000) * fullYears;
                if (fullYears > 15)
                {
                    exciseTax = rate * (volume / 1000) * 15;
                }
            }
            return Math.Round(exciseTax,0);
        }
        public int MethodVAT(int price)                            // ПДВ
        {
           return variableVAT = Convert.ToInt32((price + importDuty + exciseTax) * 0.2);
        }
        public int EndResult()                                     // Кінцевий результат
        {
           return endResult = Convert.ToInt32(exciseTax + importDuty + variableVAT);           
        }
    }
}
