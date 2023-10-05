using WheelOfFortune.FortuneWheelLogic;
using WheelOfFortune.Randomization;
using Zenject;

namespace WheelOfFortune.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public FortuneWheelRandomizationSettings RandomizationSettings;
        public FortuneWheelSettings FortuneWheelSettings;
        
        public override void InstallBindings()
        {
            BindRandomizer();
            BindFortuneWheel();
        }

        private void BindFortuneWheel()
        {
            Container.Bind<FortuneWheel>().AsSingle();
            Container.BindInstance(FortuneWheelSettings).AsSingle();
        }

        private void BindRandomizer()
        {
            Container.BindInstance(RandomizationSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<FortuneWheelRandomizer>().AsSingle();
        }
    }
}