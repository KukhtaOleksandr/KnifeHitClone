using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace UI.ButtonHandlers
{
    public class HomeButtonHandler : MonoBehaviour
    {
        [Inject]
        private SignalBus _signalBus;
        public async void HomeButtonClicked()
        {
            await Task.Delay(300);
            _signalBus.Fire<SignalHomeButtonClicked>();
        }
    }
}