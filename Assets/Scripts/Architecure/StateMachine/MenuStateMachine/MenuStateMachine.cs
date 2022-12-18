using Architecure.StateMachine.Base;
using Zenject;

namespace Architecure.StateMachine.MenuStateMachine
{
    public class MenuStateMachine : StateMachineBase
    {
        public MenuStateMachine(DiContainer container, SignalBus signalBus) : base(container, signalBus)
        {
        }

        protected override void Initialize()
        {
            ChangeState<LoadMenuState>();
        }
    }
}