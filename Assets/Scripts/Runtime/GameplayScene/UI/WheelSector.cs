using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace WheelOfFortune.GameplayScene.UI
{
    public class WheelSector : MonoBehaviour
    {
        public TMP_Text TextField;
        public int Value;

        public async UniTask SetValue(int value)
        {
            Value = value;
            TextField.text = Value.ToString();
        }
    }
}