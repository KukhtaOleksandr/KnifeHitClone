using System;
using Global.Audio;
using Global.Services.Settings;
using Zenject;

namespace Global.Services.Audio
{
    public class AudioService : IAudioService, IInitializable, IDisposable
    {
        [Inject]
        private AudioSourceFactory _audioSourceFactory;
        [Inject]
        private ISettingsService _settingsService;
        [Inject]
        private SignalBus _signalBus;

        private bool _isSoundsOn;


        public void Initialize()
        {
            _signalBus.Subscribe<SignalSoundsStateChanged>(ChangeSoundState);
            _isSoundsOn = _settingsService.GetSoundState();
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalSoundsStateChanged>(ChangeSoundState);
        }

        public void Play(AudioTypes audioType)
        {
            if(_isSoundsOn)
            {
                var source = _audioSourceFactory.Create(audioType);
                source.Play();
            }
        }

        private void ChangeSoundState(SignalSoundsStateChanged args)
        {
            _isSoundsOn = args.IsOn;
        }

    }
}