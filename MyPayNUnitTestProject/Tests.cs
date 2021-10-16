using MyPayProject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPayNUnitTestProject
{
    public class Tests
    {
        private List<PayRecord> _records;

        [SetUp]
        public void Setup()
        {
            string fileImportPath = @"..\..\..\Import\employee-payroll-data.csv";
            _records = CsvImporter.ImportPayRecords(fileImportPath);
        }

        [Test]
        public void TestImport()
        {
            var isNotNull = _records != null;
            var hasFiveObjects = _records.Count == 5;

            Assert.True(isNotNull);
            Assert.True(hasFiveObjects);
        }

        [Test]
        public void TestGross()
        {
            List<double> grossValues = new List<double>()
            {
                652,
                418,
                2202,
                1104,
                1797.45
            };
            List<double> grossRecords = new List<double>();

            foreach (var record in _records)
            {
                grossRecords.Add(record.Gross);
            }

            

            Assert.True(grossRecords.SequenceEqual(grossValues));
        }

        [Test]
        public void TestTax()
        {
            List<double> taxValues = new List<double>()
            {
                182.45,
                133.76,
                754.91,
                165.6,
                597.14
            };
            List<double> taxRecords = new List<double>();

            foreach (var record in _records)
            {
                taxRecords.Add(record.Tax);
            }

            Assert.True(taxRecords.SequenceEqual(taxValues));
        }

        [Test]
        public void TestNet()
        {
            List<double> netValues = new List<double>()
            {
                469.55,
                284.24,
                1447.09,
                938.4,
                1200.31
            };
            List<double> netRecords = new List<double>();

            foreach (var record in _records)
            {
                netRecords.Add(record.Net);
            }

            Assert.True(netRecords.SequenceEqual(netValues));
        }

        [Test]
        public void TestExport()
        {
            string filePath = @$"..\..\..\Export\\{DateTime.Now.Ticks}-records.csv";
            PayRecordWriter.Write(filePath,_records,false);

            Assert.True(File.Exists(filePath));
        }


    }
}
