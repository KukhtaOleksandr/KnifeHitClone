using System;
using System.Collections.Generic;
using Input;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;
using Architecure.Services;
using UnityEngine.Events;

namespace Knife.UI
{
    public class KnifeUIFactory
    {
        [Inject]
        readonly SignalBus _signalBus;
        readonly Transform _parent;
        readonly Image _knifeIconPrefab;
        readonly IStageConfigGeneratorService _stageConfigGeneratorService;

        private List<Image> _swords;
        private int _knivesToSpawn;

        public KnifeUIFactory(Image knifeIconPrefab, IStageConfigGeneratorService stageConfigGeneratorService, Transform parent)
        {
            _knifeIconPrefab = knifeIconPrefab;
            _stageConfigGeneratorService = stageConfigGeneratorService;
            _parent = parent;
        }

        public void Create()
        {
            _knivesToSpawn = _stageConfigGeneratorService.GetConfig().KnivesToSpawn;
            _swords = new List<Image>();
            for (int i = 0; i < _knivesToSpawn; i++)
            {
                _swords.Add(GameObject.Instantiate(_knifeIconPrefab, _parent));
                _swords[i].DOFade(1,0.3f);
            }
            _swords.Reverse();
            _signalBus.Fire(new SignalKnivesUICreated() { Knives = _swords });
        }

        public void DestroyAll()
        {
            foreach (var sword in _swords)
            {
                GameObject.Destroy(sword.gameObject);
            }
            _swords.Clear();
        }

        public void DestroyAllWithFade()
        {
            foreach (var sword in _swords)
            {
                sword.DOFade(0,0.3f).OnComplete(()=>{GameObject.Destroy(sword.gameObject);});
            }
            _swords.Clear();
        }

    }
}
