using System;
using System.Linq;

namespace Hamnen
{
    public class Boat
    {
        public string BoatId = idNumber();
        public string BoatType { get; set; }
        public int Weight { get; set; }
        public int Speed { get; set; }
        public int NoOfBerths { get; set; }
        public int DaysAtPier { get; set; }

        public static Random random = new Random();
        public static string idNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
    public class MotorBoat : Boat
    {
        public int HorsePower = random.Next(10, 1001);
        public MotorBoat()
        {
            BoatId = "M-" + BoatId;
            BoatType = "Motorbåt";
            Weight = random.Next(200, 3000);
            Speed = random.Next(0, 60);
            HorsePower = random.Next(10, 1000);
            NoOfBerths = 1;
            DaysAtPier = 3;
        }
    }
    public class SailingBoat : Boat
    {
        public int BoatLength = random.Next(0, 61);
        public SailingBoat()
        {
            BoatId = "S-" + BoatId;
            BoatType = "Segelbåt";
            Weight = random.Next(800, 6000);
            Speed = random.Next(0, 12);
            BoatLength = random.Next(10, 60);
            NoOfBerths = 2;
            DaysAtPier = 4;
        }
    }
    public class CargoShip : Boat
    {
        public int Containers = random.Next(0, 501);
        public CargoShip()
        {
            BoatId = "L-" + BoatId;
            BoatType = "Lastfartyg";
            Weight = random.Next(3000, 20000);
            Speed = random.Next(0, 20);
            Containers = random.Next(0, 500);
            NoOfBerths = 4;
            DaysAtPier = 6;
        }
    }

}
