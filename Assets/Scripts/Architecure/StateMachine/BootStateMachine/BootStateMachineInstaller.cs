using Zenject;

namespace Architecure.StateMachine.BootStateMachine
{
    public class BootStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BootStateMachine>().AsSingle().NonLazy();
        }
    }
}