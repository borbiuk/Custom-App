using CustomBL.Controller;
using CustomBL.Model;
using System;


namespace CustomCMD
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Welcome to the customs calculator");

            while (true)
            {
                Console.WriteLine("Choose your vehicle:");
                Console.WriteLine("C - Car");
                Console.WriteLine("T - Trucks");
                Console.WriteLine("M - Motor Cycle");
                Console.WriteLine("H - Hybrid");
                Console.WriteLine("E - Electirc");
                Console.WriteLine("Q - EXIT");

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.C:
                        Console.WriteLine();
                        Console.WriteLine("Enter the mark");
                        var mark = Console.ReadLine();
                        Console.WriteLine("Enter the model");
                        var model = Console.ReadLine();
                        var price = ParseInt("price");
                        var year = ParseDateTime("year");
                        var volume = ParseInt("volume");
                        var typeEngine = ParseTypeEngine("engine type");
                        var carController = new CarController(mark, model, price, year, volume, typeEngine);
                        Console.WriteLine();
                        Console.WriteLine($"Mark : {carController.Car.Mark}");
                        Console.WriteLine($"Model : {carController.Car.Model}");
                        Console.WriteLine($"Import duty : {carController.ImportDuty(price)} EUR");
                        Console.WriteLine($"Excise tax : {carController.ExciseTax(volume, typeEngine)} EUR");
                        Console.WriteLine($"VAT : {carController.MethodVAT(price)} EUR");
                        Console.WriteLine($"End result : {carController.EndResult()} EUR");
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
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
                    break;
                }
                else
                {
                    Console.WriteLine($"Not the correct {value} format");
                }
            }
            return year;
        }
        private static int ParseInt(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
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
        private static int ParseTypeEngine(string name)
        {
            while (true)
            {
                Console.Write($"Enter the {name}:\nselect 1 if your type - DIESEL \nselect 2 if your type - GAS\n");                
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    if (value > 2 || value <= 0) 
                    {
                        Console.WriteLine($"Not the correct {name} format");
                    }   
                    else
                    {
                        return value;
                    }
                }                
            }
        }
    }
}
