using System;
using System.Collections.Generic;
using System.Linq;
using Custom.BL.Enums;
using Custom.BL.Services;

namespace Custom.Cmd
{
    class Program
    {
        private static readonly Dictionary<ConsoleKey, string> CommandsNames = new Dictionary<ConsoleKey, string>
        {
            {ConsoleKey.C, "Car"},
            {ConsoleKey.T, "Truck"},
            {ConsoleKey.B, "Bike"},
            {ConsoleKey.Q, "Exit"},
        };

        /// <summary>
        /// Instance of <see cref="ICustomService"/>
        /// </summary>
        private static ICustomService _customService;

        /// <summary>
        /// Service that calculate custom of cars.
        /// </summary>
        public static ICustomService CustomService => _customService ??= new CustomCalculatorService();

        static void Main()
        {
            SayHello();
            while (true)
            {
                ShowCommands();
                var continueProcess = Process();
                if (!continueProcess)
                {
                    break;
                }
            }
            SayBye();
        }

        private static bool Process()
        {
            var command = Console.ReadKey().Key;
            if (CommandsNames.TryGetValue(command, out var commandName))
            {
                switch (command)
                {
                    case ConsoleKey.C:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter the fuel type: ");  // 0-Diesel, 1-Gas, 2-Electric
                        ShowFuelTypes();
                        Enum.TryParse(Console.ReadLine(), out FuelType fuelType);  

                        if (fuelType == FuelType.Electric)  // TODO: ConselKey для  FuelType?
                        {                                   
                            var carEnginePower = ParseInt("engine power in KW");
                            var electricCarResult = CustomService.GetCarCustomValue(fuelType, carEnginePower);
                            Console.WriteLine($"Full payment : {electricCarResult} EUR.");
                        }
                        else
                        {
                            var carPrice = ParsePrice("price");
                            var carYear = ParseDateTime("year");
                            var carEngineVolume = ParseInt("engine volume in cubic centimeters");

                            var carResult = CustomService.GetCarCustomValue(fuelType, carEngineVolume, carPrice, carYear);
                            Console.WriteLine($"Full payment : {carResult} EUR.");
                        }

                        //TODO: later...
                        //AskToSave();
                        //DataService.SaveToJson(result, pathToFile, other params ...)
                        break;

                    case ConsoleKey.T:
                        var truckPrice = ParsePrice("price");
                        var truckYear = ParseDateTime("year");
                        var truckEngineVolume = ParseInt("engine volume in cubic centimeters");
                        var truckFullWeight = ParseInt("full weight in kilograms");

                        var truckResult = CustomService.GetTruckCustomValue(truckPrice, truckYear, truckEngineVolume, truckFullWeight);
                        Console.WriteLine($"Full payment : {truckResult} EUR.");

                        break;

                    case ConsoleKey.B:
                        var bikePrice = ParsePrice("price");
                        var bikeYear = ParseDateTime("year");
                        var bikeEngineVolume = ParseInt("engine volume in cubic centimeters");

                        var bikeResult = CustomService.GetBikeCustomValue(bikePrice, bikeYear, bikeEngineVolume);
                        Console.WriteLine($"Full payment : {bikeResult} EUR.");

                        break;

                    case ConsoleKey.Q:
                        return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid key.");
            }
            return true;
        }

        private static void SayHello()
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Welcome to the customs calculator.");
        }

        private static void SayBye()
        {
            Console.WriteLine();
            Console.WriteLine("Bye!");
        }

        private static void ShowCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Choose your vehicle:");
            foreach (var key in CommandsNames.Keys)
            {
                Console.WriteLine($"{key} - {CommandsNames[key]}");
            }
        }

        private static void ShowFuelTypes()
        {
            var fuelTypes = Enum.GetValues(typeof(FuelType)).Cast<FuelType>();
            foreach (var fuelType in fuelTypes)
            {
                var fuelTypeNameFirstLetter = fuelType.ToString()[0];
                var key = char.ToUpper(fuelTypeNameFirstLetter);

                Console.WriteLine($"{key} - {fuelType}");
            }
        }

        private static int ParsePrice(string name)
        {
            int value;
            while (true)
            {
                Console.WriteLine($"Enter the {name} in EUR: ");
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value > 99 && value < 15_000_000)
                        break;                     
                    else
                        Console.WriteLine($"Not the correct {name} format");
                }
            }
            return value;
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime year;
            while (true)
            {
                Console.Write($"Enter the {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out year))
                {
                    if (year > DateTime.Parse("01.01.1900") && year < DateTime.Now)
                        break;
                    else
                        Console.WriteLine($"Not the correct {value} format");
                }
            }
            return year;
        }

        private static int ParseInt(string name)
        {
            while (true)
            {
                Console.Write($"Enter the {name} : ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Not the correct {name} format");
                }
            }
        }
    }
}
