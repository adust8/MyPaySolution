using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MyPayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileImportPath = @"..\..\..\Import\employee-payroll-data.csv";
            string fileExportPath = @$"..\..\..\Export\\{DateTime.Now.Ticks}-records.csv";
            List<PayRecord> records = CsvImporter.ImportPayRecords(fileImportPath);

            PayRecordWriter.Write(fileExportPath,records,true);
        }
    }
}
