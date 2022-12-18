using Global.Services.Settings;
using Zenject;

namespace Global.Services.Audio
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AudioProvider>().AsSingle();
            Container.BindInterfacesTo<AudioService>().AsSingle();
            Container.BindInterfacesTo<SettingsService>().AsSingle().NonLazy();

            Container.BindInitializableExecutionOrder<SettingsService>(-20);
            Container.BindInitializableExecutionOrder<AudioService>(-10);
        }

    }
}