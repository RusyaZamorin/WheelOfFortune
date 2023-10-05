using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using WheelOfFortune.Services;
using Zenject;

namespace WheelOfFortune.GameplayScene.UI
{
    public class PlayerScoreView : MonoBehaviour
    {
        public TMP_Text TextField;
        private PlayerScoreService playerScoreService;

        [Inject]
        public void Construct(PlayerScoreService playerScoreService) => 
            this.playerScoreService = playerScoreService;

        public void Setup() => 
            SetScore();

        public async UniTask UpdateScore() => 
            SetScore();

        private void SetScore() => 
            TextField.text = GetFormattedScore();

        private string GetFormattedScore() => 
            playerScoreService.PlayerScore.ToString();
    }
}