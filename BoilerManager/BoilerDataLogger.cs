using System.Collections.Generic;
using System.Globalization;
using BoilerManager.Model;
using CsvHelper;

namespace BoilerManager
{
    public class BoilerDataLogger
    {
        public string FileName = "BoilerLog.txt";

        public void Write(BoilerStateData boilerStateData)
        {
            using (StreamWriter streamWriter = new StreamWriter(FileName,true))
            using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecord(boilerStateData);
                streamWriter.WriteLine();
            }
        }

        public List<BoilerStateData> Read()
        {
            Console.WriteLine("Hello");
            using (StreamReader reader = new StreamReader(FileName))
            using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                IEnumerable<BoilerStateData> records = csvReader.GetRecords<BoilerStateData>();

                foreach (var r in records)
                {
                    Console.WriteLine($"{r.BoilerState} | {r.InterLockSwitchState} | {r.StateTime}");
                }
                Console.ReadLine();
            return records.ToList();
            }
        }

    }
}
