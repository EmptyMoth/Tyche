using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings;
using Ninject.Syntax;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using Tyche.DDD.Domain;
using Tyche.DDD.Domain.Models.Randomness.Distributions;
using Tyche.DDD.Domain.Models.Randomness.Random;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Tyche.DDD.Application.Engine;

namespace Tyche.DDD.Application
{
    public class Engine
    {
        private Dictionary<DistributionInformation, AbstractContinuousDistribution> distributions;
        private Dictionary<RandomInformation, Random> randoms;
        private IDistributionFactory distributionFactory;
        private IRandomFactory randomFactory;
        public enum RandomType
        {
            LCGRandom,
            MersenneTwisterRandom,
            PCGRandom,
            XorShiftRandom,
        }

        public enum DistributionType
        {
            ExponentialDistribution,
            NormalDistribution,
            UniformDistribution,
        }

        public Engine(Dictionary<RandomInformation, Random> randoms, Dictionary<DistributionInformation, AbstractContinuousDistribution> distributions, IDistributionFactory distributionFactory, IRandomFactory randomFactory)
        {
            this.randoms = randoms;
            this.randomFactory = randomFactory;
            this.distributionFactory = distributionFactory;
            this.distributions = distributions;
        }

        public void ReloadRandoms()
        {
            var dict = new Dictionary<RandomInformation, Random>();
            foreach (var rand in randoms.Keys)
                dict[rand] = randomFactory.CreateRandomInstance(rand.Type);
            randoms = dict;
        }

        public void ReloadDistributions()
        {
            var dict = new Dictionary<DistributionInformation, AbstractContinuousDistribution>();
            foreach (var distr in distributions.Keys)
                dict[distr] = distributionFactory.CreateDistributionInstance(distr.Type);
            distributions = dict;
        }

        private RandomInformation GetRandomInfoByType(RandomType random) => randoms.Keys.Where(x => x.Type == random).Select(x => x).First();
        private DistributionInformation GetDistributionInfoByType(DistributionType distribution) => distributions.Keys.Where(x => x.Type == distribution).Select(x => x).First();
        public double GenerateDistributionValue(long minValue, long maxValue, DistributionType distribution, RandomType random)
            => distributions[GetDistributionInfoByType(distribution)].Generate(randoms[GetRandomInfoByType(random)], minValue, maxValue);
        public IReadOnlyList<RandomInformation> GetRandomInfoList() => randoms.Keys.ToList();
        public IReadOnlyList<DistributionInformation> GetDistributionInfoList() => distributions.Keys.ToList();
        public double GenerateRandomValue(long minValue, long maxValue, RandomType random) => randoms[GetRandomInfoByType(random)].NextDouble((int)minValue, (int)maxValue);
    }
}
