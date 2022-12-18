using Global.Services.Settings;
using Lean.Gui;
using UnityEngine;
using Zenject;

public class SoundsToggleHandler : MonoBehaviour
{
    [Inject]
    readonly ISettingsService _settingsService;
    [Inject]
    readonly SignalBus _signalBus;

    private LeanToggle _leanToggle;

    void Start()
    {
        _leanToggle=GetComponent<LeanToggle>();
        _leanToggle.On = _settingsService.GetSoundState();
    }

    public void SoundsOn()
    {
        _signalBus.Fire<SignalSoundsToggleChanged>(new SignalSoundsToggleChanged() { IsOn = true });
    }
    public void SoundsOff()
    {
        _signalBus.Fire<SignalSoundsToggleChanged>(new SignalSoundsToggleChanged() { IsOn = false });
    }
}
