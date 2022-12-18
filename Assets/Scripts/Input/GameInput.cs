using UnityEngine;
using Zenject;

namespace Input
{
    public class GameInput : MonoBehaviour
    {
        [Inject]
        readonly SignalBus signalBus;

        void Update()
        {
            if(UnityEngine.Input.GetMouseButtonDown(0))
            {
                signalBus.Fire(new MouseClickedSignal());
            }
        }
    }
}