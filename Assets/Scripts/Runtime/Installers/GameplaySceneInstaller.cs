using WheelOfFortune.Randomization;
using Zenject;

namespace WheelOfFortune.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public FortuneWheelRandomizationSettings RandomizationSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(RandomizationSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<FortuneWheelRandomizer>().AsSingle();
        }
    }
}