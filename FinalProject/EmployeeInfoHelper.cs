using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FinalProject
{
    public class EmployeeInfoHelper
    {
        Employee[] employees = new Employee[10];
        public bool HasRecords { get; set; }
        public bool MenuItemSelected { get; set; }

        public EmployeeInfoHelper()
        {
           
        }

        public void ListInfo(int employeeIndex)
        {
        }


        public void DisplayMenu()
        {
            Console.WriteLine(
                "(A)dd\t" +
                "(D)elete\t" +
                "(L)ist\t" +
                "(S)earch\t");
        }

        public void GetMenuOption(string keyPressed)
        {
            string upper = keyPressed.ToUpper();

            switch(upper)
            {
                case "A":
                    AddEmployee();
                    MenuItemSelected = true;
                    break;
                case "D":
                    DeleteEmployee();
                    MenuItemSelected = true;
                    break;
                case "L":
                    ListEmployees();
                    MenuItemSelected = true;
                    break;
                case "S":
                    SearchEmployees();
                    break;
                default:
                    break;
            }
        }

        public void AddEmployee()
        {
            HasRecords = true;
        }

        private void DeleteEmployee()
        {
            // If records == 0 change bool.
        }

        private void ListEmployees()
        {
            if (!HasRecords)
            { 
                Console.WriteLine("\r\nNo employee records.\r\n");
                Console.Read();
                Console.Clear();
                DisplayMenu();
            }
            else
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    Console.WriteLine($"{i}) {employees[i].EmployeeIdNumber}");
                }
            }
        }

        private void SearchEmployees()
        {
           
        }
    }
}
