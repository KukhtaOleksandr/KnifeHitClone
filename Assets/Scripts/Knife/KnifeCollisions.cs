using Architecure.Services;
using Global.Audio;
using Global.Services.Audio;
using Stump.RotationMechanics;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Knife
{
    public class KnifeCollisions : MonoBehaviour
    {
        public UnityAction KnifeHitAnotherKnife { get; set;}

        [Inject]
        readonly SignalBus _signalBus;
        [Inject] ICurrentKnivesAvailableService _availableKnives;
        [Inject] IAudioService _audioService;

        private bool _enteredOnce;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<StumpRotation>(out StumpRotation stumpRotation) && _enteredOnce == false)
            {
                transform.SetParent(stumpRotation.transform);

                if (_availableKnives.Knives > 0)
                {
                    _audioService.Play(AudioTypes.WoodHit);
                    _signalBus.Fire<SignalKnifeHitStump>();
                }
                else
                {
                    _audioService.Play(AudioTypes.WoodBreak);
                    _signalBus.Fire<SignalFinalKnifeHitStump>();
                }

                DestroyComponent();
            }
            if (other.TryGetComponent<Knife>(out Knife knife) && knife.IsCollisibleWithKnife && _enteredOnce == false)
            {
                _audioService.Play(AudioTypes.KnifeHit);
                _signalBus.Fire<SignalKnifeHitAnotherKnife>();
                KnifeHitAnotherKnife?.Invoke();

                DestroyComponent();
            }
        }

        private void DestroyComponent()
        {
            _enteredOnce = true;
            Destroy(this);
        }
    }
}