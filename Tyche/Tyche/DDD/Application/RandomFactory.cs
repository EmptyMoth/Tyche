using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tyche.DDD.Application.Engine;
using Tyche.DDD.Domain.Models.Randomness.Random;

namespace Tyche.DDD.Application
{
    public class RandomFactory : IRandomFactory
    {
        public Random CreateRandomInstance(RandomType type)
        {
            switch (type)
            {
                case RandomType.LCGRandom:
                    return new LCGRandom(Properties.Settings.Default.Seed);
                case RandomType.MersenneTwisterRandom:
                    return new MersenneTwisterRandom((long)Properties.Settings.Default.Seed);
                case RandomType.PCGRandom:
                    return new PCGRandom(Properties.Settings.Default.Seed);
                case RandomType.XorShiftRandom:
                    return new XorShiftRandom(Properties.Settings.Default.Seed);
                default:
                    break;
            }
            throw new NotSupportedException();
        }
    }
}
