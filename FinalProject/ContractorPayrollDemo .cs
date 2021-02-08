using System;

namespace FinalProject
{
    class ContractorPayrollDemo
    {
        static void Main(string[] args)
        {
            EmployeeInfoHelper helper = new EmployeeInfoHelper();

            helper.DisplayMenu();
            while (helper.GetMenuOption())
            {
                try
                {
                    Console.Clear();
                    helper.DisplayMenu();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
