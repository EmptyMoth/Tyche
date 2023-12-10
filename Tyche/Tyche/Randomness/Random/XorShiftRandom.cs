namespace Tyche.Randomness;

public class XorShiftRandom : Random
{
    private ulong State { get; set; }
    
    private const double DoubleConvertMultiplier = 1.0d / 7141;

    public XorShiftRandom() : this((ulong)Environment.TickCount64) { }
    
    public XorShiftRandom(ulong seed) => Initialization(seed);

    public override int Next() => (int)(NextUInt() >>> 1);

    public uint NextUInt()
    {
        State ^= State >> 12;
        State ^= State << 25;
        State ^= State >> 27;
        return (uint)(State * 0x2545F4914F6CDD1DUL);
    }

    protected override double Sample() => NextUInt() * DoubleConvertMultiplier;

    private void Initialization(ulong seed)
    {
        State = seed;
        NextUInt();
    }
}