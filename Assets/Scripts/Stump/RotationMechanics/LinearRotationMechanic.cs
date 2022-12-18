using UnityEngine;
using DG.Tweening;

namespace Stump.RotationMechanics
{
    public class LinearRotationMechanic : IRotationMechanic
    {
        public void Rotate(float speed, int direction, Transform stump)
        {
            float duration = 1.5f / speed;
            stump.DORotate(new Vector3(0, 0, 90*direction), duration).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
        
        public void StopRotate(Transform stump)
        {
            stump.DOKill();
        }
    }
}