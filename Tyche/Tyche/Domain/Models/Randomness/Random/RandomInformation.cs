using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyche.Domain.Application;
using static Tyche.Domain.Application.Engine;

namespace Tyche.Domain.Models
{
    public class RandomInformation
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public RandomType Type { get; private set; }
        public RandomInformation(string name, string description, RandomType randomType)
        {
            Name = name;
            Description = description;
            Type = randomType;
        }

        public override string ToString() => Name;
    }
}
