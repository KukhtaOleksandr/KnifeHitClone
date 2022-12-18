using System;
using Knife;
using Zenject;

namespace Architecure.Services
{
    public class CurrentKnivesAvailableService : ICurrentKnivesAvailableService, IInitializable, IDisposable
    {
        [Inject]
        readonly SignalBus _signalBus;
        private int _knivesAvailable;

        public int Knives { get => _knivesAvailable; }

        public void Initialize()
        {
            _signalBus.Subscribe<SignalKnifeThrow>(HandleKnivesChange);
            _signalBus.Subscribe<ISignalNewStageConfigGenerated>(ResetKnives);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalKnifeThrow>(HandleKnivesChange);
            _signalBus.Unsubscribe<ISignalNewStageConfigGenerated>(ResetKnives);
        }

        private void HandleKnivesChange()
        {
            _knivesAvailable--;
        }

        private void ResetKnives(ISignalNewStageConfigGenerated args)
        {
            _knivesAvailable = args.StageConfig.KnivesToSpawn;
        }
    }
}