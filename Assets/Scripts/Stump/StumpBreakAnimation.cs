using Architecure.Services;
using DG.Tweening;
using Knife;
using UnityEngine;
using Zenject;

public class StumpBreakAnimation : MonoBehaviour
{
    [SerializeField] Transform _stumpPart1Prefab;
    [SerializeField] Transform _stumpPart2Prefab;
    [SerializeField] Transform _stumpPart3Prefab;
    [SerializeField] Transform _stumpPart4Prefab;

    [Inject]
    readonly SignalBus _signalBus;

    void Start()
    {
        _signalBus.Subscribe<SignalFinalKnifeHitStump>(StartAnimation);
    }

    void OnDestroy()
    {
        _signalBus.Unsubscribe<SignalFinalKnifeHitStump>(StartAnimation);
    }

    private void StartAnimation()
    {
        Vector3 position = transform.position;
        GetComponent<SpriteRenderer>().enabled=false;
        Transform stump1 = GameObject.Instantiate(_stumpPart1Prefab,position,Quaternion.identity);
        Transform stump2 = GameObject.Instantiate(_stumpPart2Prefab,position,Quaternion.identity);
        Transform stump3 = GameObject.Instantiate(_stumpPart3Prefab,position,Quaternion.identity);
        Transform stump4 = GameObject.Instantiate(_stumpPart4Prefab,position,Quaternion.identity);

        Animate(stump1,new Vector3(4.26f,-4.7f,0),new Vector3(0,0,-66));
        Animate(stump2,new Vector3(-3.8f,-4.9f,0),new Vector3(0,0,-81));
        Animate(stump3,new Vector3(5.3f,2.7f,0),new Vector3(0,0,-88));
        Animate(stump4,new Vector3(-3.85f,1.3f,0),new Vector3(0,0,116));

        Invoke("EndAnimation",0.5f);
    }

    private void EndAnimation()
    {
        Destroy(this.gameObject);
    }

    private void Animate(Transform stumpPart,Vector3 firstPosition,Vector3 firstRotation)
    {
        Sequence mySequence1 = DOTween.Sequence();
        Sequence mySequence2 = DOTween.Sequence();

        mySequence1.Append(stumpPart.DOMove(firstPosition,0.3f));
        mySequence2.Append(stumpPart.DORotate(firstRotation,0.3f));
    }
}
