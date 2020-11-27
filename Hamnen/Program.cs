using System;

namespace Hamnen

{
    class Program
    {
        static Boat[] Dock = new Boat[26];
        static int rejectedBoats = 0;
        static void Main(string[] args)
        {
            int day = 0;

            while (true)
            {
                day++;

                for (int i = 0; i < 5; i++)
                {
                    var newBoat = CreateBoat();
                    AssignBerth(newBoat);
                }

                Console.WriteLine("Dag: " + day);
                Console.WriteLine("Avvisade båtar: " + rejectedBoats);

                PrintTable();

                Console.ReadKey();
                Console.Clear();

                Dock = RemoveDays(Dock);
                Dock = RemoveBoats(Dock);
            }
        }

        static Boat CreateBoat()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 4);

            switch (randomNum)
            {
                case 1:
                    MotorBoat motorBoat = new MotorBoat();
                    return motorBoat;
                case 2:
                    SailingBoat SailingBoat = new SailingBoat();
                    return SailingBoat;
                case 3:
                    CargoShip cargoShip = new CargoShip();
                    return cargoShip;
                default:
                    return null;
            }
        }

        static void AssignBerth(Boat boat)
        {
            bool assigned = false;
            switch (boat.BoatType)
            {
                case "Motorbåt":
                    for (int i = 0; i < Dock.Length; i++)
                    {
                        if (Dock[i] == null)
                        {
                            Dock[i] = boat;
                            assigned = true;
                            break;
                        }
                    }
                    break;
                case "Segelbåt":
                    for (int i = 0; i < Dock.Length; i++)
                    {
                        if (i != 25)
                        {
                            if (Dock[i] == null && Dock[i + 1] == null)
                            {
                                Dock[i] = boat;
                                Dock[i + 1] = boat;
                                assigned = true;
                                break;
                            }
                        }
                    }
                    break;
                case "Lastfartyg":
                    for (int i = 0; i < Dock.Length; i++)
                    {
                        if (i < 23)
                        {
                            if (Dock[i] == null && Dock[i + 1] == null && Dock[i + 2] == null && Dock[i + 3] == null)
                            {
                                Dock[i] = boat;
                                Dock[i + 1] = boat;
                                Dock[i + 2] = boat;
                                Dock[i + 3] = boat;
                                assigned = true;
                                break;
                            }
                        }
                    }
                    break;

            }
            if (assigned != true)
            {
                rejectedBoats++;
            }
        }
        static Boat[] RemoveDays(Boat[] Dock)
        {
            for (int i = 0; i < Dock.Length; i++)
            {
                if (Dock[i] != null)
                {
                    Dock[i].DaysAtPier--;
                    if (Dock[i].BoatType == "Segelbåt") { i++; }
                    if (Dock[i].BoatType == "Lastfartyg") { i += 3; }
                }
            }
            return Dock;
        }

        static Boat[] RemoveBoats(Boat[] Dock)
        {
            for (int i = 0; i < Dock.Length; i++)
            {
                if (Dock[i] != null)
                {
                    if (Dock[i].DaysAtPier == 0)
                    {
                        Dock[i] = null;
                    }
                }
            }
            return Dock;
        }
        static void PrintTable()
        {
            int emptySpots = 0;
            Console.WriteLine("KAJPLATS \tBÅTTYP \tID-NUMMER\n");

            for (int i = 1; i < 26; i++)
            {
                string spot = i.ToString();
                if (Dock[i] != null)
                {
                    if (Dock[i].BoatType == "Lastfartyg") { spot = i.ToString() + "-" + (i + 3).ToString(); i += 3; }
                    else if (Dock[i].BoatType == "Segelbåt") { spot = i.ToString() + "-" + (i + 1).ToString(); i++; }
                }

                Console.Write(spot + "\t\t");
                if (Dock[i] != null)
                {
                    Console.Write(Dock[i].BoatType);
                    Console.WriteLine("\t" + Dock[i].BoatId);
                }
                else
                {
                    Console.WriteLine();
                    emptySpots++;
                }
            }
            Console.WriteLine("\nAntal tomma platser: " + emptySpots);

        }
    }
}
