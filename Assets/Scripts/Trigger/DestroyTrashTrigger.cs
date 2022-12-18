using UnityEngine;
using Knife;
using Zenject;

public class DestroyTrashTrigger : MonoBehaviour
{
    [Inject]
    private KnifeFactory _knifeFactory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Knife.Knife>(out Knife.Knife knife))
        {
            _knifeFactory.DestroyKnife(knife);
        }
        else
        {
            GameObject.Destroy(other.gameObject);
        }
    }

}
