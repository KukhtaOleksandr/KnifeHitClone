using Global.Progress.Data;
using Global.Progress.Data.Transactions;
using Zenject;

namespace Global.Progress
{
    public partial class GameProgressService : IGameProgressLoader, IGameProgressSaver, IGameProgressService
    {
        private readonly SignalBus _signalBus;
        private GameProgress _gameProgress;

        public GameProgress GameProgress => _gameProgress;

        public GameProgressService(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void MakeTransaction(GameProgressTransaction transaction)
        {
            transaction.Execute(_gameProgress);
        }

    }
}
