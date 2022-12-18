using UnityEngine;
using DG.Tweening;

public class KnifeMenuAnimation : MonoBehaviour
{
    private const int Offset = 20;
    private const int Duration = 1;
    private RectTransform _knife;

    void Start()
    {
        _knife = GetComponent<RectTransform>();
        Sequence mySequence = DOTween.Sequence();
        TweenParams tweenParams = new TweenParams().SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        mySequence.Append(_knife.DOAnchorPosX(Offset, Duration).SetRelative().SetAs(tweenParams));
        mySequence.Append(_knife.DOAnchorPosX(-Offset,Duration).SetRelative().SetAs(tweenParams));
        mySequence.SetAs(tweenParams);
    }
}
