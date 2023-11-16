namespace ParkingSystem.Models
{
    public interface IVehicle
    {
        void DisplayInfo();
    }

    public class Vehicle(string type, string size, string color, string licensePlate) : IVehicle
    {
        public string Type = type;
        public string Size = size;
        public string Color = color;
        public string LicensePlate = licensePlate;

        public void DisplayInfo()
        {
            Console.WriteLine("Type: {0}", Type);
            Console.WriteLine("Size: {0}", Size);
            Console.WriteLine("Color: {0}", Color);
            Console.WriteLine("License Plate: {0}", LicensePlate);
            Console.WriteLine();
        }
    }
}