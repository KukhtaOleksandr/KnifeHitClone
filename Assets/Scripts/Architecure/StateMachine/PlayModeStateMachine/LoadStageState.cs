using Architecure.StateMachine.Base;
using Knife.UI;
using Stump;
using UI.Factories;
using Zenject;

namespace Architecure.PlayModeStateMachine
{
    public class LoadStageState : IState
    {
        [Inject]
        readonly KnifeFactory _knifeFactory;
        [Inject]
        readonly KnifeUIFactory _knifeUIFactory;
        [Inject]
        readonly StumpFactory _stumpFactory;
        [Inject]
        readonly StageTextFactory _stageTextFactory;
        [Inject]
        readonly SignalBus _signalBus;

        public void Enter()
        {
            _stumpFactory.CreateStump();
            _knifeFactory.CreateKnife();
            _knifeUIFactory.Create();
            _stageTextFactory.Create();
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() {State = new PlayState()});
        }

        public void Exit()
        {
            
        }
    }
}