using System;
using System.Collections.Generic;

namespace WheelOfFortune.Randomization
{
    public static class ShuffleExtension
    {
        private static Random random = new();
        
        public static void Shuffle<T>(this List<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}