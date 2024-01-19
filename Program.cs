using Lab_04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Car Park!");
            CarParkProgram carParkObj = new CarParkProgram();

            //// Initialising the capacity of car park
            //carParkObj.InitializeCarPark(5);

            //// get the license number
            //string license = carParkObj.LicenseNumber();
            
            //// Add the vehicle to the car park
            //int stallNumber = carParkObj.AddVehicle(license);

            while (true)
            {
                Console.WriteLine("\n1. Add vehicle \n2. Vacant Stall \n3. Leave Parkade \n4. Display Manifest \n5. Exit");
                Console.Write("Enter your choice : ");
                int userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.Write("Enter the license number of your vehicle : ");
                        string license = Console.ReadLine();
                        try
                        {
                            int stallNumber = carParkObj.AddVehicle(license);
                            if (stallNumber != -1)
                            {
                                Console.WriteLine("Vehicle parked successfully in stall {0}", stallNumber);
                            }
                            else
                            {
                                Console.WriteLine("Sorry, no unoccupied stall availabe");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
