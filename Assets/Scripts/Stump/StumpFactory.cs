using Architecure.Services;
using UnityEngine;
using Zenject;

namespace Stump
{
    public class StumpFactory
    {
        readonly IStageConfigGeneratorService _configGeneratorService;
        readonly DiContainer _container;
        readonly Vector3 _position;

        private Stump _stump;

        public StumpFactory(DiContainer container, IStageConfigGeneratorService configGeneratorService, Vector3 position )
        {
            _container = container;
            _configGeneratorService = configGeneratorService;
            _position = position;
        }

        public void CreateStump()
        {
            Stump prefab = _configGeneratorService.GetConfig().StumpPrefab;
            _stump = _container.InstantiatePrefabForComponent<Stump>(prefab, _position, Quaternion.identity, null);
        }

        public void DestroyStump()
        {
            GameObject.Destroy(_stump.gameObject);
        }
    }
}