using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using WheelOfFortune.GameplayScene.FortuneWheelLogic;
using Zenject;

namespace WheelOfFortune.GameplayScene.UI
{
    public class FortuneWheelView : MonoBehaviour
    {
        public List<WheelSector> Sectors;
        private FortuneWheel fortuneWheel;

        [Inject]
        public void Construct(FortuneWheel fortuneWheel) => 
            this.fortuneWheel = fortuneWheel;

        public UniTask Setup() => 
            UpdateSectors();

        public async UniTask PlaySpinAnimation()
        {
            await UpdateSectors();
            await PlayWheelAnimation();
        }

        private async UniTask PlayWheelAnimation()
        {
            
        }
        
        private async UniTask UpdateSectors()
        {
            for (var i = 0; i < fortuneWheel.SectorsCount; i++)
            {
                var value = fortuneWheel.SectorValues[i];
                await Sectors[i].SetValue(value);
            }
        }
    }
}