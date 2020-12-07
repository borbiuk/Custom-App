using System;
using System.Collections.Generic;
using System.Text;
using CustomBL.Model;

namespace CustomBL.Model
{
    [Serializable]
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public DateTime Year { get; set; }
        public int Volume { get; set; }
        public int TypeEngine { get; set; }
        public int Result { get; set; }

        public Car(string mark, 
                   string model, 
                   int price, 
                   DateTime year, 
                   int volume, 
                   int typeEngine)
        {
            if (string.IsNullOrWhiteSpace(mark))
            {
                throw new ArgumentNullException("Mark cannot be in this format", nameof(mark));
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("Model cannot be  in this format", nameof(model));
            }
            if (price <= 0)
            {
                throw new ArgumentException("Price cannot be null or minus", nameof(price));
            }
            if (year < DateTime.Parse("01.01.1900") || year > DateTime.Now)
            {
                throw new ArgumentNullException("Year cannot be this format", nameof(year));
            }
            if (volume <= 0)
            {
                throw new ArgumentNullException("Volume cannot be null or minus", nameof(volume));
            }
            if (typeEngine <= 0)
            {
                throw new ArgumentNullException ("Type engine cannot be this gormat, choose: diesel or gas", nameof(typeEngine));
            }
            Mark = mark;
            Model = model;
            Price = price;
            Year = year;
            Volume = volume;
            TypeEngine = typeEngine;
        }
        public override string ToString()
        {
            return $"{Price}";
        }
    }
}
