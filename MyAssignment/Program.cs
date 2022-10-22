//Introduction to programming - Software Assignment
//Level of functionality: High
//Author: Victor-Florian Davidescu
//SID: 1705734

using System;
using System.Timers;

namespace MyAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Boot.Booting(); // Display the necessary information about the program before it's starting.
            Data.Initialise(); // Initialise the data

            Timer timer = new Timer();
            timer.Interval = 2050;
            timer.AutoReset = true; // repeat every 2 seconds
            timer.Elapsed += RunProgramLoop;
            timer.Enabled = true;
            timer.Start();

            Console.ReadKey(); //To close the program, the user must press a key.
        }

        static void RunProgramLoop(object sender, ElapsedEventArgs e)
        {
            Data.AssignVehicleToPump(); //Assign vehicle to a free pump
            Console.Clear(); //Clear the console
            Display.DrawStats(); //Display counters 1-5
            Display.DrawTransactions(); //Display counter 6
            Console.WriteLine(); // Space line
            Display.DrawVehicles(); //Display vehicles in the queue
            Console.WriteLine(); // Space line
            Display.DrawPumps(); // Display pumps arranged in three lanes
        }
    }
}