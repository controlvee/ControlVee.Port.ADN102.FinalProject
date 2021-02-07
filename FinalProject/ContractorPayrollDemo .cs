using System;

namespace FinalProject
{
    class ContractorPayrollDemo
    {
        static void Main(string[] args)
        {
            EmployeeInfoHelper helper = new EmployeeInfoHelper();

            try
            {
                helper.DisplayMenu();

                string keyPressed = Console.ReadLine();

                if (!helper.MenuItemSelected)
                {
                    helper.GetMenuOption(keyPressed);
                }
               

                









                //string state = Console.ReadLine();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
