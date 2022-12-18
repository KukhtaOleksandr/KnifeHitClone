using UnityEngine;
using Zenject;

namespace Input
{
    public class GameInputFactory
    {
        [Inject] 
        private DiContainer _container;
        [Inject] 
        private GameInput _gameInputPrefab;

        private GameInput _gameInput;

        public void Create()
        {
            _gameInput=_container.InstantiatePrefabForComponent<GameInput>(_gameInputPrefab);
        }

        public void Destroy() 
        {
            GameObject.Destroy(_gameInput.gameObject);
        }
    }
}