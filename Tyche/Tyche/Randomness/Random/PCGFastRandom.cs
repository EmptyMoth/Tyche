namespace Tyche.Randomness;

public class PCGFastRandom : Random
{
    private ulong State { get; set; }
    
    private const ulong Multiplier = 6364136223846793005ul;
    private const double DoubleConvertMultiplier = 1.0d / Multiplier;

    public PCGFastRandom() : this((ulong)Environment.TickCount64) { }
    
    public PCGFastRandom(ulong seed) => Initialization(seed);

    public override int Next() => (int)(NextUInt() >>> 1);

    public uint NextUInt()
    {
        var oldState = State;
        State *= Multiplier;
        
        oldState ^= oldState >>> 22;
        var rotationCount = (byte)(oldState >>> 61);
        return (uint)(oldState >> (22 + rotationCount));
    }

    protected override double Sample() => NextUInt() * DoubleConvertMultiplier;

    private void Initialization(ulong seed)
    {
        State = 2 * seed + 1;
        NextUInt();
    }
}