using System.Collections.Generic;
using Stages;
using UnityEngine;
using Zenject;

namespace Architecure.Services
{
    public class ServicesInstaller : MonoInstaller
    {
        [SerializeField] List<StageConfig> _stageConfigs;
        public override void InstallBindings()
        {
            Container.DeclareSignalWithInterfaces<SignalNewStageConfigGenerated>();
            Container.DeclareSignal<SignalNewStageConfigGenerated>();
            Container.DeclareSignal<SignalScoreChanged>();
            

            Container.BindInstance(_stageConfigs).AsSingle().WhenInjectedInto<StageConfigGeneratorService>();
            Container.BindInterfacesTo<StageConfigGeneratorService>().AsSingle();
            Container.BindInterfacesTo<CurrentKnivesAvailableService>().AsSingle();
            Container.BindInterfacesTo<CurrentScoreService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PlayAudioLoaderService>().AsSingle().NonLazy();

            Container.BindInitializableExecutionOrder<StageConfigGeneratorService>(-10);
            Container.BindInitializableExecutionOrder<CurrentKnivesAvailableService>(-8);

        }
    }
}