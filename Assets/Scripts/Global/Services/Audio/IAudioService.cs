using Global.Audio;

namespace Global.Services.Audio
{
    public interface IAudioService
    {
        void Play(AudioTypes audioType);
    }
}