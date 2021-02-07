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
                while (helper.GetMenuOption())
                {
                    Console.Clear();
                    helper.DisplayMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
