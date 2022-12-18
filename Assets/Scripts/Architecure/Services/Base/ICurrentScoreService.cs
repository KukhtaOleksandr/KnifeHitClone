namespace Architecure.Services
{
    public interface ICurrentScoreService
    {
        int Score {get;}
        void ResetScore();
    }
}
