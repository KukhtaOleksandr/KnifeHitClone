using System.ComponentModel;
using Zenject;

namespace Global.Progress
{
    public class ProgressInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameProgressService>().AsSingle();
        }
    }
}