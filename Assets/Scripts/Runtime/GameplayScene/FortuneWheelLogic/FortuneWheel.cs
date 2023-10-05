using System.Collections.Generic;
using WheelOfFortune.GameplayScene.FortuneWheelRandomization;
using Zenject;

namespace WheelOfFortune.GameplayScene.FortuneWheelLogic
{
    public class FortuneWheel
    {
        public List<int> SectorValues { get; private set; }
        public int ResultValue { get; private set; }
        public int SectorsCount => settings.SectionsCount;

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
            
            return ResultValue;
        }
    }
}