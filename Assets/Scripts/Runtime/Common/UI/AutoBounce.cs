using DG.Tweening;
using UnityEngine;

namespace WheelOfFortune.Common.UI
{
    public class AutoBounce : MonoBehaviour
    {
        public float BouncingDuration = 0.1f;
        public float BouncingMultiplayer = 1.1f;

        private void Awake()
        {
            transform.DOScale(transform.localScale * BouncingMultiplayer, BouncingDuration / 2f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }
    }
}