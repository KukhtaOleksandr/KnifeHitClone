using System.Collections.Generic;
using DG.Tweening;
using Stages;
using UnityEngine;
using Zenject;

namespace Stump.RotationMechanics
{
    public class RotationMechanicService : IRotationMechanicService, IInitializable
    {
        Dictionary<RotationType, IRotationMechanic> _rotationMechanics;
        RotationType _rotationType;

        public void Initialize()
        {
            _rotationMechanics = new Dictionary<RotationType, IRotationMechanic>();
            _rotationMechanics.Add(RotationType.Linear, new LinearRotationMechanic());
            _rotationMechanics.Add(RotationType.WithAcceleration, new AccelerationRotationMechanic());
            _rotationMechanics.Add(RotationType.InBack, new InBackRotationMechanic());
        }

        public void Rotate(float speed, int direction, RotationType rotationType, Transform stump)
        {
            _rotationMechanics[rotationType].Rotate(speed, direction, stump.transform);
        }

        public void StopRotation(Transform stump)
        {
            stump.transform.DOKill();
        }

    }

    public enum RotationType
    {
        Linear,
        WithAcceleration,
        InBack
    }
}