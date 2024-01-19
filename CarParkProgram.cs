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

        public  Dictionary<int, string> InitializeCarPark(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity should be greater than 0.");

            carPark.Clear(); // 

            for (int i = 0; i < capacity; i++)
            {
                carPark.Add(i, null);
                //Console.WriteLine("Stall number : {0} license number : {1}", i, carPark[i]);
            }
            return carPark;

        }

        public string LicenseNumber()
        {
            Console.Write("Enter your license number : ");
            return Console.ReadLine();
        }

        public bool isLicenseValid(string license)
        { 
            // regex for license
            string licenseRegex = @"^[A-Z0-9]{3}-[A-Z0-9]{3}$";
            return Regex.IsMatch(license, licenseRegex);
        }

        public int AddVehicle(string license)
        {
            try
            {
                if (!isLicenseValid(license))
                    throw new ArgumentException("Invalid License number. Please enter a valid License number");

                foreach(int stallNumber in carPark.Keys)
                {
                    if (carPark[stallNumber] == null)
                    {
                        carPark[stallNumber] = license;
                        return stallNumber;
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

        public bool VacantStall(int stallNumber)
        {
            try
            {
                if (!carPark.ContainsKey(stallNumber) || carPark[stallNumber] == null)
                    throw new InvalidOperationException("Stall doesn't exist");

                carPark[stallNumber] = null;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error vacating stall: {ex.Message}");
                return false;
            }
        }

        public bool LeaveParkade(string licenseNumber)
        {
            try
            {
                if (!isLicenseValid(licenseNumber))
                    throw new ArgumentException("Invalid license number");

                foreach(var kv in carPark)
                {
                    if (kv.Value == licenseNumber)
                    {
                        carPark[kv.Key] = null;
                        return true;
                    }
                }
                throw new InvalidOperationException("License number not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
                return false;
            }
        }

        public string Manifest()
        {
            try
            {
                string manifest = "";

                foreach (var kv in carPark)
                {
                    string stallInfo = $"Stall number : {kv.Key}";
                    string licenseInfo = kv.Value != null ? $"license number: {kv.Value}" : "Unoccupied";
                    manifest += stallInfo + licenseInfo;
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
