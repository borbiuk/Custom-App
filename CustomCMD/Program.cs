using System;
using System.Collections.Generic;
using System.Linq;
using CustomBL.Enums;
using CustomBL.Services;

namespace CustomCMD
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

                //Console.WriteLine("Choose your vehicle:");
                //Console.WriteLine("C - Car");
                //Console.WriteLine("T - Trucks");
                //Console.WriteLine("M - Motor Cycle");
                //Console.WriteLine("H - Hybrid");
                //Console.WriteLine("E - Electirc");
                //Console.WriteLine("Q - EXIT");

                //var key = Console.ReadKey();
                //switch (key.Key)
                //{
                //    case ConsoleKey.C:
                //        Console.WriteLine();
                //        Console.WriteLine("Enter the mark");
                //        var mark = Console.ReadLine();
                //        Console.WriteLine("Enter the model");
                //        var model = Console.ReadLine();
                //        var price = ParseInt("price");
                //        var year = ParseDateTime("year");
                //        var volume = ParseInt("volume");
                //        var typeEngine = ParseTypeEngine("engine type");
                //        var carController = new CarController(mark, model, price, year, volume, typeEngine);
                //        Console.WriteLine();
                //        Console.WriteLine($"Mark : {carController.Car.Mark}");
                //        Console.WriteLine($"Model : {carController.Car.Model}");
                //        Console.WriteLine($"Import duty : {carController.ImportDuty(price)} EUR");
                //        Console.WriteLine($"Excise tax : {carController.ExciseTax(volume, typeEngine)} EUR");
                //        Console.WriteLine($"VAT : {carController.MethodVAT(price)} EUR");
                //        Console.WriteLine($"End result : {carController.EndResult()} EUR");
                //        break;
                //
                //    case ConsoleKey.Q:
                //        Environment.Exit(0);
                //        break;
                //}
                //Console.ReadLine();
        //    }
        //
        //}

        // private static DateTime ParseDateTime(string value)
        // {
        //     DateTime year;
        //     while (true)
        //     {
        //         Console.Write($"Enter the {value} (dd.MM.yyyy): ");
        //         if (DateTime.TryParse(Console.ReadLine(), out year))
        //         {
        //             break;
        //         }
        //         else
        //         {
        //             Console.WriteLine($"Not the correct {value} format");
        //         }
        //     }
        //     return year;
        // }

        // private static int ParseInt(string name)
        // {
        //     while (true)
        //     {
        //         Console.Write($"Enter {name}: ");
        //         if (int.TryParse(Console.ReadLine(), out int value))
        //         {
        //             return value;
        //         }
        //         else
        //         {
        //             Console.WriteLine($"Not the correct {name} format");
        //         }
        //     }
        // }

        //private static int ParseTypeEngine(string name)
        //{
        //    while (true)
        //    {
        //        Console.Write($"Enter the {name}:\nselect 1 if your type - DIESEL \nselect 2 if your type - GAS\n");
        //        if (int.TryParse(Console.ReadLine(), out int value))
        //        {
        //            if (value > 2 || value <= 0)
        //            {
        //                Console.WriteLine($"Not the correct {name} format");
        //            }
        //            else
        //            {
        //                return value;
        //            }
        //        }
        //    }
        //}

        private static bool Process()
        {
            var command = Console.ReadKey().Key;
            if (CommandsNames.TryGetValue(command, out var commandName))
            {
                switch (command)
                {
                    case ConsoleKey.C:
                        //TODO: implement below
                        //Read params
                        //var result = CustomService.GetCarCustomValue(params);
                        //Console.WriteLine(result);
                        //TODO: later...
                        //AskToSave();
                        //DataService.SaveToJson(result, pathToFile, other params ...)
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
            Console.WriteLine("Hello");
            Console.WriteLine("Welcome to the customs calculator");
        }

        private static void SayBye()
        {
            Console.WriteLine("Bye, MOTHETFUCKER !");
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
    }
}
