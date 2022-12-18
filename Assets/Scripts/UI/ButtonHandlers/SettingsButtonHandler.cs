using UI.Factories.Global;
using UnityEngine;
using Zenject;

namespace UI.ButtonHandlers
{
    public class SettingsButtonHandler : MonoBehaviour
    {
        [Inject]
        readonly ISettingsUIFactory _factory;
        public void ButtonClicked()
        {
            Invoke("Create",0.3f);
        }

        private void Create()
        {
            _factory.Create();
        }
    }
}