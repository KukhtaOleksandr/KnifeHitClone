using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
using TMPro;
using UI.TextTypes;

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
        [Inject (Id = "bold")]
        private TMP_FontAsset _boldFontAsset;
        [Inject (Id = "regular")]
        private TMP_FontAsset _regularFontAsset;

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
                
                ReassignFonts();
            }
        }

        private void ReassignFonts()
        {
            foreach (BoldText text in _panel.GetComponentsInChildren<BoldText>())
            {
                text.gameObject.GetComponent<TextMeshProUGUI>().font = _boldFontAsset;
            }
            foreach (RegularText text in _panel.GetComponentsInChildren<RegularText>())
            {
                text.gameObject.GetComponent<TextMeshProUGUI>().font = _regularFontAsset;
            }
        }

        public void Destroy()
        {
            Addressables.Release(_handle);
            GameObject.Destroy(_panel);
        }
    }
}