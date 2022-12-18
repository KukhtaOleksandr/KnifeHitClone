using System.Threading.Tasks;
using System.Collections.Generic;
using Global.Services.Audio;
using ScriptableObjects.Base;
using UnityEngine;
using Zenject;

namespace Global.Audio
{
    public class AudioSourceFactory
    {
        [Inject]
        readonly IAudioProvider _audioProvider;

        private List<AudioSource> _activeSounds;

        public AudioSourceFactory()
        {
            _activeSounds = new List<AudioSource>();
        }

        public AudioSource Create(AudioTypes audioType)
        {
            Sound sound = _audioProvider.Get(audioType);
            GameObject gameObject =new GameObject($"{audioType.ToString()}Audio");

            if(sound.DontDestroyOnSceneLoad)
                Object.DontDestroyOnLoad(gameObject);

            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = sound.AudioClip;

            DestroySourceOnCompletion(source);
            return source;
        }

        private async void DestroySourceOnCompletion(AudioSource source)
        {
            int delay = (int)(source.clip.length*1000);
            await Task.Delay(delay);
            
            if(source.gameObject!=null)
                GameObject.Destroy(source.gameObject);
        }
    }
}