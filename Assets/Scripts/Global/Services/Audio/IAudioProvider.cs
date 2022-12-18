using ScriptableObjects.Base;
using Global.Audio;

namespace Global.Services.Audio
{
    public interface IAudioProvider
    {
        Sound Get(AudioTypes type);
    }
}