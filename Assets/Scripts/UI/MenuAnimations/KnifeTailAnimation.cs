using DG.Tweening;
using UnityEngine;

public class KnifeTailAnimation : MonoBehaviour
{
    private const float Scale = 1.05f;
    private const float Duration = 0.8f;
    private RectTransform _trail;

    void Start()
    {
        _trail = GetComponent<RectTransform>();
        Sequence mySequence = DOTween.Sequence();
        TweenParams tweenParams = new TweenParams().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Flash);
        mySequence.Append(_trail.DOScaleY(Scale, Duration).SetRelative().SetAs(tweenParams));
        mySequence.Append(_trail.DOScaleY(-Scale, Duration).SetRelative().SetAs(tweenParams));
        mySequence.SetAs(tweenParams);
    }
}
