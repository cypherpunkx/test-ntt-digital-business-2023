using System.Text.RegularExpressions;
using ParkingSystem.Models;
using ParkingSystem.Utils;

namespace ParkingSystem.Services
{
    public interface IService
    {
        void CheckAvailability();
        void FindVehicle();
        void ParkVehicle();
        void ExitVehicle();
    }

    public class ParkingService : IService
    {
        readonly private int TotalSlots;
        readonly private List<Vehicle> FilledSlots;

        public ParkingService(int totalSlots)
        {
            TotalSlots = totalSlots;
            FilledSlots = [];
            Console.WriteLine("Created a parking lot with {0} slots", TotalSlots);
            Console.WriteLine();
        }

        public void CheckAvailability()
        {
            int availableSlot = TotalSlots - FilledSlots.Count;

            if (FilledSlots.Count > 0)
            {
                Console.WriteLine("===== Parking List =====");
                Console.WriteLine("Slot | License Plate | Type | Size | Color");
                foreach (var vehicle in FilledSlots)
                {
                    var slot = FilledSlots.IndexOf(vehicle) + 1;
                    Console.WriteLine(Util.Format, slot, vehicle.LicensePlate, vehicle.Type, vehicle.Size, vehicle.Color);
                }
                Console.WriteLine("Slot availability : {0}", availableSlot);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Not one has parked yet");
                Console.WriteLine();
            }
        }
        public void FindVehicle()
        {
            Util.DisplaySearchMenu();

            var choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    Util.SearchByLicensePlate(FilledSlots);
                    break;
                case "2":
                    Util.SearchByOddLicensePlate(FilledSlots);
                    break;
                case "3":
                    Util.SearchByEvenLicensePlate(FilledSlots);
                    break;
                case "4":
                    Util.SearchByType(FilledSlots);
                    break;
                case "5":
                    Util.SearchByColor(FilledSlots);
                    break;
                case "6":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Service doesn't exists");
                    break;
            }
        }

        public void ParkVehicle()
        {
            Regex regex = new(Util.Pattern);

            if (FilledSlots.Count < TotalSlots)
            {
                var licensePlate = Util.GetUserInput("Input License Plate (x-xxx-xxx) : ");

                if (regex.IsMatch(licensePlate))
                {
                    var type = Util.GetUserInput("Input Type (car,motor): ").ToLower();

                    if (type != "car" && type != "motor")
                    {
                        Console.WriteLine("Please input only car or motor");
                        Console.WriteLine("");
                        return;
                    }

                    var size = Util.GetUserInput("Input Size (small,big) : ").ToLower();

                    if (size != "small" && size != "motor")
                    {
                        Console.WriteLine("Please input only small or big");
                        Console.WriteLine("");
                        return;
                    }

                    var color = Util.GetUserInput("Input Color (red,blue .etc) : ").ToLower();

                    Vehicle vehicle = new(type, size, color, licensePlate);

                    FilledSlots.Add(vehicle);

                    var slotVehicle = FilledSlots.IndexOf(vehicle) + 1;

                    Console.WriteLine("Vehicle with licensed plate {0} has been parked", licensePlate);
                    Console.WriteLine("Allocated slot number {0}", slotVehicle);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Please input valid license plate");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Sorry, parking lot is full");
                Console.WriteLine();
            }

        }

        public void ExitVehicle()
        {
            var licensePlate = Util.GetUserInput("Input License Plate (x-xxx-xxx) : ");

            Vehicle foundVehicle = FilledSlots.FirstOrDefault(vehicle => vehicle.LicensePlate.ToLower() == licensePlate.ToLower());

            if (foundVehicle != null)
            {
                var slot = FilledSlots.IndexOf(foundVehicle) + 1;

                FilledSlots.Remove(foundVehicle);

                Console.WriteLine("Vehicle with licensed plate {0} has been exit.", licensePlate);
                Console.WriteLine("Slot number {0} is free", slot);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Vehicle with licensed plate {0} not exists in the parking lot", licensePlate);
                Console.WriteLine();
            }
        }
    }
}