using UnityEngine;
using Zenject;
using TMPro;
using DG.Tweening;

namespace UI.Factories
{
    public class StageTextFactory
    {
        private DiContainer _container;
        private StageTextUI _stageTextUI;
        private Canvas _parent;
        private TextMeshProUGUI text;

        public StageTextFactory(DiContainer container, StageTextUI stageTextUI, Canvas parent)
        {
            _container = container;
            _stageTextUI = stageTextUI;
            _parent = parent;
        }

        public void Create()
        {
            text = _container.InstantiatePrefabForComponent<StageTextUI>(_stageTextUI,_parent.transform).GetComponent<TextMeshProUGUI>();
            text.DOFade(1, 0.5f);
        }

        public void Destroy()
        {
            text.DOFade(0, 0.5f);
            GameObject.Destroy(text.gameObject,0.5f);
        }
    }
}