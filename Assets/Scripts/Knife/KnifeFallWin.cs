using UnityEngine;
using Zenject;

namespace Knife
{
    public class KnifeFallWin : MonoBehaviour
    {
        [Inject]
        readonly SignalBus _signalBus;
        
        private Rigidbody2D _rigidBody;
        private bool _startAnimation = false;

        void Start()
        {
            _signalBus.Subscribe<SignalFinalKnifeHitStump>(StartAnimation);
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void OnDestroy()
        {
            _signalBus.Unsubscribe<SignalFinalKnifeHitStump>(StartAnimation);
        }

        private void StartAnimation()
        {
            _startAnimation = true;
        }

        void FixedUpdate()
        {
            if (_startAnimation)
            {
                GetComponent<Knife>().IsCollisibleWithKnife=false;
                transform.parent = null;
                _rigidBody.bodyType = RigidbodyType2D.Dynamic;
                _rigidBody.AddTorque(Random.Range(Random.Range(-500, -300), Random.Range(300, 500)));
                _rigidBody.AddForce(new Vector2(Random.Range(Random.Range(-500, -300), Random.Range(300, 500)), 
                                                Random.Range(Random.Range(-500, -300), Random.Range(200, 300))));
                Destroy(this);
            }
        }
    }
}