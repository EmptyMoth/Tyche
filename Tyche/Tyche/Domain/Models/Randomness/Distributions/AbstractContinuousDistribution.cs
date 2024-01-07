namespace Tyche.Domain.Models;

public abstract class AbstractContinuousDistribution
{
    public virtual long Generate(Random random, long minValue, long maxValue)
        => (long)MakeDistributionValue(random.Next((int)minValue, (int)maxValue));

    //public virtual double GenerateDouble(Random random, double minValue, double maxValue)
    //    => MakeDistributionValue(random.NextDouble(minValue, maxValue));

    protected abstract double MakeDistributionValue(double value);
}