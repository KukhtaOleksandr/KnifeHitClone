using System.Threading.Tasks;
using Architecure.StateMachine.Base;
using Knife.UI;
using Stump;
using Zenject;
using Input;
using UI.ButtonHandlers;
using Architecure.StateMachine.PlayModeStateMachine;
using Global.Services.Audio;
using UI.Factories;

namespace Architecure.PlayModeStateMachine
{
    public class GameLooseState : IState
    {
        [Inject]
        private KnifeFactory _knifeFactory;
        [Inject]
        private KnifeUIFactory _knifeUIFactory;
        [Inject]
        private ScoreUIFactory _scoreUIFactory;
        [Inject]
        private StumpFactory _stumpFactory;
        [Inject]
        private GameLoosePanelFactory _gameLoosePanelFactory;
        [Inject]
        readonly GameInputFactory _gameInputFactory;
        [Inject]
        readonly IAudioService _audioService;
        [Inject]
        readonly SignalBus _signalBus;

        
        public void Enter()
        {
            _signalBus.Subscribe<SignalRestartButtonClicked>(Restart);
            _signalBus.Subscribe<SignalHomeButtonClicked>(LoadMenuSceneState);

            _audioService.Play(Global.Audio.AudioTypes.GameLoose);
            WaitForAllAnimationsAndDestroy();
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalRestartButtonClicked>(Restart);
            _signalBus.Unsubscribe<SignalHomeButtonClicked>(LoadMenuSceneState);
        }

        private void LoadMenuSceneState()
        {
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() {State = new LoadMenuSceneState()});
        }

        private async void WaitForAllAnimationsAndDestroy()
        {
            _gameInputFactory.Destroy();
            await Task.Delay(800);
            await Task.WhenAll(_gameLoosePanelFactory.CreatePanel());
            _knifeFactory.DestroyAllKnives();
            _stumpFactory.DestroyStump();
            _knifeUIFactory.DestroyAll();
            _scoreUIFactory.Destroy();
        }

        private async void Restart()
        {
            await Task.WhenAll(_gameLoosePanelFactory.DestroyPanel());
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() {State = new LoadPlayModeState()});
        }
    }
}