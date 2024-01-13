namespace Tyche.DDD.Domain;

public static class RandomExtensions
{
    public static double NextDouble(this Random random,
        double minValue = double.MinValue, double maxValue = double.MaxValue)
        => random.NextDouble() % (maxValue - minValue) + minValue;
}