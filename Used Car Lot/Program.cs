using System;
using System.Collections.Generic;

namespace Used_Car_Lot
{
    class CarLot
    {
        public List<Car> Cars;
        public CarLot()
        {
            Cars = new List<Car>();
        }
        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
        public void PrintCars()
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                Car car = Cars[i];
                Console.WriteLine($"{(i + 1) + ".", -5}" + car.ToString());
            }
        }
        public void RemoveCar(int index)
        {
            Cars.RemoveAt(index);
        }
    }
    class Car
    {
        public string Make;
        public string Model;
        public int Year;
        public decimal Price;
        public Car()
        {
            Make = "";
            Model = "";
            Year = 0;
            Price = 0m;
        }

        public Car(string Make, string Model, int Year, decimal Price)
        {
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Price = Price;
        }

        public override string ToString()
        {
            return $"{Make,-20}{Model,-20}{Year,-8}{Price,12}";
        }
    }
    
    class UsedCar : Car
    {
        double Milage;

        public UsedCar(string Make, string Model, int Year, decimal Price, double Milage) : base(Make, Model, Year, Price)
        {
            this.Milage = Milage;
        }

        public override string ToString()
        {
            return $"{Make,-20}{Model,-20}{Year,-8}{Price,12}{Milage,12}";
        }
    }
    class Program
    {
        static void PrintOptions(List<string> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{(i + 1) + ".",-2}{options[i]}");
            }
        }
        static void Main(string[] args)
        {
            bool run = true;

            List<string> entryOptions = new List<string>() { "Buy Car", "Add Car" };
            List<string> addOptions = new List<string>() { "New Car", "Used Car" };

            CarLot lot = new CarLot();
            lot.Cars.Add(new Car("Honda", "Civic", 2022, 21900.00m));
            lot.Cars.Add(new Car("Ford", "F-150", 2022, 29640.00m));
            lot.Cars.Add(new Car("BMW", "i8", 2020, 147500.00m));
            lot.Cars.Add(new UsedCar("Honda", "Accord", 2012, 11990.00m, 30204.1));
            lot.Cars.Add(new UsedCar("Ford", "Crown Victoria", 2007, 12310.00m, 54095.9));
            lot.Cars.Add(new UsedCar("BMW", "6 Series", 2017, 22995.00m, 57108.7));

            while (run)
            {
                Console.WriteLine("Here's our inventory!\n");

                Console.WriteLine($"     {"Make",-20}{"Model",-20}{"Year",-8}{"Price",12}{"Milage",12}\n");

                lot.PrintCars();

                Console.WriteLine("");
                PrintOptions(entryOptions);
                Console.WriteLine("");

                Console.Write("Please select an option above: ");

                int userChoice = 0;
                bool validInput = false;
                do
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out userChoice) && userChoice > 0 && userChoice <= entryOptions.Count)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.Write("Please select an option above: ");
                    }
                } while (!validInput);

                Console.Clear();

                if (userChoice == 1)
                {
                    lot.PrintCars();

                    Console.WriteLine("");

                    Console.Write("Which car would you like to buy? ");

                    validInput = false;
                    do
                    {
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out userChoice) && userChoice > 0 && userChoice <= lot.Cars.Count)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.Write("Which car would you like to buy? ");
                        }
                    } while (!validInput);

                    Car purchased = lot.Cars[userChoice - 1];

                    Console.WriteLine($"You purchased the {purchased.Year} {purchased.Make} {purchased.Model} for ${purchased.Price}!");

                    lot.Cars.RemoveAt(userChoice - 1);
                }
                else
                {
                    string make;
                    string model;
                    int year;
                    decimal price;

                    PrintOptions(addOptions);

                    Console.WriteLine("");

                    validInput = false;
                    do
                    {
                        Console.Write("\nWould you like to add a new or used car? ");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out userChoice) && userChoice > 0 && userChoice <= addOptions.Count)
                        {
                            validInput = true;
                        }
                    } while (!validInput);

                    Console.Write("What is the make of your car? ");
                    make = Console.ReadLine();

                    Console.Write("What is the model of your car? ");
                    model = Console.ReadLine();

                    validInput = false;
                    do
                    {
                        Console.Write("What is the year of your car? ");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out year) && year > 0)
                        {
                            validInput = true;
                        }
                    } while (!validInput);

                    validInput = false;
                    do
                    {
                        Console.Write("What is the price of your car? ");
                        string input = Console.ReadLine();
                        if (decimal.TryParse(input, out price) && price > 0)
                        {
                            validInput = true;
                        }
                    } while (!validInput);

                    if (userChoice == 1)
                    {
                        lot.Cars.Add(new Car(make, model, year, price));
                    }
                    else
                    {
                        double milage;

                        validInput = false;
                        do
                        {
                            Console.Write("What is the milage of your car? ");
                            string input = Console.ReadLine();
                            if (double.TryParse(input, out milage) && milage > 0)
                            {
                                validInput = true;
                            }
                        } while (!validInput);

                        lot.Cars.Add(new UsedCar(make, model, year, price, milage));
                    }
                }

                validInput = false;
                do
                {
                    Console.Write("Would you like to see our inventory again? (y/n) ");
                    string input = Console.ReadLine();
                    if (input == "y")
                    {
                        validInput = true;
                    }
                    else if (input == "n")
                    {
                        validInput = true;
                        run = false;
                    }
                } while (!validInput);

                Console.Clear();
            }
        }
    }
}
