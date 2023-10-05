using WheelOfFortune.GameplayScene;
using WheelOfFortune.GameplayScene.FortuneWheelLogic;
using WheelOfFortune.GameplayScene.FortuneWheelRandomization;
using WheelOfFortune.GameplayScene.UI;
using Zenject;

namespace WheelOfFortune.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public FortuneWheelRandomizationSettings RandomizationSettings;
        public FortuneWheelSettings FortuneWheelSettings;
        public FortuneWheelView FortuneWheelView;
        public SpinButton SpinButton;
        public PlayerScoreView PlayerScoreView;
        
        public override void InstallBindings()
        {
            BindRandomizer();
            BindFortuneWheel();
            BindUI();
            
            Container.BindInterfacesAndSelfTo<GameplaySceneLifecycle>().AsSingle();
        }

        private void BindUI()
        {
            Container.BindInstance(SpinButton).AsSingle();
            Container.BindInstance(PlayerScoreView).AsSingle();
            Container.BindInstance(FortuneWheelView).AsSingle();
        }

        private void BindFortuneWheel()
        {
            Container.BindInstance(FortuneWheelSettings).AsSingle();
            Container.Bind<FortuneWheel>().AsSingle();
        }

        private void BindRandomizer()
        {
            Container.BindInstance(RandomizationSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<FortuneWheelRandomizer>().AsSingle();
        }
    }
}