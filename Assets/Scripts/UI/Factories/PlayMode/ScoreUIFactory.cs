using UnityEngine;
using Zenject;

namespace UI.Factories
{
    public class ScoreUIFactory
    {
        [Inject]
        readonly ScoreUI _scoreUIPrefab;
        [Inject]
        readonly DiContainer _container;
        [Inject]
        readonly Canvas _parent;

        private GameObject _score;

        public void Create()
        {
            _score = _container.InstantiatePrefabForComponent<ScoreUI>(_scoreUIPrefab,_parent.transform).gameObject;
        }

        public void Destroy()
        {
            GameObject.Destroy(_score);
        }
    }
}