//Display class
using System;
namespace MyAssignment
{
    public class Display
    {
        //Showing stats
        public static void DrawStats()
        {
            Console.WriteLine("Stats:");

            Console.WriteLine("Total number of litres dispensed: {0}", Stats.TotalLitres.ToString("#0.00"));
            Console.WriteLine("Total ammount of money: {0}", Stats.TotalMoney.ToString("#0.00"));
            Console.WriteLine("Total commission: {0}", Stats.Commission.ToString("#0.00"));
            Console.WriteLine("Total number of vehicles serviced: {0}", Stats.VehiclesServiced);
            Console.WriteLine("Total number of vehicles left before service: {0}", Stats.VehiclesUnserviced);
            Console.WriteLine("");
        }

        //Showing vehicles
        public static void DrawVehicles()
        {
            Vehicle v;

            Console.WriteLine("Vehicles Queue:");

            for (int i = 0; i < Data.vehicles.Count; i++)
            {
                v = Data.vehicles[i];

                Console.WriteLine("#{0} {1} {2}",v.carID,v.vehicleType,Config.fuelType[v.fuelType]);
            }
        }

        //Showing transactions
        public static void DrawTransactions()
        {
            Transaction t;
            Console.WriteLine("Latest Transactions: ");

            int i = 0;
            if (Data.transactions.Count > 5) {
                i = Data.transactions.Count - 5;
            }

            for ( ; i < Data.transactions.Count; i++)
            {
                t = Data.transactions[i];
                Console.WriteLine("Vehicle type:" + t.vehicleType + " | Number of litres:" + t.numberOfLitres.ToString("#0.00") + " | Pump number:" + (t.pumpNumber+1));
            }
        }

        //Showing pumos
        public static void DrawPumps()
        {

            Pump p;

            Console.WriteLine("Pumps Status:");

            for (int i = 0; i < 9; i++)
            {
                p = Data.pumps[i];

                Console.Write("#{0} ", i + 1);
                if (p.IsAvailable())
                {
                    Console.Write("FREE");
                }
                else
                {
                    Console.Write("BUSY");
                }
                Console.Write(" | ");

                // modulus -> remainder of a division operation
                // 0 % 3 => 0 (0 / 3 = 0 R=0)
                // 1 % 3 => 1 (1 / 3 = 0 R=1)
                // 2 % 3 => 2 (2 / 3 = 0 R=2)
                // 3 % 3 => 0 (3 / 3 = 1 R=0)
                // 4 % 3 => 1 (4 / 3 = 1 R=1)
                // 5 % 3 => 2 (5 / 3 = 1 R=2)
                // 6 % 3 => 0 (6 / 3 = 2 R=0)
                // ...
                if (i % 3 == 2) { Console.WriteLine(); }
            }
        }
    }
}