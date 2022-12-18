using System;
using System.Collections.Generic;
using Stages;
using Zenject;
using Knife;

namespace Architecure.Services
{
    public class StageConfigGeneratorService : IStageConfigGeneratorService, IInitializable, IDisposable
    {
        [Inject]
        private List<StageConfig> _stageConfigs;
        [Inject]
        readonly SignalBus _signalBus;

        private int _currentStageNumber = 1;

        private Stage _currentStage = Stage.First;
        private StageConfig _currentStageConfig;

        public void Initialize()
        {
            _signalBus.Subscribe<SignalFinalKnifeHitStump>(CreateNextStageConfig);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalFinalKnifeHitStump>(CreateNextStageConfig);
        }

        public int GetCurrentStageNumber()
        {
            return _currentStageNumber;
        }

        public StageConfig GetConfig()
        {
            return _currentStageConfig;
        }

        public void Reset()
        {
            _currentStageNumber = 1;
            _currentStage = Stage.First;
            _currentStageConfig = GetConfigInternal();
            _signalBus.AbstractFire<SignalNewStageConfigGenerated>(new SignalNewStageConfigGenerated()
            { StageNumber = _currentStageNumber, StageConfig = _currentStageConfig });
        }

        private void CreateNextStageConfig()
        {
            _currentStageNumber++;

            if (((int)_currentStage) < _stageConfigs.Count)
                _currentStage++;
            else
                _currentStage = Stage.Twelfth;

            _currentStageConfig = GetConfigInternal();
            _signalBus.AbstractFire<SignalNewStageConfigGenerated>(new SignalNewStageConfigGenerated()
            { StageNumber = _currentStageNumber, StageConfig = _currentStageConfig });
        }


        private StageConfig GetConfigInternal()
        {
            List<StageConfig> currentStageConfigs = new List<StageConfig>();
            GetCurrentStageConfigs(currentStageConfigs);

            return currentStageConfigs[UnityEngine.Random.Range(0, currentStageConfigs.Count)];
        }

        private void GetCurrentStageConfigs(List<StageConfig> currentStageConfigs)
        {
            foreach (var stageConfig in _stageConfigs)
            {
                if (stageConfig.Stage == _currentStage)
                    currentStageConfigs.Add(stageConfig);
            }
        }

    }
}