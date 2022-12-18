using UnityEngine;

namespace Knife
{
    public class KnifeFallLoose : MonoBehaviour
    {
        [SerializeField] private KnifeCollisions _knifeCollision;

        private Rigidbody2D _rigidBody;
        private bool _startAnimation = false;

        void Start()
        {
            _knifeCollision.KnifeHitAnotherKnife+=StartAnimation;
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void OnDestroy()
        {
            _knifeCollision.KnifeHitAnotherKnife-=StartAnimation;
        }

        private void StartAnimation()
        {
            _startAnimation = true;
        }

        void FixedUpdate()
        {
            if (_startAnimation)
            {
                _rigidBody.bodyType = RigidbodyType2D.Dynamic;
                _rigidBody.AddTorque(Random.Range(Random.Range(-500, -300), Random.Range(300, 500)));
                _rigidBody.AddForce(new Vector2(Random.Range(Random.Range(-500, -300), Random.Range(300, 500)), 
                                                Random.Range(-500, -300)));
                Destroy(this);
            }
        }
    }
}