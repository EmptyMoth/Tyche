using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyche.DDD.Domain.Models.Randomness.Distributions;
using static Tyche.DDD.Application.Engine;

namespace Tyche.DDD.Application
{
    public class EngineModule : NinjectModule
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
            Bind<IRandomFactory>().To<RandomFactory>();
        }

        private void InitDistributions()
        {
            Bind<IDistributionFactory>().To<DistributionFactory>();
        }

        private void SetDistributionInformation()
        {
            Bind<Dictionary<DistributionInformation, AbstractContinuousDistribution>>().ToMethod(context =>
            {
                var dictionary = new Dictionary<DistributionInformation, AbstractContinuousDistribution>();
                List<DistributionInformation> distributionInfo = new List<DistributionInformation>();
                distributionInfo.Add(new DistributionInformation(DistributionType.ExponentialDistribution.ToString(),
                    "Экспоненциа́льное (или показа́тельное) распределе́ние — абсолютно непрерывное распределение, " +
                    "моделирующее время между двумя последовательными свершениями одного и того же события. ",
                    DistributionType.ExponentialDistribution));
                distributionInfo.Add(new DistributionInformation(DistributionType.NormalDistribution.ToString(),
                    "Закон нормального распределения — это статистический закон, который описывает, " +
                    "как часто различные значения случайной величины встречаются в наборе данных. ",
                    DistributionType.NormalDistribution));
                distributionInfo.Add(new DistributionInformation(DistributionType.UniformDistribution.ToString(),
                    "Непреры́вное равноме́рное распределе́ние в теории вероятностей — распределение случайной вещественной величины, " +
                    "принимающей значения, принадлежащие некоторому промежутку конечной длины, характеризующееся тем, " +
                    "что плотность вероятности на этом промежутке почти всюду постоянна. ",
                    DistributionType.UniformDistribution));
                foreach (var info in distributionInfo)
                    dictionary.Add(info, Kernel.Get<IDistributionFactory>().CreateDistributionInstance(info.Type));
                if (distributionInfo.Count != Enum.GetValues(typeof(DistributionType)).Length)
                    throw new ActivationException("Количество инициализированных элементов не совпадает с количеством " +
                        "элементов в Engine.DistributionType. Вероятно, вы забыли добавить distribution в enum, " +
                        "либо не инициализировали его в DistributionFactory.");
                return dictionary;
            }).InSingletonScope();
        }

        private void SetRandomInformation()
        {
            Bind<Dictionary<RandomInformation, Random>>().ToMethod(context =>
            {
                var dictionary = new Dictionary<RandomInformation, Random>();
                List<RandomInformation> randomInfo = new List<RandomInformation>();
                randomInfo.Add(new RandomInformation(RandomType.LCGRandom.ToString(),
                    "LCG Random: Вычисляет псевдослучайные числа с помощью прерывистого кусочно-линейного уравнения.",
                    RandomType.LCGRandom));
                randomInfo.Add(new RandomInformation(RandomType.MersenneTwisterRandom.ToString(),
                    "Mersenne Twister Random: Генератор псевдослучайных чисел общего назначения (PRNG), генерирует с периодом равным одному из простых чисел Мерсенна, " +
                    "большой период, недетерминированный, трудно выявляемые статистические закономерности.",
                    RandomType.MersenneTwisterRandom));
                randomInfo.Add(new RandomInformation(RandomType.PCGRandom.ToString(),
                    "PCG Random: применяет выходную функцию перестановки для улучшения статистических свойств линейного конгруэнтного генератора по модулю 2n." +
                    " Он обеспечивает отличную статистическую производительность при небольшом и быстром коде и небольшом размере состояния.",
                    RandomType.PCGRandom));
                randomInfo.Add(new RandomInformation(RandomType.XorShiftRandom.ToString(),
                    "Xor Shift Random: Генератор сдвигового регистра, представляет собой подмножество регистров сдвига с линейной обратной связью (LFSR), которые позволяют особенно " +
                    "эффективно реализовать их в программном обеспечении без чрезмерного использования разреженных полиномов.",
                    RandomType.XorShiftRandom));
                foreach (var info in randomInfo)
                    dictionary.Add(info, Kernel.Get<IRandomFactory>().CreateRandomInstance(info.Type));
                if (randomInfo.Count != Enum.GetValues(typeof(RandomType)).Length)
                    throw new ActivationException("Количество инициализированных элементов не совпадает с количеством " +
                        "элементов в Engine.RandomType. Вероятно, вы забыли добавить random в enum, " +
                        "либо не инициализировали его в RandomFactory.");
                return dictionary;
            }).InSingletonScope();
        }
    }
}
