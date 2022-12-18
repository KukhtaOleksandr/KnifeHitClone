using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace UI.ButtonHandlers
{
    public class PlayButtonHandler : MonoBehaviour
    {
        [Inject]
        private SignalBus _signalBus;
        public async void PlayButtonClicked()
        {
            await Task.Delay(300);
            _signalBus.Fire<SignalPlayButtonClicked>();
        }
    }
}