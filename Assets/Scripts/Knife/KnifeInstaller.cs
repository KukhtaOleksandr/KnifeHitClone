using Knife.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Knife
{
    public class KnifeInstaller: MonoInstaller
    {
        [SerializeField] Knife _knifePrefab;
        [SerializeField] Image _knifeIconPrefab;
        [SerializeField] Transform _iconsParent;
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalKnifeHitStump>();
            Container.DeclareSignal<SignalFinalKnifeHitStump>();
            Container.DeclareSignal<SignalKnifeHitAnotherKnife>();
            Container.DeclareSignal<SignalKnivesUICreated>();

            Container.BindInstance(_knifePrefab).AsSingle().WhenInjectedInto<KnifeFactory>();
            Container.BindInstance(_knifeIconPrefab).AsSingle().WhenInjectedInto<KnifeUIFactory>();
            Container.BindInstance(_iconsParent).AsSingle().WhenInjectedInto<KnifeUIFactory>();
            Container.Bind<KnifeFactory>().AsSingle();
            Container.Bind<KnifeUIFactory>().AsSingle().NonLazy();

            Container.BindInterfacesTo<KnifeSpawner>().AsSingle().NonLazy();
            Container.BindInitializableExecutionOrder<KnifeSpawner>(-1);
            
        }
    }
}