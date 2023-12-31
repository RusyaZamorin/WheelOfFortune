﻿using UnityEngine;

namespace WheelOfFortune.GameplayScene.FortuneWheelLogic
{
    [CreateAssetMenu(fileName = nameof(FortuneWheelSettings),
        menuName = nameof(WheelOfFortune) + "/" + nameof(FortuneWheelSettings), order = 0)]
    public class FortuneWheelSettings : ScriptableObject
    {
        public int SectionsCount = 16;
    }
}