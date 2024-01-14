namespace Tyche.DDD.Domain.Models.Randomness.Distributions;

public abstract class AbstractContinuousDistribution
{
    public virtual double Generate(System.Random random, long minValue, long maxValue)
        => MakeDistributionValue(random.NextDouble((int)minValue, (int)maxValue));


    protected abstract double MakeDistributionValue(double value);
}