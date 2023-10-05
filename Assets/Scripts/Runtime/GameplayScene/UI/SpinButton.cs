using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WheelOfFortune.GameplayScene.UI
{
    public class SpinButton : MonoBehaviour, IPointerDownHandler
    {
        public GameObject ActiveIcon;
        public GameObject InActiveIcon;
        private bool isLocked;
            
        public event Action Click;

        public async UniTask Lock()
        {
            isLocked = true;
            UpdateIcons();
        }

        public async UniTask Unlock()
        {
            isLocked = false;
            UpdateIcons();
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!isLocked) 
                Click?.Invoke();
        }

        private void UpdateIcons()
        {
            ActiveIcon.SetActive(!isLocked);
            InActiveIcon.SetActive(isLocked);
        }
    }
}