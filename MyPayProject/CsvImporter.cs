using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayProject
{
    public class ImportPayRecord
    {
        public int Id { get; set; }
        public double Hour { get; set; }
        public double Rate { get; set; }
        public string Visa { get; set; }
        public string YearToDate { get; set; }
    }



    public class CsvImporter
    {
        public static List<PayRecord> ImportPayRecords(string filePath)
        {
            List<ImportPayRecord> importRecords = new List<ImportPayRecord>();
            List<PayRecord> records = new List<PayRecord>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] columns = null;
                string line;
                bool isHeader = true;

                while ((line = sr.ReadLine()) != null)
                {
                    columns = line.Split(',');
                    if(!isHeader)
                    {
                        importRecords.Add(new ImportPayRecord
                        {
                            Id = int.Parse(columns[0]),
                            Hour = double.Parse(columns[1]),
                            Rate = double.Parse(columns[2]),
                            Visa = columns[3],
                            YearToDate = columns[4],
                        });
                    }

                    isHeader = false;
                }
            }
            for (int i = 0; i < importRecords.Count; i++)
            {
                List<double> hours = new List<double>();
                List<double> rate = new List<double>();
                List<ImportPayRecord> recordsById = importRecords.Where(x => x.Id == i).ToList();

                if(recordsById.Any())
                {
                    foreach (var record in recordsById)
                    {
                        hours.Add(record.Hour);
                        rate.Add(record.Rate);
                    }

                    ImportPayRecord lastRecord = recordsById.Last();

                    if (string.IsNullOrEmpty(lastRecord.Visa) || string.IsNullOrEmpty(lastRecord.YearToDate))
                    {
                        records.Add(new ResidentPayRecord(lastRecord.Id, hours.ToArray(), rate.ToArray()));
                    }
                    else
                    {
                        records.Add(new WorkingHolidayPayRecord(lastRecord.Id, hours.ToArray(), rate.ToArray(), int.Parse(lastRecord.Visa), int.Parse(lastRecord.YearToDate)));
                    }
                }               

            }

            return records;
        }


    }
    
}

