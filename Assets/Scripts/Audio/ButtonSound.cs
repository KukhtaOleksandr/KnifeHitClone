using Global.Services.Audio;
using UnityEngine;
using Zenject;

public class ButtonSound : MonoBehaviour
{
    [Inject]
    readonly IAudioService _audioService;

    public void PlaySound()
    {
        _audioService.Play(Global.Audio.AudioTypes.ButtonTap);
    }
}
