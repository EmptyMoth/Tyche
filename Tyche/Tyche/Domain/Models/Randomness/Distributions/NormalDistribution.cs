namespace Tyche.Domain.Models;

public class NormalDistribution : AbstractContinuousDistribution
{
    public readonly double Mean;
    public readonly double Sigma;

    public NormalDistribution(double mean = 0.0, double sigma = 1.0)
    {
        Sigma = sigma;
        Mean = mean;
    }

    public override long Generate(Random random, long minValue, long maxValue)
        => (long)MakeDistributionValue(random.NextDouble(), random.NextDouble());

    //public override double GenerateDouble(Random random, double minValue, double maxValue)
    //    => MakeDistributionValue(random.NextDouble(minValue, maxValue), random.NextDouble(minValue, maxValue));

    protected override double MakeDistributionValue(double value)
    {
        throw new NotImplementedException();
    }

    protected double MakeDistributionValue(double u, double v) =>
        Math.Sqrt(-2 * Math.Log(1.0 - u)) * Math.Sin(2 * Math.PI * (1.0 - v)) * Sigma + Mean;
}