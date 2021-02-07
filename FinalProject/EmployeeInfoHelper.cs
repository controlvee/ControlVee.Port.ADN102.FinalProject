using System;
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
                "(A)dd\t" +
                "(Li)st Taxes Descending\t" +
                "(L)ist Normal\t" +
                "(S)earch\t" +
                "(E)xit\t");
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
                    ListEmployees();
                    break;
                case "E":
                    ExitConsole();
                    break;
                case "LI":
                    ListEmployeesByAmountAndTaxes();
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
            if (emptySlotIndex > 9)
            {
                Console.WriteLine("Program holds 10 users maximum - please return to main menu to (D)elete.");
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
                CheckEINForLengthAndDups(ein);

                // Get number of employees to use to index.
                var hasEmployees = employees.All(e => e.EmployeeIdNumber > 0);

                // If there are no entries then add to first.
                bool foundEmpty = false;
                while (!foundEmpty)
                {
                    for (int i = 0; i < employees.Length; i++)
                    {
                        employees[emptySlotIndex] = new Employee();
                        employees[emptySlotIndex].EmployeeIdNumber = UInt64.Parse(ein);
                        employees[emptySlotIndex].HoursWorked = Int32.Parse(hrsWorked);
                        employees[emptySlotIndex].State = state;
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
            // Check for dups.
            bool isGoodLength = true;
            if (ein.Length > 9)
            {
                Console.WriteLine("EIN must be 9 characters or less in length.");
                Console.ReadKey();
            }
            //if(Check for dups.)
            //{ 
            //}

            return isGoodLength;
        }

        private void ListEmployees()
        {
            if (!HasRecords)
            {
                Console.Clear();

                Console.WriteLine("\r\nNo employee records.\r\n\r\n" +
                                    "\r\nIf you would like to (A)dd please return to the main menu.\r\n");

                
            }
            else
            {
                // Add header.
                Console.WriteLine($"{"EIN:", -25}{"State Tax:",-25}{"Hrs Worked:",-25}{"Paycheck:",-25}");
                for (int i = 0; i < employees.Length; i++)
                {
                    Console.WriteLine($"{i}) {employees[i].EmployeeIdNumber, - 25} {employees[i].HoursWorked, -25} {employees[i].Paycheck, -25} {employees[i].StateTax, -25} ");
                }
               
            }

            Console.ReadKey();
        }
        private void ListEmployeesByAmountAndTaxes()
        {
            if (!HasRecords)
            {
                Console.Clear();

                Console.WriteLine("\r\nNo employee records.\r\n\r\n" +
                                    "\r\nIf you would like to (A)dd please return to the main menu.\r\n");
            }
            else
            {
                employees.OrderByDescending(e => e.Paycheck);

                // Add Header somehow.
                for (int i = 0; i < employees.Length; i++)
                {
                    Console.WriteLine($"{i}) {employees[i].EmployeeIdNumber} {employees[i].HoursWorked} {employees[i].Paycheck} {employees[i].StateTax} ");
                }
            }

            Console.ReadKey();
        }
    }
}
