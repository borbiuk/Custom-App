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
                        var price = ParsePrice("price");
                        var year = ParseDateTime("year");
                        var engineVolume = ParseEngineVolume("engine volume");

                        Console.WriteLine("Enter the fuel type: ");
                        ShowFuelTypes();

                        if (Enum.TryParse(Console.ReadLine(), out FuelType fuelType))
                        {
                            var result = CustomService.GetCarCustomValue(engineVolume, fuelType, price, year);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            
                        }

                        //TODO: later...
                        //AskToSave();
                        //DataService.SaveToJson(result, pathToFile, other params ...)
                        break;

                    case ConsoleKey.T:

                        break;
                    case ConsoleKey.B:
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
            Console.WriteLine("Bye!");
        }

        private static void ShowCommands()
        {
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
            while (true)
            {
                Console.WriteLine();
                Console.Write($"Enter the {name} in EUR: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    if (value < 99 && value > 15000000)
                        Console.WriteLine($"Not the correct {name} format");
                    else
                        return value;
                }
            }
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

        private static int ParseEngineVolume(string name)
        {
            while (true)
            {
                Console.Write($"Enter the {name} in cubic centimeter: ");
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
