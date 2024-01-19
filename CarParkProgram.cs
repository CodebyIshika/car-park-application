using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_04
{
    internal class CarParkProgram
    {
        Dictionary<int, string> carPark = new Dictionary<int, string>();

        /// <summary>
        /// This method creates a dictionary representing a car park with a specified capacity
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public  Dictionary<int, string> InitializeCarPark(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity should be greater than 0.");

            carPark.Clear();

            for (int i = 1; i <= capacity; i++)
            {
                carPark.Add(i, null);
            }
            return carPark;
        }


        /// <summary>
        /// Checking the validity of user license number
        /// </summary>
        /// <param name="license"></param>
        /// <returns></returns>
        public bool isLicenseValid(string license)
        { 
            // regex for license
            string licenseRegex = @"^[A-Z0-9]{3}-[A-Z0-9]{3}$";
            return Regex.IsMatch(license, licenseRegex);
        }


        /// <summary>
        /// This method adds the vehicle to the first unoccupied stall, reserves it by 
        /// assigning the license and returns the stall number
        /// </summary>
        /// <param name="license"></param>
        /// <returns></returns>
        public int AddVehicle(string license)
        {
            try
            {
                // checking validity of license
                if (!isLicenseValid(license))
                    throw new ArgumentException("Invalid License number. Please enter a valid License number");

                // check if stall is unoccupied
                for (int i = 1; i <= carPark.Count;i++)
                {
                    if (carPark[i] == null)
                    {
                        carPark[i] = license;
                        return i;
                    }
                }

                throw new InvalidOperationException("No unoccupied stalls available.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in adding vehicle : {ex.Message}");
                return -1;
            }
        }


        /// <summary>
        /// This method attempts to vacate a specified parking stall and 
        /// also check if the stall exists or not
        /// </summary>
        /// <param name="stallNumber"></param>
        /// <returns></returns>
        public bool VacateStall(int stallNumber)
        {
            try
            {
                // check if stall number exists
                if (!carPark.ContainsKey(stallNumber))
                    throw new InvalidOperationException("Stall doesn't exist");

                // check if stall number is occupied or not
                if (carPark[stallNumber] == null)
                {
                    Console.WriteLine($"Stall {stallNumber} is already unoccupied.");
                    return false;
                }

                carPark[stallNumber] = null;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error vacating stall: {ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// This method attempts to remove a vehicle with a specified license 
        /// number from the parking.
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        public bool LeaveParkade(string licenseNumber)
        {
            try
            {
                // check validity of license number
                if (!isLicenseValid(licenseNumber))
                    throw new ArgumentException("Invalid license number");

                // remove the vehicle
                foreach(var kv in carPark)
                {
                    // check if current stall has vehicle of provided license number
                    if (kv.Value == licenseNumber)
                    {
                        // set value to null to remove the vehicle
                        carPark[kv.Key] = null;
                        return true;
                    }
                }
                throw new InvalidOperationException("License number not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// This method return the list of all parking stall and parking vehicles
        /// </summary>
        /// <returns></returns>
        public string Manifest()
        {
            try
            {
                string manifest = "";

                foreach (var kv in carPark)
                {
                    string stallInfo = $"Stall number : {kv.Key}";

                    // Create a string with license information or indicate unoccupied status.
                    string licenseInfo = kv.Value != null ? $"license number: {kv.Value}" : "Unoccupied";

                    string spaces = new string(' ', 3);
                    manifest += stallInfo + spaces + licenseInfo + "\n";
                }

                return manifest;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating manifest: {ex.Message}");
                return "";
            }
        }
    }
}
