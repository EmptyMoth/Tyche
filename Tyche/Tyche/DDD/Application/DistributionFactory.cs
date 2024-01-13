using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tyche.DDD.Application.Engine;
using Tyche.DDD.Domain.Models.Randomness.Distributions;

namespace Tyche.DDD.Application
{
    public class DistributionFactory : IDistributionFactory
    {
        public AbstractContinuousDistribution CreateDistributionInstance(DistributionType type)
        {
            switch (type)
            {
                case DistributionType.NormalDistribution:
                    return new NormalDistribution(Properties.Settings.Default.Mean, Properties.Settings.Default.Sigma);
                case DistributionType.ExponentialDistribution:
                    return new ExponentialDistribution(Properties.Settings.Default.Lambda);
                case DistributionType.UniformDistribution:
                    return new UniformDistribution();
                default:
                    break;
            }
            throw new NotSupportedException();
        }
    }
}
