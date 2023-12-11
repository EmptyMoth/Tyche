namespace Tyche.Randomness;

public class UniformDistribution : AbstractContinuousDistribution
{
    protected override double MakeDistributionValue(double value) => value;
}