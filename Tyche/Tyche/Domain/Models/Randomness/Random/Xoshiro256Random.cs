namespace Tyche.Domain.Models;

public class Xoshiro256Random : Random
{
    public override int Next() => (int)(0);
    public override int Next(int min, int max) => (Next() % (max - min + 1)) + min;
}