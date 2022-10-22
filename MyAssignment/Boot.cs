//Boot class
using System;

namespace MyAssignment
{
    class Boot
    {

        public static void Booting()
        {
            Credits();
            Console.WriteLine();
            Console.WriteLine("<---BOOT MENU--->");
            Console.WriteLine("Level functionality of the program: HIGH");

            Console.WriteLine();
            CheckConfig();

            Console.WriteLine("All the transactions are stored inside a text file called transactions.txt, found in the program's directory.");
            Console.WriteLine("Attention! The program runs automatically for an unlimited time.");
            Console.WriteLine("To stop the program, the user must press any key.");
            Console.WriteLine();

            StartProgram();
        }
        //The program's author
        private static void Credits()
        {
            const string name = "Victor-Florian Davidescu";
            const int sid = 1705734;

            Console.WriteLine("Author: {0} | SID: {1}", name, sid);
        }

        //Checking the values from the Config.cs
        private static void CheckConfig()
        {
            Console.WriteLine("Reading Config.cs");
            Console.Write("Types of vehicle:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(" {0} ",Config.vehicleList[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Fuel type: {0} | Price per litre: {1} | Pump speed (litres/second): {2}", Config.fuelType[i], Config.fuelPrice[i], Config.fuelSpeed[i]);
            }
            Console.WriteLine();
        }

        //Starting the program
        private static void StartProgram()
        {
            Console.WriteLine("Please press any key to start the program.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Loading...");
        }
    }
}