using System;
using System.Collections.Generic;
using System.Text;
using CustomBL.Model;

namespace CustomBL.Model
{
    [Serializable]
    public class Hybrid
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int Result { get; set; }

        public Hybrid(string mark,
                      string model, 
                      int price)
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
            Mark = mark;
            Model = model;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Price}";
        }
    }
}
