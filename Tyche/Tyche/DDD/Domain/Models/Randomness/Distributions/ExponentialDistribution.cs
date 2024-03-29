﻿namespace Tyche.DDD.Domain.Models.Randomness.Distributions;

public class ExponentialDistribution : AbstractContinuousDistribution
{
    public readonly double Lambda;
    public ExponentialDistribution(double lambda = 1.0)
    {
        Lambda = lambda;
    }

    protected override double MakeDistributionValue(double value) => -Math.Log(1.0 - value) / Lambda;
}