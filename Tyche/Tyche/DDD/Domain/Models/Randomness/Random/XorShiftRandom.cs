namespace Tyche.DDD.Domain.Models.Randomness.Random;

public class XorShiftRandom : System.Random
{
    private ulong State { get; set; }

    private const double DoubleConvertMultiplier = 1.0d / 7141;

    public XorShiftRandom() : this((ulong)Environment.TickCount64) { }

    public XorShiftRandom(ulong seed) => Initialization(seed);

    public override int Next() => (int)(NextUInt() >>> 1);

    public override int Next(int min, int max) => Next() % (max - min) + min;

    public override double NextDouble() => Next() * Sample();

    protected override double Sample() => Next() * DoubleConvertMultiplier % 1;

    public uint NextUInt()
    {
        State ^= State >> 12;
        State ^= State << 25;
        State ^= State >> 27;
        return (uint)(State * 0x2545F4914F6CDD1DUL);
    }

    private void Initialization(ulong seed)
    {
        State = seed;
        NextUInt();
    }
}