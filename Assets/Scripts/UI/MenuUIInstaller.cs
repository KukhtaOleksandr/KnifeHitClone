using TMPro;
using UI.ButtonHandlers;
using UI.Factories;
using UI.Factories.Global;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace UI
{
    public class MenuUIInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private AssetReference _settingsPanel;
        [SerializeField] private GameObject _knifeHitPrefab;
        [SerializeField] private GameObject _settingButtonPrefab;
        [SerializeField] private GameObject _playButtonPrefab;
        [SerializeField] private GameObject _stageScorePrefab;
        [SerializeField] private TMP_FontAsset _boldFont;
        [SerializeField] private TMP_FontAsset _regularFont;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_mainCanvas).AsSingle();
            
            Container.DeclareSignal<SignalPlayButtonClicked>();
            

            BindFactories();
        }

        private void BindFactories()
        {
            Container.BindInstance(_settingsPanel).AsTransient().WhenInjectedInto<SettingsUIFactory>();
            Container.BindInstance(_boldFont).WithId("bold").AsTransient().WhenInjectedInto<SettingsUIFactory>();
            Container.BindInstance(_regularFont).WithId("regular").AsTransient().WhenInjectedInto<SettingsUIFactory>();
            Container.Bind<ISettingsUIFactory>().To<SettingsUIFactory>().AsCached();

            Container.BindInstance(_knifeHitPrefab).AsTransient().WhenInjectedInto<KnifeHitMenuUIFactory>();
            Container.Bind<KnifeHitMenuUIFactory>().AsSingle();

            Container.BindInstance(_settingButtonPrefab).AsTransient().WhenInjectedInto<SettingsButtonUIFactory>();
            Container.Bind<SettingsButtonUIFactory>().AsSingle();

            Container.BindInstance(_playButtonPrefab).AsTransient().WhenInjectedInto<PlayButtonUiFactory>();
            Container.Bind<PlayButtonUiFactory>().AsSingle();

            Container.BindInstance(_stageScorePrefab).AsTransient().WhenInjectedInto<StageScoreUIFactory>();
            Container.Bind<StageScoreUIFactory>().AsSingle();

            Container.Bind<MenuUIFactory>().AsSingle();
        }

    }
}