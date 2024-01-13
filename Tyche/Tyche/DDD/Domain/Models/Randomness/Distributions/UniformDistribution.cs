namespace Tyche.DDD.Domain.Models.Randomness.Distributions;

public class UniformDistribution : AbstractContinuousDistribution
{
    protected override double MakeDistributionValue(double value) => value;
}