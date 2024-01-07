namespace Tyche.Domain.Models;

public class UniformDistribution : AbstractContinuousDistribution
{
    protected override double MakeDistributionValue(double value) => value;
}