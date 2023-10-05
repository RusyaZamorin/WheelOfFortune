using WheelOfFortune.FortuneWheelLogic;
using WheelOfFortune.Randomization;
using WheelOfFortune.UI;
using Zenject;

namespace WheelOfFortune.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public FortuneWheelRandomizationSettings RandomizationSettings;
        public FortuneWheelSettings FortuneWheelSettings;
        public FortuneWheelView FortuneWheelView;

        public override void InstallBindings()
        {
            BindRandomizer();
            BindFortuneWheel();
            BindUI();
        }

        private void BindUI()
        {
            Container
                .Bind(typeof(FortuneWheelView), typeof(IInitializable))
                .FromInstance(FortuneWheelView)
                .AsSingle();
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