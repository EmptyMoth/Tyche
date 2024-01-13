using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tyche.DDD.Application.Engine;

namespace Tyche.DDD.Application
{
    public interface IRandomFactory
    {
        Random CreateRandomInstance(RandomType type);
    }
}
