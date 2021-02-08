﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    /// <summary>
    /// 
    /// </summary>
    public class Employee
    {
        ulong employeeIdNumber;
        int hoursWorked;
        double ratePerHour;
        string state;
        Dictionary<string, double>  taxesByState =
            new Dictionary<string, double>
            {
               #region States and Tax
                // State tax chart - https://taxfoundation.org/state-and-local-sales-tax-rates-2020/

		        { "AL", .04 },
                { "AK", 0.00 },
                { "AZ", .056 },
                { "AR", 6.50 },
                { "CA", .0725 },
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
        double paycheck;
        public readonly double StateTax;

        public ulong EmployeeIdNumber
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

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (!(taxesByState.ContainsKey(state.ToUpper())))
                {
                    throw new Exception("Please enter valid State abbreviation: ex. \"TX\"");
                }
                else
                {
                    state = value;
                }
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

        public Employee()
        {
                
        }

        public Employee(string state, int hoursWorked)
        {
          
            this.state = state.ToUpper();
            this.hoursWorked = hoursWorked;
            ratePerHour = 35.00;

            foreach(var t in taxesByState)
            {
                if(t.Key == this.state)
                {
                    StateTax = t.Value;
                    break;
                }
            }
                        
            double preTaxPayCheck = hoursWorked * ratePerHour;
            paycheck = (preTaxPayCheck - (preTaxPayCheck * StateTax));
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



