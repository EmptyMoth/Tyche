namespace Tyche.Randomness;

public interface IContinuousDistribution
{
    double Generate(Random random, long minValue, long maxValue);
}