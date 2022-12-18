using DG.Tweening;
using UnityEngine;

public class HitMenuAnimation : MonoBehaviour
{
    private const int Offset = 20;
    private const int Duration = 1;
    private RectTransform _hit;

    void Start()
    {
        _hit = GetComponent<RectTransform>();
        Sequence mySequence = DOTween.Sequence();
        TweenParams tweenParams = new TweenParams().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        mySequence.Append(_hit.DOAnchorPosX(-Offset, Duration).SetRelative().SetAs(tweenParams));
        mySequence.Append(_hit.DOAnchorPosX(Offset, Duration).SetRelative().SetAs(tweenParams));
        mySequence.SetAs(tweenParams);
    }
}
