using Zenject;

namespace Architecure.PlayModeStateMachine
{
    public class PlayStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayStateMachine>().AsSingle().NonLazy();
        }
    }
}