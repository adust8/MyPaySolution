using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    /// <summary>
    /// Class that contains a static method for writing the calculated pay records to a comma delimited file (and optionally console) 
    /// </summary>
    public static class PayRecordWriter
    {
        public static void Write(string filePath, List<PayRecord> records, bool writeToConsole)
        {
            if(writeToConsole)
            {
                foreach (var record in records)
                {
                    Console.WriteLine(record.GetDetails());
                }
                
            }
            string delimiter = ", ";
            File.AppendAllText(filePath, "Id" + delimiter);
            File.AppendAllText(filePath, "Gross" + delimiter);
            File.AppendAllText(filePath, "Net" + delimiter);
            File.AppendAllText(filePath, "Tax" + delimiter);
            File.AppendAllText(filePath, "\n");

            foreach (var record in records)
            {
                File.AppendAllText(filePath, $"{record.Id}" + delimiter);
                File.AppendAllText(filePath, $"{record.Gross}" + delimiter);
                File.AppendAllText(filePath, $"{record.Net}" + delimiter);
                File.AppendAllText(filePath, $"{record.Tax}" + delimiter);
                File.AppendAllText(filePath, $"\n");
            }
            


        }
    }
}
