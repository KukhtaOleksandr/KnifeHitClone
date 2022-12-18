using Architecure.StateMachine.Base;
using UI.ButtonHandlers;
using UI.Factories;
using Zenject;

namespace Architecure.StateMachine.MenuStateMachine
{
    public class LoadMenuState : IState
    {
        [Inject]
        private MenuUIFactory _menuUIFactory;
        [Inject]
        private SignalBus _signalBus;
        public void Enter()
        {
            _menuUIFactory.Create();
            _signalBus.Subscribe<SignalPlayButtonClicked>(LoadNextState);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalPlayButtonClicked>(LoadNextState);
        }

        private void LoadNextState()
        {
            _signalBus.Fire<SignalChangedState>(new SignalChangedState(){State = new LoadPlayModeSceneState()});
        }
    }
}