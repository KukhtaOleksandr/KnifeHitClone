using UnityEngine;

namespace Stump.RotationMechanics
{
    public interface IRotationMechanic
    {
        void Rotate(float speed, int Direction, Transform stump);
        void StopRotate(Transform stump);
    }
}