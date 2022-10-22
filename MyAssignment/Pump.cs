//Pump class
using System;
using System.Timers;

namespace MyAssignment
{
    class Pump
    {
        public Vehicle currentVehicle = null;
        public int number;

        public Pump(int n)
        {
            number = n;
        }

        //Check pump's availability
        public bool IsAvailable()
        {
            // returns TRUE if currentVehicle is NULL, meaning available
            // returns FALSE if currentVehicle is NOT NULL, meaning busy
            return currentVehicle == null;
        }

        public void AssignVehicle(Vehicle v)
        {
            currentVehicle = v;

            Timer timer = new Timer();
            timer.Interval = v.fuelTime;
            timer.AutoReset = false; // don't repeat
            timer.Elapsed += ReleaseVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        private void ReleaseVehicle(object sender, ElapsedEventArgs e)
        {
            //Add 1 to total vehicles serviced 
            Stats.VehiclesServiced++;

            // record transaction
            Transaction t = new Transaction(currentVehicle.vehicleType, (float)(currentVehicle.fuelTime / 1000 / Config.fuelSpeed[currentVehicle.fuelType]), number);
            Data.transactions.Add(t);

            Stats.TotalLitres = Stats.TotalLitres + (currentVehicle.fuelTime / 1000 / Config.fuelSpeed[currentVehicle.fuelType]);

            Stats.TotalMoney = Stats.TotalMoney + (currentVehicle.fuelTime / 1000 / Config.fuelSpeed[currentVehicle.fuelType] * Config.fuelPrice[currentVehicle.fuelType]);

            Stats.Commission = (float)Stats.TotalMoney * 0.01f;

            currentVehicle = null;            
        }
    }
}