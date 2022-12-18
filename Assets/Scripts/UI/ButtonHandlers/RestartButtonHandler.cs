using UnityEngine;
using Zenject;

namespace UI.ButtonHandlers
{
    public class RestartButtonHandler : MonoBehaviour
    {
        [Inject]
        readonly SignalBus _signalBus;

        public void RestartButtonClicked()
        {
            Invoke("DelayForAnimation",0.3f);
        }
        private void DelayForAnimation()
        {
            _signalBus.Fire<SignalRestartButtonClicked>();
        }
    }
}