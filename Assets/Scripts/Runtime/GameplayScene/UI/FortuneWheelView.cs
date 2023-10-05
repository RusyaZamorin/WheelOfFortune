using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using WheelOfFortune.GameplayScene.FortuneWheelLogic;
using Zenject;

namespace WheelOfFortune.GameplayScene.UI
{
    public class FortuneWheelView : MonoBehaviour
    {
        public List<WheelSector> Sectors;
        public Transform WheelRotationTransform;
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
            var duration = 2f;
            var count = 10;

            WheelRotationTransform
                .DORotate(new Vector3(0, 0, -360), duration / count, RotateMode.FastBeyond360)
                .SetLoops(count, LoopType.Restart)
                .SetEase(Ease.Linear);

            await UniTask.Delay(TimeSpan.FromSeconds(duration));

            var resultSectorNumber = fortuneWheel.SectorValues.IndexOf(fortuneWheel.ResultValue) + 1;
            var resultAngle = resultSectorNumber * (360f / fortuneWheel.SectorsCount);

            WheelRotationTransform.DORotate(new Vector3(0, 0, -360 - resultAngle), 2f, RotateMode.FastBeyond360)
                .SetEase(Ease.OutCirc);

            await UniTask.Delay(TimeSpan.FromSeconds(1f));
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