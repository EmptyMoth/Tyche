using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tyche.DDD.Application.Engine;
using Tyche.DDD.Domain.Models.Randomness.Distributions;

namespace Tyche.DDD.Application
{
    public interface IDistributionFactory
    {
        AbstractContinuousDistribution CreateDistributionInstance(DistributionType type);
    }
}
