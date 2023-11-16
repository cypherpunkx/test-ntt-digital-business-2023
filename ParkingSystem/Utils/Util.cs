using ParkingSystem.Models;

namespace ParkingSystem.Utils
{
    public class Util
    {
        public static readonly string Format = " {0}      {1}      {2}  {3}  {4}";
        public static readonly string Pattern = @"^[a-z]{1}-\d{4}-[a-z]{3}$";

        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static void DisplaySearchMenu()
        {
            Console.WriteLine("==== Find Vehicle In Parking Lot =====");
            Console.WriteLine("1. Find By License Plate");
            Console.WriteLine("2. Find By Odd License Plate");
            Console.WriteLine("3. Find By Even License Plate");
            Console.WriteLine("4. Find By Type");
            Console.WriteLine("5. Find By Color");
            Console.WriteLine("6. Exit");
            Console.Write("Choose Service : ");
        }

        public static void SearchByLicensePlate(List<Vehicle> filledSlots)
        {
            Console.WriteLine("Input License Plate (x-xxx-xxx) :");
            var licensePlate = Console.ReadLine();

            var foundVehicle = filledSlots.Find(car => car.LicensePlate == licensePlate);

            if (foundVehicle != null)
            {
                Console.WriteLine("Slot number is {0}", filledSlots.IndexOf(foundVehicle) + 1);
                Console.WriteLine("===== DETAIL VEHICLE =====");
                foundVehicle.DisplayInfo();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Vehicle not exists");
                Console.WriteLine();
            }
        }
        public static void SearchByOddLicensePlate(List<Vehicle> filledSlots)
        {
            var totalVehicle = filledSlots.FindAll(car => car.LicensePlate.Split("-")[1].Last() % 2 != 0);

            if (totalVehicle.Count > 0)
            {
                Console.WriteLine("===== LIST =====");
                foreach (var vehicle in totalVehicle)
                {
                    Console.WriteLine("{0}", vehicle.LicensePlate);
                }
                Console.WriteLine("Total vehicle in the parking lot is {0}", totalVehicle.Count);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Vehicle not exists");
                Console.WriteLine();
            }
        }
        public static void SearchByEvenLicensePlate(List<Vehicle> filledSlots)
        {
            var totalVehicle = filledSlots.FindAll(car => car.LicensePlate.Split("-")[1].Last() % 2 == 0);

            if (totalVehicle.Count > 0)
            {
                Console.WriteLine("===== LIST =====");
                foreach (var vehicle in totalVehicle)
                {
                    Console.WriteLine("{0}", vehicle.LicensePlate);
                }
                Console.WriteLine("Total vehicle in the parking lot is {0}", totalVehicle.Count);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Vehicle not exists");
                Console.WriteLine();
            }
        }
        public static void SearchByType(List<Vehicle> filledSlots)
        {
            var type = GetUserInput("Input Type :");

            var totalVehicle = filledSlots.FindAll(car => car.Type.ToLower() == type.ToLower());

            if (totalVehicle.Count > 0)
            {
                Console.WriteLine("Total vehicle in the parking lot is {0}", totalVehicle.Count);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Vehicle not exists");
                Console.WriteLine();
            }
        }
        public static void SearchByColor(List<Vehicle> filledSlots)
        {
            var color = GetUserInput("Input Color :");

            for (int i = 0; i < filledSlots.Count; i++)
            {
                if (filledSlots[i].Color.Equals(color, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("{0}", i + 1);
                }
            }
            Console.WriteLine();
        }
    }
}
