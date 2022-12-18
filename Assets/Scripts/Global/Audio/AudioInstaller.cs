using System.Collections.Generic;
using Zenject;
using UnityEngine;
using ScriptableObjects.Base;
using UnityEngine.AddressableAssets;
using Global.Services.Audio;

namespace Global.Audio
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private List<Sound> _sounds;
        [SerializeField] private List<AssetReference> _playModeSounds;
        public override void InstallBindings()
        {
            Container.BindInstance(_sounds).AsSingle();
            Container.BindInstance(_playModeSounds).AsSingle().WhenInjectedInto<IPlayAudioLoaderService>();
            Container.Bind<AudioSourceFactory>().AsSingle();
        }
    }
}