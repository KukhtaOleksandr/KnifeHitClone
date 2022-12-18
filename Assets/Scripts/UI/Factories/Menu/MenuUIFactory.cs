using UnityEngine;
using Zenject;

namespace UI.Factories
{
    public class MenuUIFactory
    {
        [Inject]
        private DiContainer _container;
        [Inject]
        private Canvas _parent;
        [Inject]
        private KnifeHitMenuUIFactory _knifeHitMenuUIFactory;
        [Inject]
        private SettingsButtonUIFactory _settingsButtonUIFactory;
        [Inject]
        private StageScoreUIFactory _stageScoreUIFactory;
        [Inject]
        private PlayButtonUiFactory _playButtonUiFactory;

        public void Create()
        {
            _playButtonUiFactory.Create(_parent,_container);
            _settingsButtonUIFactory.Create(_parent,_container);
            _knifeHitMenuUIFactory.Create(_parent,_container);
            _stageScoreUIFactory.Create(_parent,_container);
        }
    }
}