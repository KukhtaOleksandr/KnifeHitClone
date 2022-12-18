using Architecure.StateMachine.Base;
using Global.Progress;
using Global.Progress.Data;
using Zenject;

namespace Architecure.StateMachine.BootStateMachine
{
    class LoadProgressState : IState
    {
        [Inject]
        private IGameProgressLoader _gameProgressLoader;
        [Inject]
        readonly SignalBus _signalBus;

        public LoadProgressState(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        public void Enter()
        {
            _gameProgressLoader.Load();
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() { State = new LoadMenuSceneState() });
        }

        public void Exit()
        {

        }
    }
}