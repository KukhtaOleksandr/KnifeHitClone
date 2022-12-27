using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UI.TextTypes;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace UI.Factories
{
    public class GameLoosePanelFactory
    {
        private const float SpawnPositionY = -2000;
        private const float MovePositionY = 0;

        private AssetReference _gameLoosePanelReference;
        private DiContainer _container;
        private Canvas _gameLoosePanelParent;

        private GameObject _gameLoosePanel;
        private RectTransform _panel;
        private AsyncOperationHandle<GameObject> handle;
        private TMP_FontAsset _boldFontAsset;

        public GameLoosePanelFactory(AssetReference gameLoosePanelReference, Canvas gameLoosePanelParent, DiContainer container, TMP_FontAsset boldFontAsset)
        {
            _gameLoosePanelReference = gameLoosePanelReference;
            _gameLoosePanelParent = gameLoosePanelParent;
            _container = container;
            _boldFontAsset = boldFontAsset;
        }

        public async Task CreatePanel()
        {
            handle = _gameLoosePanelReference.LoadAssetAsync<GameObject>();
            await handle.Task;
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject result = handle.Result;

                _panel = _container.InstantiatePrefab(result, _gameLoosePanelParent.transform).GetComponent<RectTransform>();

                ReassignFonts();
                AnimatePanelCreation();
            }
        }

        private void ReassignFonts()
        {
            foreach (BoldText text in _panel.GetComponentsInChildren<BoldText>())
            {
                text.gameObject.GetComponent<TextMeshProUGUI>().font = _boldFontAsset;
            }
        }

        private void AnimatePanelCreation()
        {
            _panel.DOAnchorPosY(SpawnPositionY, 0);
            _panel.localScale = new Vector3(1, 1, 1);
            _panel.DOAnchorPosY(MovePositionY, 0.5f);
        }

        public async Task DestroyPanel()
        {
            _panel.DOAnchorPosY(SpawnPositionY, 0.3f);
            await Task.Delay(300);
            GameObject.Destroy(_panel.gameObject);
            Addressables.Release(handle);
        }
    }
}