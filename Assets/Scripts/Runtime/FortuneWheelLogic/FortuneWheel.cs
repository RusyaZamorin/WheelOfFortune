using System.Collections.Generic;
using WheelOfFortune.Randomization;
using Zenject;

namespace WheelOfFortune.FortuneWheelLogic
{
    public class FortuneWheel
    {
        public List<int> SectionValues { get; private set; }
        public int ResultValue { get; private set; }
        public int SectionsCount => settings.SectionsCount;
        
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
            SectionValues = randomizer.GetRandomValues(settings.SectionsCount);
            ResultValue = SectionValues.TakeRandom();
            
            return ResultValue;
        }
    }
}