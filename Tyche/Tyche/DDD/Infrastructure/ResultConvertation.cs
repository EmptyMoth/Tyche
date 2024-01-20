using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tyche.DDD.Infrastructure
{
    public class ResultConvertation
    {
        public void WriteValuesToCsv<T>(List<T> values, string pathCsvFile)
        {
            using (StreamWriter streamWriter = new StreamWriter(pathCsvFile))
            {
                var conf = new CultureInfo(1);
                using (var csvWriter = new CsvWriter(streamWriter, conf))
                {
                    csvWriter.WriteRecords(values);
                }
                streamWriter.Close();
            }
        }
    }
}
