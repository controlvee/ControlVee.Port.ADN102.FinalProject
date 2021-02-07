﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    /// <summary>
    /// 
    /// </summary>
    public class Employee
    {
        int employeeIdNumber;
        int hoursWorked;
        double ratePerHour;
        string state;
        double paycheck;
        public readonly int StateTax;
        Dictionary<string, double> taxesByState = 
            new Dictionary<string, double>
            {
               #region States and Tax
                // State tax chart - https://taxfoundation.org/state-and-local-sales-tax-rates-2020/

		        { "AL", 4.00 },
                { "AK", 0.00 },
                { "AZ", 5.60 },
                { "AR", 6.50 },
                { "CA", 7.25 },
                { "CO", 2.90 },
                { "CT", 6.35 },
                { "DE", 0 },
                { "FL", 0 },
                { "GA", 0 },
                { "HI", 0 },
                { "ID", 0 },
                { "IL", 0 },
                { "IN", 0 },
                { "IA", 0 },
                { "KS", 0 },
                { "KY", 0 },
                { "LA", 0 },
                { "ME", 0 },
                { "MD", 0 },
                { "MA", 0 },
                { "MI", 0 },
                { "MN", 0 },
                { "MS", 0 },
                { "MO", 0 },
                { "MT", 0 },
                { "NE", 0 },
                { "NV", 0 },
                { "NH", 0 },
                { "NJ", 0 },
                { "NM", 0 },
                { "NY", 0 },
                { "NC", 0 },
                { "ND", 0 },
                { "OH", 0 },
                { "OK", 0 },
                { "OR", 0 },
                { "PA", 0 },
                { "RI", 0 },
                { "SC", 0 },
                { "SD", 0 },
                { "TN", 0 },
                { "TX", 0 },
                { "UT", 0 },
                { "VT", 0 },
                { "VA", 0 },
                { "WA", 0 },
                { "WV", 0 },
                { "WI", 0 },
                { "WY", 0 } 
	#endregion
            };

        public int EmployeeIdNumber
        {
            get
            {
                return employeeIdNumber;
            }
            set
            {
                employeeIdNumber = value;
            }
        }

        public int HoursWorked
        {
            get
            {
                return hoursWorked;
            }
            set
            {
                hoursWorked = value;
            }
        }

        public double Paycheck
        {
            get
            {
                return paycheck;
            }
            set
            {
                paycheck = value;
            }
        }

        public Employee(string state)
        {
            if (!(taxesByState.ContainsKey(state)))
            {
                throw new Exception("Please enter valid State abbreviation: ex. \"TX\"");
            }

            this.state = state;
            ratePerHour = 35;

            CalculatePaycheck();
        }

        private void CalculatePaycheck()
        {
            double preTaxPayCheck = hoursWorked * ratePerHour;
            paycheck = preTaxPayCheck - 
                (preTaxPayCheck * (StateTax * 0.1d));
        }

        public override string ToString()
        {
            return $"Employee ID: " +
                $"{EmployeeIdNumber}\r\n" +
                $"Paycheck Amount: " +
                $"{paycheck}\r\n" +
                $"Total State Tax: " +
                $"{StateTax}\r\n";
        }
    }
}


