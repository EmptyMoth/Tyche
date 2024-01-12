namespace Tyche.Domain.Models;

public class ExponentialDistribution : AbstractContinuousDistribution
{
    public readonly double Lambda;

    public ExponentialDistribution(double lambda = 1.0)
    {
        Lambda = lambda;
    }
    
    public override long Generate(Random random, long minValue, long maxValue)
        => (long)MakeDistributionValue(random.NextDouble());

    protected override double MakeDistributionValue(double value) => -Math.Log(1.0 - value) / Lambda;
}