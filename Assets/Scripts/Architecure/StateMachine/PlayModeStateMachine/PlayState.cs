using System.Threading.Tasks;
using Architecure.Services;
using Architecure.StateMachine.Base;
using Global.Progress;
using Global.Progress.Data.Transactions;
using Knife;
using UI.Factories;
using Zenject;

namespace Architecure.PlayModeStateMachine
{
    public class PlayState : IState
    {
        [Inject]
        readonly SignalBus _signalBus;
        [Inject]
        readonly StageTextFactory _stageTextFactory;
        [Inject]
        readonly ScoreUIFactory _scoreUIFactory;
        [Inject]
        readonly ICurrentScoreService _currentScoreService;
        [Inject]
        readonly IStageConfigGeneratorService _stageConfigGeneratorService;
        [Inject]
        readonly IGameProgressService _gameProgressService;
        [Inject]
        readonly IGameProgressSaver _gameProgressSaver;
        public void Enter()
        {
            _signalBus.Subscribe<SignalNewStageConfigGenerated>(LoadNextStage);
            _signalBus.Subscribe<SignalKnifeHitAnotherKnife>(LoadGameLooseState);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<SignalNewStageConfigGenerated>(LoadNextStage);
            _signalBus.Unsubscribe<SignalKnifeHitAnotherKnife>(LoadGameLooseState);
        }

        private async void LoadNextStage()
        {
            _stageTextFactory.Destroy();
            await Task.Delay(750);
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() {State = new LoadStageState()});
        }

        private void LoadGameLooseState()
        {
            _stageTextFactory.Destroy();
            _scoreUIFactory.Destroy();
            
            TryToSaveGameProgress();
            _signalBus.Fire<SignalChangedState>(new SignalChangedState() {State = new GameLooseState()});
        }

        private void TryToSaveGameProgress()
        {
            _gameProgressService.MakeTransaction(new TryChangeMaxScoreTransaction(_currentScoreService.Score));
            _gameProgressService.MakeTransaction(new TryChangeMaxStageTransaction(_stageConfigGeneratorService.GetCurrentStageNumber()));
            _gameProgressSaver.Save();
        }

    }
}