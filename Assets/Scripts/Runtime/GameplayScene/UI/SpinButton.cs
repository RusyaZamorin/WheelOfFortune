using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WheelOfFortune.GameplayScene.UI
{
    public class SpinButton : MonoBehaviour, IPointerDownHandler
    {
        private bool isLocked;
            
        public event Action Click;

        public async UniTask Lock()
        {
            isLocked = true;
        }

        public async UniTask Unlock()
        {
            isLocked = false;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!isLocked) 
                Click?.Invoke();
        }
    }
}