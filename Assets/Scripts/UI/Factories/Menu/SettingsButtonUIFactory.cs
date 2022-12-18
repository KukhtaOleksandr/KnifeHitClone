using UnityEngine;
using Zenject;

namespace UI.Factories
{
    public class SettingsButtonUIFactory
    {
        [Inject] 
        private GameObject _settingsButtonPrefab;

        public void Create(Canvas parent, DiContainer container)
        {
            container.InstantiatePrefab(_settingsButtonPrefab, parent.transform);
        }

    }
}