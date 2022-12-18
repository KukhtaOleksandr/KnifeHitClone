using UnityEngine;
using DG.Tweening;

namespace Stump.RotationMechanics
{
    public class AccelerationRotationMechanic : IRotationMechanic
    {
        public void Rotate(float speed, int direction, Transform stump)
        {
            float duration = 7 / speed;

            //stump.DORotate(new Vector3(0, 0, 360), duration).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.InBack);
            stump.DORotate(new Vector3(0, 0, 450*direction), duration).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.InFlash);
        }
        
        public void StopRotate(Transform stump)
        {
            stump.DOKill();
        }
    }
}