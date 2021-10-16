using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    public abstract class PayRecord
    {
        public int Id { get; private set; }
        /// <summary>
        /// Derived value calculated from the sum of (hours multiplied by rate) for all shifts.
        /// </summary>
        public double Gross
        {
            get
            {
                double gross = 0;

                for(int i = 0; i < _hours.Length; i++)
                {
                    gross += _hours[i] * _rates[i];                
                }

                return Math.Round(gross,2);
            }
        }
        /// <summary>
        ///  Derived value calculated from the appropriate TaxCalculator method based on the type of pay record (resident or working holiday)
        /// </summary>
        public abstract double Tax { get; }
        /// <summary>
        /// Derived value calculated from Gross minus Tax (Net = Gross - Tax)
        /// </summary>
        public double Net
        {
            get
            {
                return Math.Round(Gross - Tax,2);
            }
        }

        /// <summary>
        /// Array to store the hours and rate for each shift
        /// </summary>
        protected double[] _hours;
        /// <summary>
        /// Array to store the rates and rate for each shift
        /// </summary>
        protected double[] _rates;

        public PayRecord(int id, double[] hours, double[] rates)
        {
            Id = id;
            _hours = hours;
            _rates = rates;
        }

        public virtual string GetDetails()
        {
            return null;
        }


    }
}
