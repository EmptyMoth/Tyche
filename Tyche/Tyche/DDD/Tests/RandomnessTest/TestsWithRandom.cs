using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Tyche.DDD.Domain.Models.Randomness.Distributions;
using Tyche.DDD.Domain.Models.Randomness.Random;

namespace Tyche.Domain.Tests.RandomnessData
{
    public class TestsWithRandom
    {
        public List<double> GenerateRandomValues<TRandom, TDistribution>(
            TDistribution distribution,
            TRandom random,
            int count)
            where TRandom : Random
            where TDistribution : AbstractContinuousDistribution
        {
            return Enumerable.Range(0, count)
                .Select(_ => distribution.Generate(random, 0, 1))
                .ToList();
        }

        public void WriteValuesToCsv(List<double> randomValues, string pathCsvFile)
        {

            using (StreamWriter streamWriter = new StreamWriter(pathCsvFile))
            {
                var conf = new CultureInfo(1);
                using (var csvWriter = new CsvWriter(streamWriter, conf))
                {
                    csvWriter.WriteRecords(randomValues);
                }
                streamWriter.Close();
            }
        }

        private void GenerateAndWriteValuesToCsvs(
            Random random,
            string defaultPath,
            int countValues)
        {
            WriteValuesToCsv(
                GenerateRandomValues(new UniformDistribution(), random, countValues),
                defaultPath + "\\UniformDistribution.csv");

            WriteValuesToCsv(
                GenerateRandomValues(new ExponentialDistribution(), random, countValues),
                defaultPath + "\\ExponentialDistribution.csv");

            WriteValuesToCsv(
                GenerateRandomValues(new NormalDistribution(), random, countValues),
                defaultPath + "\\NormalDistribution.csv");
        }

        public void ToCSV()
        {
            Type[] typesRandom = {
                typeof(LCGRandom),
                typeof(MersenneTwisterRandom),
                typeof(PCGRandom),
                typeof(XorShiftRandom)
            };
            var countValues = 100000;
            foreach (Type type in typesRandom)
            {
                string defaultPath = $"..\\..\\..\\DDD\\Tests\\RandomnessCsv\\{type.Name}";
                Random? random = Activator.CreateInstance(type) as Random;
                if (random == null) continue;
                GenerateAndWriteValuesToCsvs(random, defaultPath, countValues);
            }
        }
    }
}
