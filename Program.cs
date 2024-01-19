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

            // Initialising the capacity of car park
            carParkObj.InitializeCarPark(10);


            while (true)
            {
                Console.WriteLine("\n1. Add vehicle \n2. Vacant Stall \n3. Leave Parkade \n4. Display Manifest");
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
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error : {ex.Message}");
                        }
                        break;

                     case 2:
                        Console.Write("Enter the stall number to vacate : ");
                        int stallToVacate = Convert.ToInt32(Console.ReadLine());

                        bool vacated = carParkObj.VacateStall(stallToVacate);
                        if (vacated)
                        {
                            Console.WriteLine($"Stall {stallToVacate} vacated successfully.");
                        }
                        break;

                    case 3:
                        Console.Write("Enter the license number to leave the parkade : ");
                        string licenseNumber = Console.ReadLine();

                        bool leftParkade = carParkObj.LeaveParkade(licenseNumber);
                        if (leftParkade)
                            Console.WriteLine("Vehicle left the parkade successfully.");
                        break;

                     case 4:
                        Console.WriteLine(carParkObj.Manifest());
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter again.");
                        break;

                }
            }

            Console.ReadKey();
        }
    }
}
