using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tyche.Domain.Application.Engine;

namespace Tyche.Domain.UI
{
    public class DistributionInformation
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DistributionType Type { get; private set; }
        public DistributionInformation(string name, string description, DistributionType distributionType)
        {
            Name = name;
            Description = description;
            Type = distributionType;
        }

        public override string ToString() => Name;
    }
}
