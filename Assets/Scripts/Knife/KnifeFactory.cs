using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class KnifeFactory
{
    readonly DiContainer _container;
    readonly Knife.Knife _knifePrefab;
    readonly Vector3 _position;
    readonly Vector3 _animationPosition;

    private List<Knife.Knife> _knives;

    public KnifeFactory(Knife.Knife knifePrefab, DiContainer container)
    {
        _knives = new List<Knife.Knife>();
        _knifePrefab = knifePrefab;
        _container = container;

        _position = new Vector3(0, -3.2f, 0);
        _animationPosition = new Vector3(0, -2.2f, 0);
    }

    public void CreateKnife()
    {
        Knife.Knife knife = _container.InstantiatePrefabForComponent<Knife.Knife>(_knifePrefab, _animationPosition, Quaternion.identity, null);
        SpriteRenderer spriteRenderer = knife.GetComponent<SpriteRenderer>();
        _knives.Add(knife);
        FadeCreation(knife.transform, spriteRenderer);
    }

    public void DestroyAllKnives()
    {
        foreach (Knife.Knife knife in _knives)
        {
            GameObject.Destroy(knife.gameObject);
        }
        _knives.Clear();
    }

    public void DestroyKnife(Knife.Knife knife)
    {
        _knives.Remove(knife);
        GameObject.Destroy(knife.gameObject);
    }

    private void FadeCreation(Transform knife, SpriteRenderer spriteRenderer)
    {
        spriteRenderer.DOFade(0, 0);
        knife.DOMove(_position, 0.1f);
        spriteRenderer.DOFade(1, 0.1f);
    }

}
