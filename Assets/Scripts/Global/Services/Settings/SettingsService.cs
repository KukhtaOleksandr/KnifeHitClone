using System;
using Zenject;
using UnityEngine;
using Extensions;

namespace Global.Services.Settings
{
    public class SettingsService : IInitializable, IDisposable, ISettingsService
    {
        [Inject]
        readonly SignalBus _signalBus;

        private bool _soundState;


        public void Initialize()
        {
            int soundToggleOn = true.ToInt();
            _soundState = PlayerPrefs.GetInt("SoundToggleOn", soundToggleOn).ToBool();

            _signalBus.Subscribe<SignalSoundsToggleChanged>(OnSoundsToggleChanged);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalSoundsToggleChanged>(OnSoundsToggleChanged);
        }

        public bool GetSoundState()
        {
            return _soundState;
        }

        private void OnSoundsToggleChanged(SignalSoundsToggleChanged args)
        {
            _soundState=args.IsOn;
            _signalBus.Fire<SignalSoundsStateChanged>(new SignalSoundsStateChanged() { IsOn = args.IsOn });

            SaveSoundState(args);
        }

        private void SaveSoundState(SignalSoundsToggleChanged args)
        {
            if (args.IsOn)
                PlayerPrefs.SetInt("SoundToggleOn", true.ToInt());
            else
                PlayerPrefs.SetInt("SoundToggleOn", false.ToInt());
        }

    }

    public interface ISettingsService
    {
        bool GetSoundState();
    }
}