using System;
using System.Collections.Generic;
using WheelOfFortune.Randomization;
using Zenject;

namespace WheelOfFortune.FortuneWheelLogic
{
    public class FortuneWheel
    {
        public List<int> SectorValues { get; private set; }
        public int ResultValue { get; private set; }
        public int SectorsCount => settings.SectionsCount;

        public event Action Spined;
        
        private FortuneWheelRandomizer randomizer;
        private FortuneWheelSettings settings;

        [Inject]
        public FortuneWheel(FortuneWheelRandomizer randomizer, FortuneWheelSettings settings)
        {
            this.settings = settings;
            this.randomizer = randomizer;
        }

        public int Spin()
        {
            SectorValues = randomizer.GetRandomValues(settings.SectionsCount);
            ResultValue = SectorValues.TakeRandom();
            
            Spined?.Invoke();
            return ResultValue;
        }
    }
}