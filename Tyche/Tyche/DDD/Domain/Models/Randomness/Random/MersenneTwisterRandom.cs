using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyche.DDD.Domain.Models.Randomness.Random
{
    public class MersenneTwisterRandom : System.Random
    {
        private const int N = 624;
        private const int M = 397;
        private const uint MatrixA = 0x9908B0DF;
        private const uint UpperMask = 0x80000000;
        private const uint LowerMask = 0x7FFFFFFF;
        private const double DoubleConvertMultiplier = 1.0d / 7141;

        private readonly uint[] _mt = new uint[N];
        private int _mti = N + 1;

        public MersenneTwisterRandom() : this(DateTime.Now.Ticks) { }

        public MersenneTwisterRandom(long seed) => Initialize((uint)seed);

        public override int Next() => (int)(NextUInt() >> 1);

        public override int Next(int min, int max) => Next() % (max - min) + min;

        public override double NextDouble() => Next() * Sample();

        protected override double Sample() => Next() * DoubleConvertMultiplier % 1;

        private void Initialize(uint seed)
        {
            _mt[0] = seed;
            for (var i = 1; i < N; i++)
                _mt[i] = (uint)(1812433253 * (_mt[i - 1] ^ _mt[i - 1] >> 30) + i);
        }

        private uint NextUInt()
        {
            uint x = 0;
            if (_mti >= N)
            {
                var i = 0;
                for (; i < N - M; i++)
                {
                    x = _mt[i] & UpperMask | _mt[i + 1] & LowerMask;
                    _mt[i] = _mt[i + M] ^ x >> 1 ^ (x & 0x1) * MatrixA;
                }

                for (; i < N - 1; i++)
                {
                    x = _mt[i] & UpperMask | _mt[i + 1] & LowerMask;
                    _mt[i] = _mt[i + (M - N)] ^ x >> 1 ^ (x & 0x1) * MatrixA;
                }

                x = _mt[N - 1] & UpperMask | _mt[0] & LowerMask;
                _mt[N - 1] = _mt[M - 1] ^ x >> 1 ^ (x & 0x1) * MatrixA;

                _mti = 0;
            }

            x = _mt[_mti++];
            x ^= x >> 11;
            x ^= x << 7 & 0x9D2C5680;
            x ^= x << 15 & 0xEFC60000;
            x ^= x >> 18;
            return x;
        }
    }
}

