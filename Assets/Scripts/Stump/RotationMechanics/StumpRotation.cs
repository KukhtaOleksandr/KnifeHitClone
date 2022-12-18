using Architecure.Services;
using Knife;
using Stages;
using UnityEngine;
using Zenject;

namespace Stump.RotationMechanics
{
    public class StumpRotation : MonoBehaviour
    {
        [Inject]
        readonly IRotationMechanicService _rotationMechanicService;
        [Inject]
        readonly SignalBus _signalBus;
        [Inject]
        readonly IStageConfigGeneratorService _stageConfigGeneratorService;


        void Start()
        {
            _signalBus.Subscribe<SignalKnifeHitAnotherKnife>(StopRotation);
            StartRotation();
        }

        void OnDestroy()
        {
            _signalBus.Unsubscribe<SignalKnifeHitAnotherKnife>(StopRotation);
        }

        private void StartRotation()
        {
            float speed = _stageConfigGeneratorService.GetConfig().Speed;
            RotationType rotationType = _stageConfigGeneratorService.GetConfig().RotationType;
            int direction = _stageConfigGeneratorService.GetConfig().Direction;
            _rotationMechanicService.Rotate(speed, direction, rotationType, stump: this.transform);
        }

        private void StopRotation()
        {
            _rotationMechanicService.StopRotation(this.transform);
        }
    }
}