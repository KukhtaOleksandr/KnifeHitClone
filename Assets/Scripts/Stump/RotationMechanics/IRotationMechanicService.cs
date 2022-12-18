using Stages;
using UnityEngine;

namespace Stump.RotationMechanics
{
    public interface IRotationMechanicService
    {
        void Rotate(float speed, int direction, RotationType rotationType, Transform stump);
        void StopRotation(Transform stump);
    }
}