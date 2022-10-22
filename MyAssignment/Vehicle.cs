//Vehicle class
using System;
using System.Timers;

namespace MyAssignment
{
    class Vehicle
    {
        public string vehicleType;
        public int fuelType;
        public float fuelTime;

        private int tankCapacity;
        private float startupFuel;
        private int waitTime;

        public static int nextCarID = 0;
        public int carID;

        //Vehicle
        public Vehicle(string vtp, int ftp, int tkc, float spf, float ftm, int wt)
        {
            vehicleType = vtp; //vehicle type
            fuelType = ftp; //fuel type
            tankCapacity = tkc; //tank capacity
            startupFuel = spf; // startup fuel
            fuelTime = ftm; // fuel time
            waitTime = wt; // wait time

            carID = nextCarID++; //new car ID for newly created vehicles

            StartWaitTimer(); //start wait timer for new vehicles
        }

        // Wait time for the vehicles waiting in the queue
        private void StartWaitTimer()
        {
            Timer timer = new Timer();
            timer.Interval = waitTime;
            timer.AutoReset = false;
            timer.Elapsed += RemoveFromQueue;
            timer.Enabled = true;
            timer.Start();
        }

        //Remove vehicle from the queue
        private void RemoveFromQueue(object sender, ElapsedEventArgs args)
        {
            Data.vehicles.Remove(this);
            Stats.VehiclesUnserviced++;
        }
    }
}