using DG.Tweening;
using Input;
using UnityEngine;
using Zenject;

namespace Knife
{
    public class Throw : MonoBehaviour
    {
        [Inject]
        readonly SignalBus _signalBus;
        [Inject]
        readonly Vector3 _stumpPosition;

        private Vector3 _offset = new Vector3(0, -1.58f, 0);

        private const float Duration = 0.13f;

        public void Start()
        {
            _signalBus.Subscribe<MouseClickedSignal>(ThrowKnife);
        }

        void OnDestroy()
        {
            _signalBus.Unsubscribe<MouseClickedSignal>(ThrowKnife);
        }

        private void ThrowKnife()
        {
            _signalBus.Fire<SignalKnifeThrow>();
            transform.DOMove(_stumpPosition + _offset, Duration).SetEase(Ease.Flash);
            Destroy(this);
        }


    }
}