using ParkingSystem.Services;
using ParkingSystem.Utils;

namespace ParkingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingService parkingService = new(5);

            while (true)
            {
                Console.WriteLine("==== Parking System NTT Digital Business =====");
                Console.WriteLine("1. Check parking availability");
                Console.WriteLine("2. Search parking lot");
                Console.WriteLine("3. Enter the parking lot");
                Console.WriteLine("4. Exit the parking lot");
                Console.WriteLine("5. Exit program");

                var choice = Util.GetUserInput("Choose Service : ");

                switch (choice)
                {
                    case "1":
                        parkingService.CheckAvailability();
                        break;
                    case "2":
                        parkingService.FindVehicle();
                        break;
                    case "3":
                        parkingService.ParkVehicle();
                        break;
                    case "4":
                        parkingService.ExitVehicle();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Service not exists");
                        break;
                }
            }
        }
    }
}
