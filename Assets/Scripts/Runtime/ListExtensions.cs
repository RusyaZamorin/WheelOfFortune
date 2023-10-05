using System;
using System.Collections.Generic;

namespace WheelOfFortune
{
    public static class ListExtensions
    {
        private static Random random = new(DateTime.Now.Millisecond);

        public static T TakeRandom<T>(this List<T> list) => 
            list[UnityEngine.Random.Range(0, list.Count)];

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