using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace UI.Factories.Global
{
    public class SettingsUIFactory : ISettingsUIFactory
    {
        [Inject]
        private AssetReference _settingsPanelPrefab;
        [Inject]
        private Canvas _parent;
        [Inject]
        private DiContainer _container;

        private AsyncOperationHandle<GameObject> _handle;
        private GameObject _panel;
        public async void Create()
        {
            _handle = _settingsPanelPrefab.LoadAssetAsync<GameObject>();
            await _handle.Task;
            if (_handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject result = _handle.Result;

                _panel = _container.InstantiatePrefab(result, _parent.transform);
            }
        }

        public void Destroy()
        {
            Addressables.Release(_handle);
            GameObject.Destroy(_panel);
            
        }
    }
}