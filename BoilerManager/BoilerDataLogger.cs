using System.Collections.Generic;
using System.Globalization;
using BoilerManager.Helpers;
using BoilerManager.Model;
using CsvHelper;

namespace BoilerManager
{
    public class BoilerDataLogger
    {
        public string FileName = "BoilerLog.csv";

        public void WriteToFile(BoilerStateData boilerStateData)
        {
            if (!File.Exists(FileName))
            {
                string[] clientHeader = new string[] { "BoilerState", "InterLockSwitchState", "StateTime" };
                File.WriteAllText(FileName, string.Join(",", clientHeader));
                using (StreamWriter streamWriter = new StreamWriter(FileName, true))
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecord(boilerStateData);
                    streamWriter.WriteLine();
                }
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(FileName, true))
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecord(boilerStateData);
                    streamWriter.WriteLine();
                }
            }
        }

        public void WriteToConsole(BoilerStateData boilerStateData)
        {
            MessageUtility.BoilerStatusWriter(boilerStateData);
        }

        public List<BoilerStateData>? Read()
        {
            if (!File.Exists(FileName))
            {
                MessageUtility.ActionFailedNotifier("Log Empty");
                return null;
            }

            MessageUtility.ActionTitleWriter("Boiler Log");
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
