using UI.ButtonHandlers;
using UI.Factories;
using UI.Factories.Global;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using TMPro;

namespace UI
{
    public class PlayModeUIInstaller : MonoInstaller
    {
        [SerializeField] private AssetReference _settingsPanel;
        [SerializeField] private AssetReference _gameLoosePanel;
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private StageTextUI _stageTextPrefab;
        [SerializeField] private ScoreUI _scoreUIPrefab;
        [SerializeField] private TMP_FontAsset _boldFont;
        [SerializeField] private TMP_FontAsset _regularFont;
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalRestartButtonClicked>();
            Container.DeclareSignal<SignalHomeButtonClicked>();

            Container.BindInstance(_mainCanvas).AsSingle();
            Container.BindInstance(_stageTextPrefab).AsSingle();
            Container.BindInstance(_scoreUIPrefab).AsSingle();
            Container.BindInstance(_gameLoosePanel).AsTransient().WhenInjectedInto<GameLoosePanelFactory>();
            Container.BindInstance(_boldFont).AsTransient().WhenInjectedInto<GameLoosePanelFactory>();
            Container.BindInstance(_settingsPanel).AsTransient().WhenInjectedInto<SettingsUIFactory>();
            Container.BindInstance(_boldFont).WithId("bold").AsTransient().WhenInjectedInto<SettingsUIFactory>();
            Container.BindInstance(_regularFont).WithId("regular").AsTransient().WhenInjectedInto<SettingsUIFactory>();
            
            Container.Bind<ISettingsUIFactory>().To<SettingsUIFactory>().AsCached();
            Container.Bind<GameLoosePanelFactory>().AsSingle();
            Container.Bind<StageTextFactory>().AsSingle();
            Container.Bind<ScoreUIFactory>().AsSingle();
        }
    }
}