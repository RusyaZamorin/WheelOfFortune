using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace WheelOfFortune.GameplayScene.FortuneWheelRandomization
{
    public class FortuneWheelRandomizer : IInitializable
    {
        private FortuneWheelRandomizationSettings settings;
        private List<int> valuesPool;

        [Inject]
        public FortuneWheelRandomizer(FortuneWheelRandomizationSettings settings) => 
            this.settings = settings;

        public void Initialize() => 
            valuesPool = InitializeValuesPool();

        public List<int> GetRandomValues(int count)
        {
            valuesPool.Shuffle();
            var resultValues = new List<int>();

            for (var i = 0; i < count; i++)
            {
                var correctValue = GetCorrectNexValue(resultValues);
                resultValues.Add(correctValue);
            }

            return resultValues;
        }

        private int GetCorrectNexValue(List<int> resultValues) =>
            valuesPool.First(item =>
                resultValues.All(value => Math.Abs(value - item) >= settings.MinDifferenceBetweenResultValues));

        private List<int> InitializeValuesPool()
        {
            var valuesPool = new List<int> { settings.MinValue };

            while (valuesPool.Last() < settings.MaxValue)
                valuesPool.Add(valuesPool.Last() + settings.IntervalBetweenValues);

            return valuesPool;
        }
    }
}