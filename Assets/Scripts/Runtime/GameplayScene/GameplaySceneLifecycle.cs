using Cysharp.Threading.Tasks;
using UnityEngine;
using WheelOfFortune.GameplayScene.FortuneWheelLogic;
using WheelOfFortune.GameplayScene.UI;
using WheelOfFortune.Services;
using Zenject;

namespace WheelOfFortune.GameplayScene
{
    public class GameplaySceneLifecycle : IInitializable
    {
        private FortuneWheel fortuneWheel;
        private FortuneWheelView wheelView;
        private SpinButton spinButton;
        private PlayerScoreService playerScoreService;
        private PlayerScoreView playerScoreView;

        [Inject]
        public GameplaySceneLifecycle(
            FortuneWheel fortuneWheel, 
            FortuneWheelView wheelView,
            SpinButton spinButton, 
            PlayerScoreService playerScoreService, 
            PlayerScoreView playerScoreView)
        {
            this.playerScoreView = playerScoreView;
            this.playerScoreService = playerScoreService;
            this.spinButton = spinButton;
            this.wheelView = wheelView;
            this.fortuneWheel = fortuneWheel;
        }

        public void Initialize()
        {
            SetupScene();
            spinButton.Click += () => SpinFortuneWheel();
        }

        public async UniTask SetupScene()
        {
            fortuneWheel.Spin();
            playerScoreView.Setup();
            await wheelView.Setup();
        }
        
        public async UniTask SpinFortuneWheel()
        {
            await spinButton.Lock();
            
            fortuneWheel.Spin();
            playerScoreService.IncreaseScore(fortuneWheel.ResultValue);
            
            await wheelView.PlaySpinAnimation();
            await playerScoreView.UpdateScore();
            
            await spinButton.Unlock();
        }
    }
}