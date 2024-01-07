using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyche.Domain.Models;

namespace Tyche.Domain.Application
{
    public static class Engine
    {
        static AbstractContinuousDistribution distribution;
        static Random random;
        public static RandomType SelectedRandom { get; private set; }
        public static DistributionType SelectedDistribution { get; private set; }
        public enum RandomType
        {
            LCGRandom,
            MersenneTwisterRandom,
         //   PCGFastRandom,
            PCGRandom,
            XorShiftRandom,
            Xoshiro256Random
        }
        public enum DistributionType
        {
            ExponentialDistribution,
            NormalDistribution,
            UniformDistribution
        }
        static Engine()
        {
            SelectDistribution(DistributionType.NormalDistribution);
            SelectRandom(RandomType.MersenneTwisterRandom);
        }
 

        public static void SelectDistribution(DistributionType distributionType, double mean = 1, double sigma = 2, double lambda = 1)
        {
            switch (distributionType) 
            {
                case DistributionType.ExponentialDistribution:
                    distribution = new ExponentialDistribution(lambda);
                    break;
                case DistributionType.NormalDistribution:
                    distribution = new NormalDistribution(mean, sigma);
                    break;
                case DistributionType.UniformDistribution:
                    distribution = new UniformDistribution();
                    break;
            }
            SelectedDistribution = distributionType;
        }

        public static void SelectRandom(RandomType randomType, ulong seed = 123)
        {
            switch (randomType)
            {
                case RandomType.LCGRandom:
                    random = new LCGRandom(seed);
                    break;
                case RandomType.MersenneTwisterRandom:
                    random = new MersenneTwisterRandom((uint)seed);
                    break;
                //case RandomType.PCGFastRandom:
                //    random = new PCGFastRandom(seed);
                //    break;
                case RandomType.PCGRandom:
                    random = new PCGRandom(seed);
                    break;
                case RandomType.XorShiftRandom:
                    random = new XorShiftRandom(seed);
                    break;
            }
            SelectedRandom = randomType;
        }

        public static long GenerateDistributionValue(long minValue, long maxValue) => distribution.Generate(random, minValue, maxValue);
        public static long GenerateRandomValue(long minValue, long maxValue) => random.Next((int)minValue, (int)maxValue);
    }
}
