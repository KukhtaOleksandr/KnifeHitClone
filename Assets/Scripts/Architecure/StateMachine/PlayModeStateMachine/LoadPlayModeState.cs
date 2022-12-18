using Architecure.Services;
using Architecure.StateMachine.Base;
using Input;
using UI.Factories;
using Zenject;

namespace Architecure.PlayModeStateMachine
{
    public class LoadPlayModeState : IState
    {
        [Inject]
        readonly GameInputFactory _gameInputFactory;
        [Inject]
        readonly ScoreUIFactory _scoreUIFactory;
        [Inject]
        readonly IStageConfigGeneratorService _stageConfigGenerator;
        [Inject]
        readonly ICurrentScoreService _currentScoreService;
        [Inject]
        readonly IPlayAudioLoaderService _playAudioLoaderService;
        [Inject]
        readonly SignalBus _signalBus;
        public async void Enter()
        {
            _gameInputFactory.Create();
            _stageConfigGenerator.Reset();
            _currentScoreService.ResetScore();
            _scoreUIFactory.Create();
            await _playAudioLoaderService.Load();
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() {State = new LoadStageState()});
        }

        public void Exit()
        {

        }
    }
}