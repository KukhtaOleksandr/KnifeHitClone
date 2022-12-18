namespace Global.Progress.Data.Transactions
{
    public class TryChangeMaxScoreTransaction : GameProgressTransaction
    {
        private readonly int _score;

        public TryChangeMaxScoreTransaction(int score)
        {
            _score = score;
        }

        public override void Execute(GameProgress progress)
        {
            if (_score > progress.MaxScore)
                progress.MaxScore = _score;
        }
    }
}
