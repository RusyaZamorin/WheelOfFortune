using System;
using System.Collections.Generic;
using System.Linq;
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
        public WheelArrow WheelArrow;
        public AudioSource AudioSource;
        
        public float FastRotatingDuration = 2f;
        public float SlowRotatingDuration = 2f;
        public int NumberFastRotating = 10;
        
        private FortuneWheel fortuneWheel;

        [Inject]
        public void Construct(FortuneWheel fortuneWheel) =>
            this.fortuneWheel = fortuneWheel;

        public async UniTask PlaySpinAnimation()
        {
            await UpdateSectors();
            AudioSource.Play();
            WheelArrow.PlayAnimation(FastRotatingDuration + SlowRotatingDuration);
            await PlayWheelAnimation();
        }

        private async UniTask PlayWheelAnimation()
        {
            WheelRotationTransform
                .DORotate(new Vector3(0, 0, WheelRotationTransform.transform.eulerAngles.z + 360f),
                    FastRotatingDuration / NumberFastRotating, RotateMode.FastBeyond360)
                .SetLoops(NumberFastRotating, LoopType.Restart)
                .SetEase(Ease.Linear);

            await UniTask.Delay(TimeSpan.FromSeconds(FastRotatingDuration));

            var resultLocalAngle = Sectors.First(s => s.Value == fortuneWheel.ResultValue).transform.localEulerAngles.z;

            WheelRotationTransform
                .DORotate(new Vector3(0, 0, -(360f + resultLocalAngle)), SlowRotatingDuration,
                    RotateMode.FastBeyond360)
                .SetEase(Ease.OutCirc);

            await UniTask.Delay(TimeSpan.FromSeconds(SlowRotatingDuration));
        }

        private async UniTask UpdateSectors()
        {
            var upSectorIndex = Sectors.IndexOf(Sectors.OrderBy(s => Math.Abs(s.transform.rotation.z)).First());
            for (var i = 0; i < fortuneWheel.SectorsCount; i++)
            {
                var value = fortuneWheel.SectorValues[i];
                await Sectors[(upSectorIndex + i) % fortuneWheel.SectorsCount].SetValue(value);
            }
        }
    }
}