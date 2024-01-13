
namespace Tyche.DDD.Domain.Models.Randomness.Random;

public class LCGRandom : System.Random
{
    private ulong State { get; set; }

    private const uint Multiplier = 7141;
    private const uint Increment = 54773;
    private const uint Mod = 259200;
    private const double DoubleConvertMultiplier = 1.0d / Multiplier;

    public LCGRandom() : this((ulong)Environment.TickCount64) { }

    public LCGRandom(ulong seed) => Initialization(seed);

    public override int Next() => (int)(NextUInt() >>> 1);
    public override int Next(int min, int max) => Next() % (max - min) + min;
    public override double NextDouble() => Next() * Sample();
    protected override double Sample() => Next() * DoubleConvertMultiplier % 1;

    public uint NextUInt()
    {
        State = (Multiplier * State + Increment) % Mod;
        return (uint)State;
    }

    private void Initialization(ulong seed)
    {
        State = seed + Increment;
        NextUInt();
    }
}