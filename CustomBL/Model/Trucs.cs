using System;
using System.Collections.Generic;
using System.Text;
using CustomBL.Model;

namespace CustomBL.Model
{
    [Serializable]
    public class Trucs
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public DateTime Year { get; set; }
        public int Volume { get; set; }
        public string TypeEngine { get; set; }
        public int FullMass { get; set; }
        public int Result { get; set; }

        public Trucs(string mark,
                     string model, 
                     int price, 
                     DateTime year, 
                     int volume, 
                     string typeEngine, 
                     int fullMass)
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
                throw new ArgumentNullException("Price cannot be null or minus", nameof(price));
            }
            if (year < DateTime.Parse("01.01.1900") || year >= DateTime.Now)
            {
                throw new ArgumentNullException("Year cannot be this format", nameof(year));
            }
            if (volume <= 0)
            {
                throw new ArgumentNullException("Volume cannot be null or minus", nameof(volume));
            }
            if (string.IsNullOrWhiteSpace(typeEngine))
            {
                throw new ArgumentNullException("Type engine cannot be this gormat, choose: disel or gas", nameof(typeEngine));
            }
            if (fullMass <= 0)
            {
                throw new ArgumentNullException("Full mass cannot be null or minus", nameof(fullMass));
            }
            Mark = mark;
            Model = model;
            Price = price;
            Year = year;
            Volume = volume;
            TypeEngine = typeEngine;
            FullMass = fullMass;
        }

        public override string ToString()
        {
            return $"{Price}";
        }
    }
}
