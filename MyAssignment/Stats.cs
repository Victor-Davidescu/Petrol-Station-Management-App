// This class contains all the data related to the stats: total litres dispensed, total money, commission, vehicles serviced and unserviced
// Data is set to be private to increase security and they can be accessed using methods
using System;

namespace MyAssignment
{
    class Stats
    {
        // Private variables
        private static float commission;
        private static float totalLitres;
        private static float totalMoney;
        private static int vehiclesUnserviced = 0;
        private static int vehiclesServiced = 0;

        // Public methods to access the private variables
        public static float Commission
        {
            get { return commission; } set { commission = value; }
        }
        public static float TotalLitres
        {
            get { return totalLitres; } set { totalLitres = value; }
        }
        public static float TotalMoney
        {
            get { return totalMoney; } set { totalMoney = value; }
        }
        public static int VehiclesUnserviced
        {
            get { return vehiclesUnserviced; } set { vehiclesUnserviced = value; }
        }
        public static int VehiclesServiced
        {
            get { return vehiclesServiced; } set { vehiclesServiced = value; }
        }

    }
}
