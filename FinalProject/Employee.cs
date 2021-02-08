using System;
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

		        { "AL", .04000 },
                { "AK", .00000 },
                { "AZ", .05600 },
                { "AR", .06500 },
                { "CA", .07250 },
                { "CO", .02900 },
                { "CT", .06350 },
                { "DE", .00000 },
                { "FL", .06000 },
                { "GA", .00400 },
                { "HI", .00400 },
                { "ID", .00600 },
                { "IL", .06250 },
                { "IN", .00700 },
                { "IA", .00600 },
                { "KS", .06500 },
                { "KY", .06000 },
                { "LA", .04450 },
                { "ME", .05500 },
                { "MD", .06000 },
                { "MA", .06250 },
                { "MI", .06000 },
                { "MN", .06875 },
                { "MS", .07000 },
                { "MO", .04225 },
                { "MT", .00000 },
                { "NE", .05500 },
                { "NV", .06850 },
                { "NH", .00000 },
                { "NJ", .06625 },
                { "NM", .05125 },
                { "NY", .04000 },
                { "NC", .04750 },
                { "ND", .05000 },
                { "OH", .05750 },
                { "OK", .04500 },
                { "OR", .00000 },
                { "PA", .06000 },
                { "RI", .07000 },
                { "SC", .06000 },
                { "SD", .04500 },
                { "TN", .07000 },
                { "TX", .06250 },
                { "UT", .06100 },
                { "VT", .06000 },
                { "VA", .05300 },
                { "WA", .06500 },
                { "WV", .06000 },
                { "WI", .05000 },
                { "WY", .04000 } 
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

            // Check if valid state during contruction. 
            // Is this okay?
            State = this.State;

            this.hoursWorked = hoursWorked;
            ratePerHour = 35.00;

            // Assign prop StateTax a value from the list of taxes by state.
            // The only readonly variable in this class.
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
    }
}



