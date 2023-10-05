using UnityEngine;

namespace WheelOfFortune.Randomization
{
    [CreateAssetMenu(fileName = nameof(FortuneWheelRandomizationSettings),
        menuName = nameof(WheelOfFortune) + "/" + nameof(FortuneWheelRandomizationSettings), order = 0)]
    public class FortuneWheelRandomizationSettings : ScriptableObject
    {
        public int MaxValue = 100000;
        public int MinValue = 1000;
        public int IntervalBetweenValues = 100;
        public int MinDifferenceBetweenResultValues = 1000;
    }
}