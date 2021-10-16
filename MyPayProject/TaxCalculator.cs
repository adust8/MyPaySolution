using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    public class TaxCalculator
    {
        public static double CalculateResidentialTax(double gross)
        {
            double a = 0;
            double b = 0;

            if (gross > -1 && gross <= 72)
            {
                a = 0.19;
                b = 0.19;
            }

            else if (gross > 72 && gross <= 361)
            {
                a = 0.2342;
                b = 3.213;
            }

            else if (gross > 361 && gross <= 932)
            {
                a = 0.3477;
                b = 44.2476;
            }

            else if (gross > 932 && gross <= 1380)
            {
                a = 0.345;
                b = 41.7311;
            }

            else if (gross > 1380 && gross <= 3111)
            {
                a = 0.39;
                b = 103.8657;
            }

            else if (gross > 3111 && gross <= 999999)
            {
                a = 0.47;
                b = 352.7888;
            }

            double tax = a * gross - b;

            return Math.Round(tax,2);
        }

        public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        {
            double rate = 0;
            double totalGross = yearToDate + gross;

            if (totalGross > -1 && totalGross <= 37000)
            {
                rate = 0.15;
            }
            else if (totalGross > 37000 && totalGross <= 90000)
            {
                rate = 0.32;
            }
            else if (totalGross > 90000 && totalGross <= 180000)
            {
                rate = 0.37;
            }
            else if (totalGross > 90000 && totalGross <= 180000)
            {
                rate = 0.45;
            }

            return Math.Round((gross * rate),2);
        }
        
    }
}
