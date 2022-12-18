namespace Global.Progress.Data.Transactions
{
    public class TryChangeMaxStageTransaction : GameProgressTransaction
    {
        private readonly int _stage;

        public TryChangeMaxStageTransaction(int stage)
        {
            _stage = stage;
        }
        public override void Execute(GameProgress progress)
        {
            if (_stage > progress.MaxStage)
                progress.MaxStage = _stage;
        }
    }
}