using UI.Factories.Global;
using UnityEngine;
using Zenject;

public class BackSettingsButtonHandler : MonoBehaviour
{
    [Inject]
    readonly ISettingsUIFactory _factory;
    public void ButtonClicked()
    {
        Invoke("Destroy", 0.3f);
    }

    private void Destroy()
    {
        _factory.Destroy();
    }
}
