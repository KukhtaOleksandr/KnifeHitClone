using Architecure.StateMachine.Base;
using Zenject;

namespace Architecure.StateMachine.BootStateMachine
{
    public class BootStateMachine : StateMachineBase
    {
        public BootStateMachine(DiContainer container, SignalBus signalBus) : base(container, signalBus)
        {
        }

        protected override void Initialize()
        {
            ChangeState<LoadProgressState>();
        }
    }
}