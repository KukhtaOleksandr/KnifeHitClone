using System;
using Architecure.Services;
using UnityEngine;
using Zenject;

namespace Knife
{
    public class KnifeSpawner : IInitializable, IDisposable
    {
        readonly KnifeFactory _knifeFactory;
        readonly SignalBus _signalBus;
        readonly ICurrentKnivesAvailableService _currentKnivesAvailableService;

        public KnifeSpawner(KnifeFactory knifeFactory, SignalBus signalBus, IStageConfigGeneratorService stageConfigGeneratorService, 
                            ICurrentKnivesAvailableService currentKnivesAvailableService)
        {
            _knifeFactory = knifeFactory;
            _signalBus = signalBus;
            _currentKnivesAvailableService = currentKnivesAvailableService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<SignalKnifeHitStump>(SpawnKnife);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalKnifeHitStump>(SpawnKnife);
        }

        private void SpawnKnife()
        {
            if (_currentKnivesAvailableService.Knives > 0)
            {
                _knifeFactory.CreateKnife();
            }
        }
    }
}