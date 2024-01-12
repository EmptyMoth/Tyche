using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using Tyche.Domain.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Tyche.Domain.Application.Engine;

namespace Tyche.Domain.Application
{
    public class GuiModule : NinjectModule
    {
        public override void Load()
        {
            InitRandom();
            InitDistributions();
            SetRandomInformation();
            SetDistributionInformation();
            Bind<Engine>().ToSelf().InSingletonScope();
        }
        
        private void InitRandom()
        {
            Bind<Random>().To<LCGRandom>().Named(RandomType.LCGRandom.ToString());
            Bind<Random>().To<MersenneTwisterRandom>().Named(RandomType.MersenneTwisterRandom.ToString());
            Bind<Random>().To<PCGRandom>().Named(RandomType.PCGRandom.ToString());
            Bind<Random>().To<XorShiftRandom>().Named(RandomType.XorShiftRandom.ToString());
            Bind<Random>().To<Xoshiro256Random>().Named(RandomType.Xoshiro256Random.ToString());
            if (this.Kernel.GetAll<Random>().Count() != Enum.GetValues(typeof(Engine.RandomType)).Length)
                throw new ActivationException("Количество инициализированных элементов не совпадает с количеством " +
                    "элементов в Engine.RandomType. Вероятно, вы забыли добавить random в enum, " +
                    "либо не инициализировали его в коде выше.");
        }

        private void InitDistributions()
        {
            Bind<AbstractContinuousDistribution>().To<ExponentialDistribution>().Named(DistributionType.ExponentialDistribution.ToString());
            Bind<AbstractContinuousDistribution>().To<NormalDistribution>().Named(DistributionType.NormalDistribution.ToString());
            Bind<AbstractContinuousDistribution>().To<UniformDistribution>().Named(DistributionType.UniformDistribution.ToString());
            if (this.Kernel.GetAll<AbstractContinuousDistribution>().Count() != Enum.GetValues(typeof(Engine.DistributionType)).Length)
                throw new ActivationException("Количество инициализированных элементов не совпадает с количеством " +
                    "элементов в Engine.DistributionType. Вероятно, вы забыли добавить distribution в enum, " +
                    "либо не инициализировали его в коде выше.");
        }

        private void SetDistributionInformation()
        {
            Bind<Dictionary<DistributionInformation, AbstractContinuousDistribution>>().ToMethod(context =>
            {
                var dictionary = new Dictionary<DistributionInformation, AbstractContinuousDistribution>();
                List<DistributionInformation> distributionInfo = new List<DistributionInformation>();
                distributionInfo.Add(new DistributionInformation(DistributionType.ExponentialDistribution.ToString(), 
                    "Экспоненциа́льное (или показа́тельное) распределе́ние — абсолютно непрерывное распределение, " +
                    "моделирующее время между двумя последовательными свершениями одного и того же события. " +
                    "P.S. Входное значение должно находиться в диапазоне (TODO).", 
                    DistributionType.ExponentialDistribution));
                distributionInfo.Add(new DistributionInformation(DistributionType.NormalDistribution.ToString(),
                    "Закон нормального распределения — это статистический закон, который описывает, " +
                    "как часто различные значения случайной величины встречаются в наборе данных. " +
                    "P.S. Входное значение должно находиться в диапазоне (TODO)", 
                    DistributionType.NormalDistribution));
                distributionInfo.Add(new DistributionInformation(DistributionType.UniformDistribution.ToString(),
                    "Непреры́вное равноме́рное распределе́ние в теории вероятностей — распределение случайной вещественной величины, " +
                    "принимающей значения, принадлежащие некоторому промежутку конечной длины, характеризующееся тем, " +
                    "что плотность вероятности на этом промежутке почти всюду постоянна. " +
                    "P.S. Входное значение должно находиться в диапазоне (TODO)", 
                    DistributionType.UniformDistribution));
                foreach (var info in distributionInfo)
                    dictionary.Add(info, this.Kernel.Get<AbstractContinuousDistribution>(info.Type.ToString()));
                if (distributionInfo.Count != Enum.GetValues(typeof(Engine.DistributionType)).Length)
                    throw new ActivationException("Количество инициализированных элементов не совпадает с количеством " +
                        "элементов в Engine.DistributionType. Вероятно, вы забыли добавить distribution в enum, " +
                        "либо не инициализировали его в коде выше.");
                return dictionary;
            }).InSingletonScope();
        }

        private void SetRandomInformation()
        {
            Bind<Dictionary<RandomInformation, Random>>().ToMethod(context =>
            {
                var dictionary = new Dictionary<RandomInformation, Random>();
                List<RandomInformation> randomInfo = new List<RandomInformation>();
                randomInfo.Add(new RandomInformation(RandomType.LCGRandom.ToString(), "123", RandomType.LCGRandom));
                randomInfo.Add(new RandomInformation(RandomType.MersenneTwisterRandom.ToString(), "123", RandomType.MersenneTwisterRandom));
                randomInfo.Add(new RandomInformation(RandomType.PCGRandom.ToString(), "123", RandomType.PCGRandom));
                randomInfo.Add(new RandomInformation(RandomType.XorShiftRandom.ToString(), "123", RandomType.XorShiftRandom));
                randomInfo.Add(new RandomInformation(RandomType.Xoshiro256Random.ToString(), "123", RandomType.Xoshiro256Random));
                foreach (var info in randomInfo)
                    dictionary.Add(info, this.Kernel.Get<Random>(info.Type.ToString()));
                if (randomInfo.Count != Enum.GetValues(typeof(Engine.RandomType)).Length)
                    throw new ActivationException("Количество инициализированных элементов не совпадает с количеством " +
                        "элементов в Engine.RandomType. Вероятно, вы забыли добавить random в enum, " +
                        "либо не инициализировали его в коде выше.");
                return dictionary;
            }).InSingletonScope();
        }
    }

    public class Engine
    {
        private Dictionary<DistributionInformation, AbstractContinuousDistribution> distributions;
        private Dictionary<RandomInformation, Random> randoms;
        public enum RandomType
        {
            LCGRandom,
            MersenneTwisterRandom,
            PCGRandom,
            XorShiftRandom,
            Xoshiro256Random,
        }
        public enum DistributionType
        {
            ExponentialDistribution,
            NormalDistribution,
            UniformDistribution,
        }

        public Engine(Dictionary<RandomInformation, Random> randoms, Dictionary<DistributionInformation, AbstractContinuousDistribution> distributions)
        {
            this.randoms = randoms;
            this.distributions = distributions;
        }

        private RandomInformation GetRandomInfoByType(RandomType random) => randoms.Keys.Where(x => x.Type == random).Select(x => x).First();
        private DistributionInformation GetDistributionInfoByType(DistributionType distribution) => distributions.Keys.Where(x => x.Type == distribution).Select(x => x).First();
        public long GenerateDistributionValue(long minValue, long maxValue, DistributionType distribution, RandomType random) => distributions[GetDistributionInfoByType(distribution)].Generate(randoms[GetRandomInfoByType(random)], minValue, maxValue);
        public IReadOnlyList<RandomInformation> GetRandomInfoList() => randoms.Keys.ToList();
        public IReadOnlyList<DistributionInformation> GetDistributionInfoList() => distributions.Keys.ToList();
        public long GenerateRandomValue(long minValue, long maxValue, RandomType random) => randoms[GetRandomInfoByType(random)].Next((int)minValue, (int)maxValue);
    }
}
