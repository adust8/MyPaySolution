using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// Inherits from PayRecord, overrides abstract property Tax and GetDetails method from base class.
    /// </summary>
    public class WorkingHolidayPayRecord : PayRecord
    {
        public int Visa { get; private set; }
        public int YearToDate { get; private set; }

        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateWorkingHolidayTax(base.Gross, YearToDate);
            }
        }


        public override string GetDetails()
        {
            return $"  {new string('-', 10)} EMPLOYEE: {Id}  {new string('-', 10)}\nGROSS: ${Math.Round(Gross, 2).ToString("N2", CultureInfo.InvariantCulture)}\nNET:   ${Math.Round(Net, 2).ToString("N2", CultureInfo.InvariantCulture)}\nTAX:   ${Math.Round(Tax, 2).ToString("N2", CultureInfo.InvariantCulture)}\nVISA:  {Visa}\nYTD:   ${Math.Round((double)YearToDate, 2).ToString("N2", CultureInfo.InvariantCulture)}\n";
        }

        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            Visa = visa;
            YearToDate = yearToDate;
        }


    }
}
