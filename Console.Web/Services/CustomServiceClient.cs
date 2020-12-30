using Custom.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Console.Web.Services
{
    public class CustomServiceClient : ICustomServieceCleint
    {
        private readonly Dictionary<FuelType, string> FuelTypesTitels;
        public CustomServiceClient()
        {
            FuelTypesTitels = new Dictionary<FuelType, string>();
        }
    }
}
