using UnityEngine;
using WheelOfFortune.Services;
using WheelOfFortune.Services.SaveLoad;
using Zenject;

namespace WheelOfFortune.Installers
{
    [CreateAssetMenu(fileName = nameof(ProjectGlobalInstaller),
        menuName = nameof(WheelOfFortune) + "/" + nameof(ProjectGlobalInstaller), order = 0)]
    public class ProjectGlobalInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISaveLoadService>().To<PlayerPrefsSaveLoadService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerScoreService>().AsSingle();
        }
    }
}