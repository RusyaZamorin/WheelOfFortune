using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace WheelOfFortune.GameplayScene.UI
{
    public class WheelSector : MonoBehaviour
    {
        public TMP_Text TextField;
        public int Value;
        public float BouncingDuration = 0.1f;
        public float BouncingMultiplayer = 1.1f;

        private Vector3 startScale;
        
        private void Awake() => 
            startScale = transform.localScale;

        public async UniTask SetValue(int value)
        {
            var sequence = DOTween.Sequence();
            Value = value;

            sequence.Append(transform.DOScale(startScale * BouncingMultiplayer, BouncingDuration / 2f))
                .Append(transform.DOScale(startScale, BouncingDuration / 2f))
                .Play();

            TextField.text = Value.ToString();
            
            await UniTask.Delay(TimeSpan.FromSeconds(BouncingDuration));
        }
    }
}