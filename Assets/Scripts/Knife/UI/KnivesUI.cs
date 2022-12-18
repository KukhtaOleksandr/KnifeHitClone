using System.Linq;
using System.Collections.Generic;
using DG.Tweening;
using Input;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Knife.UI
{
    public class KnivesUI : MonoBehaviour
    {
        [SerializeField] private Color _nonActiveColor;

        [Inject]
        private SignalBus _signalBus;
        [Inject]
        private KnifeUIFactory _knifeUIFactory;

        private List<Image> _knives;
        private int _lastIndex;

        void Start()
        {
            _signalBus.Subscribe<SignalKnivesUICreated>(KnivesCreated);
            _signalBus.Subscribe<SignalKnifeThrow>(OnKnifeThrow);
            _signalBus.Subscribe<SignalFinalKnifeHitStump>(DestroyKnives);
            _signalBus.Subscribe<SignalKnifeHitAnotherKnife>(DestroyKnives);

            _lastIndex=0;
            _knives = GetComponentsInChildren<Image>().ToList();
            _knives.Reverse();
        }

        void OnDestroy()
        {
            _signalBus.Unsubscribe<SignalKnivesUICreated>(KnivesCreated);
            _signalBus.Unsubscribe<SignalKnifeThrow>(OnKnifeThrow);
            _signalBus.Unsubscribe<SignalFinalKnifeHitStump>(DestroyKnives);
            _signalBus.Unsubscribe<SignalKnifeHitAnotherKnife>(DestroyKnives);
        }

        private void DestroyKnives()
        {
            _knifeUIFactory.DestroyAllWithFade();
        }

        private void KnivesCreated(SignalKnivesUICreated args)
        {
            _lastIndex=0;
            _knives = args.Knives;
        }

        private void OnKnifeThrow()
        {
            if (_knives.Count > 0)
            {
                _knives[_lastIndex].DOColor(_nonActiveColor, 0.2f);
                _lastIndex++;
            }
        }

    }
}