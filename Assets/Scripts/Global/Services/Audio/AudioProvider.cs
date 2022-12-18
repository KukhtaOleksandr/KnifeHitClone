using System.Collections.Generic;
using Architecure.Services.Audio;
using Global.Audio;
using ScriptableObjects.Base;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Global.Services.Audio
{
    public class AudioProvider : IAudioProvider, IInitializable
    {
        [Inject]
        readonly List<Sound> _projectSounds;
        [Inject]
        readonly List<AssetReference> _playModeSounds;
        [Inject]
        readonly SignalBus _signalBus;

        private Dictionary<AudioTypes, Sound> _soundsDictionary;

        public void Initialize()
        {
            _soundsDictionary = new Dictionary<AudioTypes, Sound>();
            foreach (Sound sound in _projectSounds)
            {
                _soundsDictionary.Add(sound.AudioType, sound);
            }
            _signalBus.Subscribe<SignalPlaySoundsLoaded>(PlaySoundsLoaded);
        }

        public Sound Get(AudioTypes type)
        {
            if (_soundsDictionary == null)
                return null;
            return _soundsDictionary[type];
        }


        private void PlaySoundsLoaded(SignalPlaySoundsLoaded args)
        {
            foreach (Sound sound in args.Sounds)
            {
                _soundsDictionary.Add(sound.AudioType, sound);
            }
            _signalBus.Unsubscribe<SignalPlaySoundsLoaded>(PlaySoundsLoaded);
        }

    }
}