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

        private string GetFormattedScore()
        {
            var score = playerScoreService.PlayerScore;
            return score switch
            {
                < 1000 => score.ToString(),
                > 1000 and < 1000000 => score / 1000 + "k",
                _ => $"{score / 1000000}m {score % 1000000/ 1000}k"
            };
        } 
    }
}