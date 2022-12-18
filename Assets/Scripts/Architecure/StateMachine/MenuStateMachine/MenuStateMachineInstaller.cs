using Zenject;

namespace Architecure.StateMachine.MenuStateMachine
{
    public class MenuStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MenuStateMachine>().AsSingle().NonLazy();
        }
    }
}