using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// Inherits from PayRecord, overrides abstract property Tax from base class. 
    /// </summary>
    public class ResidentPayRecord : PayRecord
    {
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates)
        {

        }

        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateResidentialTax(base.Gross);
            }
        }

        public override string GetDetails()
        {
            return $"  {new string('-', 10)} EMPLOYEE: {Id}  {new string('-', 10)}\nGROSS: ${Math.Round(Gross,5).ToString("N2", CultureInfo.InvariantCulture)}\nNET:   ${Math.Round(Net, 2).ToString("N2", CultureInfo.InvariantCulture)}\nTAX:   ${Math.Round(Tax, 2).ToString("N2", CultureInfo.InvariantCulture)}\n";
        }

    }
}
