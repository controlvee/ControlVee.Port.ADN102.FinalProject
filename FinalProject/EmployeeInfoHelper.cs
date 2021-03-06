﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime;

namespace FinalProject
{
    public class EmployeeInfoHelper
    {
        int emptySlotIndex;
        Employee[] employees = new Employee[10];
        private bool HasRecords { get; set; }

        public EmployeeInfoHelper()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Employee();
            }
        }

        public void DisplayMenu()
        {
            Console.Write(
                $"{"(A)dd", -10}" +
                $"{"(Li)st Paycheck High to Low", -30}" +
                $"{"(L)ist Normal", -15}" +
                $"{"(E)xit", -10}");
        }

        public bool GetMenuOption()
        {
            bool wantsMenu = true;

            switch (Console.ReadLine().ToUpper())
            {
                case "A":
                    AddEmployee();
                    break;
                case "L":
                    ListEmployees(false);
                    break;
                case "E":
                    ExitConsole();
                    break;
                case "LI":
                    ListEmployees(true);
                    break;
                default:
                    break;
            }

            Console.Clear();
            return wantsMenu;
        }

        private void ExitConsole()
        {
            Environment.Exit(0);
        }

        public void AddEmployee()
        {
            // Check if there are already 10 employess in the system.
            if (emptySlotIndex >= 10)
            {
                Console.WriteLine("Program holds 10 users maximum - please (E)xit and restart.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Please enter Employee Identificaiton Number (EIN): ");
            string ein = Console.ReadLine();
            Console.WriteLine("Please enter hours worked: ");
            string hrsWorked = Console.ReadLine();
            Console.WriteLine("Please enter state (ex. TX) where employee worked: ");
            string state = Console.ReadLine();

            Console.WriteLine($"Is EIN: {ein}, Hours Worked: {hrsWorked}, State: {state} correct? Y/N");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                // If empty slot is more than 0 then we want to check for dups.  If its 
                // not then we need to check the employee number for length anyways.
                if (!CheckEINForLengthAndDups(ein))
                    return;

                // Get number of employees to use to index.
                var hasEmployees = employees.All(e => e.EmployeeIdNumber > 0);

                // If there are no entries then add to first.
                bool foundEmpty = false;
                while (!foundEmpty)
                {
                    for (int i = 0; i < employees.Length; i++)
                    {
                        try
                        {
                            employees[emptySlotIndex] = new Employee(state, Int32.Parse(hrsWorked));
                            employees[emptySlotIndex].EmployeeIdNumber = UInt64.Parse(ein);
                        }
                        catch(Exception e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }

                        hasEmployees = true;
                        foundEmpty = true;

                        // Push next employee to next slot.
                        emptySlotIndex++;

                        break;
                    }

                    HasRecords = true;
                }
            }
            HasRecords = true;
        }

        private bool CheckEINForLengthAndDups(string ein)
        {
            bool isGoodLength = true;
            
            // Check for length.
            if (ein.Length > 9)
            {
                isGoodLength = false;
                Console.WriteLine("EIN must be 9 characters or less in length.");
                Console.ReadKey();
            }

            // Don't compare if first one in array.
            if (emptySlotIndex > 0)
            {
                // Check for dups.
                if (employees.Any(x => x.EmployeeIdNumber.ToString() == ein))
                {
                    isGoodLength = false;
                    Console.WriteLine($"Employee with EIN: {ein} already exists.");
                    Console.ReadKey();
                }
            }
       
            return isGoodLength;
        }

        private void ListEmployees(bool descendingList)
        {
            if (!HasRecords)
            {
                Console.Clear();

                Console.WriteLine("\r\nNo employee records.\r\n\r\n" +
                                    "\r\nIf you would like to (A)dd please return to the main menu.\r\n");
            }
            else
            {
                if (descendingList)
                {
                    employees = employees.OrderByDescending(e => e.Paycheck).ToArray();
                }
                else
                {
                    employees = employees.OrderByDescending(e => e.State).ToArray();
                }

                Console.WriteLine($"\r\n");
                Console.WriteLine($"{"EIN:",-25}{"State:",-25}{"State Tax:",-25}{"Hrs Worked:",-25}{"Paycheck:",-25}\r\n");
                
                for (int i = 0; i < employees.Length; i++)
                {
                    Console.WriteLine($"\r\n{i}) {employees[i].EmployeeIdNumber, - 25}" +
                                                    $" {employees[i].State, -25} " +
                                                    $" {employees[i].StateTax, -25:p} " +
                                                    $"{employees[i].HoursWorked, -25} " +
                                                    $"{employees[i].Paycheck, -25:n} ");
                }
            }

            Console.ReadKey();
        }
    }
}
