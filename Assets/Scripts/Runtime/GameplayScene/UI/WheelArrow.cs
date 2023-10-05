using DG.Tweening;
using UnityEngine;

namespace WheelOfFortune.GameplayScene.UI
{
    public class WheelArrow : MonoBehaviour
    {
        public float AnimationDuration = 0.2f;

        public void PlayAnimation(float duration)
        {
            var sequence = DOTween.Sequence();

            sequence
                .Append(transform.DORotate(Vector3.forward * 20f, AnimationDuration).SetLoops((int)(duration / AnimationDuration) - 1, LoopType.Yoyo))
                .Append(transform.DORotate(Vector3.zero, AnimationDuration))
                .Play();
        }
    }
}