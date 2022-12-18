using DG.Tweening;
using Knife;
using UnityEngine;
using Zenject;

public class StumpHitAnimation : MonoBehaviour
{
    [Inject]
    readonly SignalBus _signalBus;

    public void Start()
    {
        _signalBus.Subscribe<SignalKnifeHitStump>(AnimateStumpHit);
    }

    public void OnDisable()
    {
        _signalBus.Unsubscribe<SignalKnifeHitStump>(AnimateStumpHit);
    }

    private void AnimateStumpHit()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(1.1f,1.1f,0),0.03f));
        mySequence.Append(transform.DOScale(new Vector3(1,1,0),0.03f));
    }
}
