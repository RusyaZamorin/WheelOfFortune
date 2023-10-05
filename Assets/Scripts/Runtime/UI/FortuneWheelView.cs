using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using WheelOfFortune.FortuneWheelLogic;
using Zenject;

namespace WheelOfFortune.UI
{
    public class FortuneWheelView : MonoBehaviour, IInitializable
    {
        public List<WheelSector> Sectors;
        private FortuneWheel fortuneWheel;

        public event Action SpinAnimationFinished;
        
        [Inject]
        public void Construct(FortuneWheel fortuneWheel) => 
            this.fortuneWheel = fortuneWheel;

        public void Initialize() => 
            fortuneWheel.Spined += PlaySpinAnimation;

        public void TestSpin()
        {
            fortuneWheel.Spin();
        }
        
        private async void PlaySpinAnimation()
        {
            await UpdateSectors();
            await PlayWheelAnimation();
        }

        private async UniTask PlayWheelAnimation()
        {
            
        }
        
        private async Task UpdateSectors()
        {
            for (var i = 0; i < fortuneWheel.SectorsCount; i++)
            {
                var value = fortuneWheel.SectorValues[i];
                await Sectors[i].SetValue(value);
            }
        }
    }
}