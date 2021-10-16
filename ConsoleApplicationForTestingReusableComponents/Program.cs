using MyPayProject;
using System;

namespace ConsoleApplicationForTestingReusableComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test TaxCalculator class

            Console.WriteLine(new string('-',30));
            Console.WriteLine("Test TaxCalculator class");
            TaxCalculator.CalculateResidentialTax(565);
            Console.WriteLine(TaxCalculator.CalculateWorkingHolidayTax(233, 37888));
            Console.WriteLine(TaxCalculator.CalculateResidentialTax(565));

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Test ResidentPayRecord class");
            
            ResidentPayRecord residentPayRecord  = new ResidentPayRecord(1,new double[] {1,3,4,5,6 }, new double[] { 1, 2, 34, 5,7 });
            Console.WriteLine(residentPayRecord.GetDetails());

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Test WorkingHolidayPayRecord class");

            WorkingHolidayPayRecord workingHolidayPayRecord = new WorkingHolidayPayRecord(1, new double[] { 1, 3, 4, 5, 6 }, new double[] { 1, 2, 34, 5, 7 }, 5, 56666);
            Console.WriteLine(workingHolidayPayRecord.GetDetails());
        }
    }
}
