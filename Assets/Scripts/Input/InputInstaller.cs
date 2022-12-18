using UnityEngine;
using Zenject;

namespace Input
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private GameInput _gameInput;
        public override void InstallBindings()
        {
            Container.BindInstance(_gameInput).AsSingle().WhenInjectedInto<GameInputFactory>();
            Container.Bind<GameInputFactory>().AsSingle();
            Container.DeclareSignal<MouseClickedSignal>();
        }
    }
}