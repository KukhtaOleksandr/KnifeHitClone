using System;
using Knife;
using Zenject;

namespace Architecure.Services
{
    public class CurrentScoreService : IInitializable, IDisposable, ICurrentScoreService
    {
        [Inject]
        private SignalBus _signalBus;

        private int _score;

        public int Score { get => _score; }

        public void Initialize()
        {
            _score = 0;
            _signalBus.Subscribe<SignalKnifeHitStump>(SetScore);
            _signalBus.Subscribe<SignalFinalKnifeHitStump>(SetScore);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalKnifeHitStump>(SetScore);
            _signalBus.Unsubscribe<SignalFinalKnifeHitStump>(SetScore);
        }

        public void ResetScore()
        {
            _score = 0;
        }

        private void SetScore()
        {
            _score++;
            _signalBus.Fire<SignalScoreChanged>(new SignalScoreChanged() { Score = _score });
        }
    }
}