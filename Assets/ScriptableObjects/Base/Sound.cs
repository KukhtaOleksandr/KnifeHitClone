using Global.Audio;
using UnityEngine;

namespace ScriptableObjects.Base
{
    [CreateAssetMenu(menuName = "Sounds/Sound")]
    public class Sound : ScriptableObject
    {
        [SerializeField] private AudioClip _audio;
        [SerializeField] private AudioTypes _audioType;
        [SerializeField] private bool _dontDestroyOnLoad;

        public AudioClip AudioClip { get => _audio; }
        public AudioTypes AudioType { get => _audioType; }
        public bool DontDestroyOnSceneLoad { get => _dontDestroyOnLoad; }
    }

}