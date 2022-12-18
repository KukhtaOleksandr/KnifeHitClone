using Knife;
using Stump.RotationMechanics;
using UnityEngine;
using Zenject;

namespace Stump
{
    public class StumpInstaller : MonoInstaller
    {
        readonly Vector3 _spawnPosition = new Vector3(0,1.2f,0);
        public override void InstallBindings()
        {
            Container.BindInstance(_spawnPosition).AsCached().WhenInjectedInto<StumpFactory>();
            Container.BindInstance(_spawnPosition).AsCached().WhenInjectedInto<Throw>();
            Container.BindInterfacesTo<RotationMechanicService>().AsSingle();

            Container.Bind<StumpFactory>().AsSingle().NonLazy();
        }
    }
}