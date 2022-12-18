using DG.Tweening;
using UnityEngine;

namespace Stump.RotationMechanics
{
    public class InBackRotationMechanic : IRotationMechanic
    {
        public void Rotate(float speed, int direction, Transform stump)
        {
            float duration = 7 / speed;

            stump.DORotate(new Vector3(0, 0, 360), duration).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.InBack);
        }

        public void StopRotate(Transform stump)
        {
            stump.DOKill();
        }

    }
}