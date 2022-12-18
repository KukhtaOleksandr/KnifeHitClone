using Architecure.StateMachine.Base;
using Zenject;

namespace Architecure.PlayModeStateMachine
{
    public class PlayStateMachine : StateMachineBase
    {
        public PlayStateMachine(DiContainer container, SignalBus signalBus) : base(container,signalBus)
        {
            
        }

        protected override void Initialize()
        {
            ChangeState<LoadPlayModeState>();
        }
    }
}