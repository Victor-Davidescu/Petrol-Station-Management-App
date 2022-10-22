using System.Collections.Generic;
using System.Timers;
using System;

namespace MyAssignment
{   
    class Data
    {
        private static Random rnd1 = new Random();

        private static Timer timer;
        public static List<Vehicle> vehicles;
        public static List<Pump> pumps;
        public static List<Transaction> transactions;

        public static int spawnTime;

        //Initiliase the program
        public static void Initialise()
        {
            InitialisePumps();
            InitialiseVehicles();
            transactions = new List<Transaction>();
        }

        // Initialise Vehicles
        private static void InitialiseVehicles()
        {
            vehicles = new List<Vehicle>();

            // https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.71).aspx
            timer = new Timer();
            timer.Interval = RandomSpawnTime();
            timer.AutoReset = true;
            timer.Elapsed += CreateVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        //Random spawn time for new vehicles
        private static int RandomSpawnTime()
        {
            //New vehicles will be spawned between 1.5 and 2.2 seconds
            spawnTime = rnd1.Next(1500, 2200);
            return spawnTime;
        }

        //Creating a new vehicle
        private static void CreateVehicle(object sender, ElapsedEventArgs e)
        {
            timer.Interval = RandomSpawnTime();

            //Vehicles queue cannot reach more than 5
            if (vehicles.Count > 4)
            {
                return;
            }
            
            string vehicleTypeSelected;
            int tankCapacity=0;
            int waitTime = 0;
            float startupFuel = 0f;
            float fuelTime = 0f;
            int fuelTypeIndex = 0;
            float speed;

            //Creating a random type of vehicle
            int index1 = rnd1.Next(Config.vehicleList.Length);           
            vehicleTypeSelected = Config.vehicleList[index1]; 

            if (vehicleTypeSelected =="Car") //If the vehicle is a car
            {
                fuelTypeIndex = rnd1.Next(0, Config.fuelType.Length); //Fuel type = Unleaded, Diesel or LPG
                tankCapacity = rnd1.Next(10,40); //Creating random fuel tank capacity.
            }

            if(vehicleTypeSelected =="Van") // If the vehicle is a van
            {
                fuelTypeIndex = rnd1.Next(1, Config.fuelType.Length); //Fuel type = Diesel or LPG
                tankCapacity = rnd1.Next(41, 80); //Creating random fuel tank capacity.
            }

            if(vehicleTypeSelected =="HGV") // If the vehicle is an HGV
            {
                fuelTypeIndex = 1; //Fuel type = Diesel
                tankCapacity = rnd1.Next(81, 150); //Creating random fuel tank capacity.
            }

            waitTime = rnd1.Next(35000, 40000); //Creating a random wait time
            
            startupFuel = rnd1.Next(1, tankCapacity / 4); //Creating a random startup fuel that is less than a quarter from the tank capacity.

            speed = Config.fuelSpeed[fuelTypeIndex]; //Gets the fuel speed from the Config.cs

            fuelTime = (float)Math.Floor((tankCapacity - startupFuel) / speed); //Fuel time is base on tank capacity minus startup fuel, all divided by speed.

            //New vehicle created
            Vehicle v = new Vehicle(vehicleTypeSelected, fuelTypeIndex, tankCapacity, startupFuel, fuelTime * 1000, waitTime);
            vehicles.Add(v);
        }

        //Initiliase the nine pumps
        private static void InitialisePumps()
        {
            pumps = new List<Pump>();

            Pump p;

            for (int i = 0; i < 9; i++)
            {
                p = new Pump(i);
                pumps.Add(p);
            }
        }

        //Assign vehicle to pump
        public static void AssignVehicleToPump()
        {
            if (vehicles.Count == 0) { return; } // If there are no vehicles in queue

            Vehicle v;

            //Loop code for lane blocked system provided by the tutor Razvan
            int pumpsPerLane = 3;
            Pump prevPump = null, currPump;

            for (int i = 0; i < Math.Ceiling(pumps.Count / (float)pumpsPerLane); i++)
            {
                for (int j = 0; j < pumpsPerLane; j++)
                {
                    currPump = pumps[i * pumpsPerLane + j];
                    if (currPump.IsAvailable())
                    {
                        prevPump = currPump;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (prevPump == null) { return; } // No free pumps

            v = vehicles[0]; // Get first vehicle
            vehicles.RemoveAt(0); // Remove vehicle from queue
            prevPump.AssignVehicle(v); // Assign vehicle to the pump
        }
    }
}
