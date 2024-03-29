﻿using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyche.DDD.Domain.Models.Randomness.Random
{
    public class PCGRandom : System.Random
    {
        private ulong State { get; set; }

        private const ulong Multiplier = 6364136223846793005ul;
        private const ulong Increment = 1442695040888963407ul | 1;
        private const double DoubleConvertMultiplier = 1.0d / Multiplier * 10000000000;

        public PCGRandom() : this((ulong)Environment.TickCount64) { }

        public PCGRandom(ulong seed) => Initialization(seed);

        public override int Next() => (int)(NextUInt() >>> 1);

        public override int Next(int min, int max) => Next() % (max - min) + min;

        public override double NextDouble() => Next() * Sample();

        public uint NextUInt()
        {
            var oldState = State;
            State = Multiplier * State + Increment;

            var rotationCount = (byte)(oldState >>> 59);
            oldState ^= oldState >>> 18;
            oldState >>= 27;
            return (uint)oldState >>> rotationCount | (uint)oldState << (-rotationCount & 31);
        }

        protected override double Sample() => Next() * DoubleConvertMultiplier % 1;

        private void Initialization(ulong seed)
        {
            State = seed + Increment;
            NextUInt();
        }
    }
}
