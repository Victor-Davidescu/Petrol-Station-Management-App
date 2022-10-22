// Config class contains the vehicle types, fuel types, fuel speed and fuel price
// All the important data to make calculations during the program were put here to be easy accessible.
using System;

namespace MyAssignment
{
    // Enum code provided by the tutor Razvan
    enum FUEL_TYPE
    {
        Unleaded,
        Diesel,
        LPG
    }
    class Config
    {
        public static string[] vehicleList = { "Car", "Van", "HGV" };
        public static string[] fuelType = { "Unleaded", "Diesel", "LPG" };
        public static float[] fuelSpeed = { 1.5f, 1.7f, 2.0f };
        public static float[] fuelPrice = { 1.20f, 1.30f, 0.8f };
    }
}
