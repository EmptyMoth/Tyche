using Tyche.DDD.Domain.Models.Randomness.Random;

namespace Tyche.DDD.Domain.Models.Randomness.Distributions;

public class NormalDistribution : AbstractContinuousDistribution
{
    public readonly double Mean;
    public readonly double Sigma;

    public NormalDistribution(double mean = 0.0, double sigma = 1.0)
    {
        Sigma = sigma;
        Mean = mean;
    }

    public override double Generate(System.Random random, long minValue, long maxValue)
        => MakeDistributionValue(random.NextDouble((int)minValue, (int)maxValue), random.NextDouble((int)minValue, (int)maxValue));

    protected override double MakeDistributionValue(double value)
    {
        throw new NotImplementedException();
    }

    protected double MakeDistributionValue(double u, double v) =>
        Math.Sqrt(-2 * Math.Log(1.0 - u)) * Math.Sin(2 * Math.PI * (1.0 - v)) * Sigma + Mean;
}