using Cysharp.Threading.Tasks;
using WheelOfFortune.GameplayScene.FortuneWheelLogic;
using WheelOfFortune.GameplayScene.UI;
using Zenject;

namespace WheelOfFortune.GameplayScene
{
    public class GameplaySceneLifecycle : IInitializable
    {
        private FortuneWheel fortuneWheel;
        private FortuneWheelView wheelView;
        private SpinButton spinButton;

        [Inject]
        public GameplaySceneLifecycle(
            FortuneWheel fortuneWheel, 
            FortuneWheelView wheelView,
            SpinButton spinButton)
        {
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
            await wheelView.Setup();
        }
        
        public async UniTask SpinFortuneWheel()
        {
            await spinButton.Lock();
            
            fortuneWheel.Spin();
            await wheelView.PlaySpinAnimation();
            
            await spinButton.Unlock();
        }
    }
}